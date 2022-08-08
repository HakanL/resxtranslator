using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.ResourceOperations;
using ResxTranslator.Tools;

namespace ResxTranslator.Controls
{
    public partial class ResourceTreeView : UserControl
    {
        public ResourceTreeView()
        {
            InitializeComponent();

            treeViewResx.ImageList = new ImageList();
            treeViewResx.ImageList.Images.Add(Properties.Resources.folderHS);
            treeViewResx.ImageList.Images.Add(Properties.Resources.DocumentHS);
            treeViewResx.ImageList.Images.Add(Properties.Resources.Book_openHS);

            treeViewResx.SelectedImageIndex = 2;
        }

        public event EventHandler<ResourceOpenedEventArgs> ResourceOpened;

        public void Clear()
        {
            treeViewResx.Nodes.Clear();
        }

        public void ExecuteFindInNodes(SearchParams searchParams)
        {
            ExecuteFindInNodes(treeViewResx.Nodes.Cast<TreeNode>(), searchParams);
        }

        public void LoadResources(ResourceLoader loader)
        {
            treeViewResx.SuspendLayout();
            treeViewResx.BeginUpdate();

            treeViewResx.Nodes.Clear();

            foreach (var resource in loader.Resources)
            {
                BuildTreeView(resource);
            }

            treeViewResx.ExpandAll();

            if (treeViewResx.Nodes.Count > 0)
                treeViewResx.Nodes.Cast<TreeNode>().OrderBy(x => x.Name).First().EnsureVisible();

            treeViewResx.EndUpdate();
            treeViewResx.ResumeLayout();
        }

        protected virtual void OnResourceOpened(ResourceOpenedEventArgs e)
        {
            ResourceOpened?.Invoke(this, e);
        }

        private static void ExecuteFindInNodes(IEnumerable<TreeNode> searchNodes, SearchParams searchParams)
        {
            foreach (var treeNode in searchNodes)
            {
                treeNode.BackColor = Color.White;
                ExecuteFindInNodes(treeNode.Nodes.Cast<TreeNode>(), searchParams);

                if (MatchNodeToSearch(searchParams, treeNode))
                    treeNode.BackColor = Color.GreenYellow;
            }
        }

        private static bool MatchNodeToSearch(SearchParams searchParams, TreeNode treeNode)
        {
            var resource = treeNode.Tag as ResourceHolder;
            if (resource == null || searchParams == null) return false;

            if (searchParams.Match(SearchParams.TargetType.Lang, resource.NoLanguageLanguage))
                return true;

            var file = resource.Filename.Split('\\');
            if (searchParams.Match(SearchParams.TargetType.File, file[file.Length - 1]))
                return true;

            if (resource.Languages.Values.Any(lng => searchParams.Match(SearchParams.TargetType.Lang, lng.LanguageId)))
                return true;

            foreach (DataRow row in resource.StringsTable.Rows)
            {
                if (searchParams.Match(SearchParams.TargetType.Key, row[Properties.Resources.ColNameKey].ToString()))
                    return true;
                if (searchParams.Match(SearchParams.TargetType.OriginalText, row[Properties.Resources.ColNameNoLang].ToString()))
                    return true;
                if (resource.Languages.Values.Any(
                    lng => searchParams.Match(SearchParams.TargetType.TranslatedText, row[lng.LanguageId].ToString())))
                    return true;
            }

            return false;
        }

        private void BuildTreeView(ResourceHolder resource)
        {
            TreeNode parentNode = null;
            var topFolders = resource.DisplayFolder.Split('\\');
            foreach (var subFolder in topFolders)
            {
                var found = false;
                foreach (TreeNode treeNode in parentNode != null ? parentNode.Nodes : treeViewResx.Nodes)
                {
                    if (treeNode.Tag is PathHolder holder && 
                        holder.Id.Equals(subFolder, StringComparison.InvariantCultureIgnoreCase))
                    {
                        found = true;
                        parentNode = treeNode;
                        break;
                    }
                }

                if (found) continue;

                var pathTreeNode = new TreeNode("[" + subFolder + "]") {Tag = new PathHolder(subFolder), ImageIndex = 0};
                (parentNode != null ? parentNode.Nodes : treeViewResx.Nodes).Add(pathTreeNode);
                parentNode = pathTreeNode;
            }

            var leafNode = new TreeNode(resource.Id) {Tag = resource, ImageIndex = 1};
            parentNode?.Nodes.Add(leafNode);

            SetTreeNodeDirty(leafNode, resource);
            SetTreeNodeTitle(leafNode, resource);

            resource.DirtyChanged += (sender, args) => SetTreeNodeDirty(leafNode, resource);
            resource.LanguageChange += (sender, args) => SetTreeNodeTitle(leafNode, resource);
        }

        private void SelectResourceFromTree()
        {
            var selectedTreeNode = treeViewResx.SelectedNode;
            if (selectedTreeNode == null)
                return;

            if (selectedTreeNode.Tag is PathHolder)
                return;

            Debug.Assert(selectedTreeNode.Tag is ResourceHolder);

            OnResourceOpened(new ResourceOpenedEventArgs((ResourceHolder) selectedTreeNode.Tag));
        }

        private void SetTreeNodeDirty(TreeNode node, ResourceHolder res)
        {
            this.InvokeIfRequired(
                c => { node.ForeColor = res.IsDirty ? Color.Red : Color.Black; });
        }

        private void SetTreeNodeTitle(TreeNode node, ResourceHolder res)
        {
            this.InvokeIfRequired(
                c => { node.Text = res.Caption; });
        }

        private void treeViewResx_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectResourceFromTree();
        }

        private void treeViewResx_DoubleClick(object sender, EventArgs e)
        {
            SelectResourceFromTree();
        }

        public sealed class ResourceOpenedEventArgs : EventArgs
        {
            public ResourceOpenedEventArgs(ResourceHolder resource)
            {
                Resource = resource;
            }

            public ResourceHolder Resource { get; }
        }
    }
}