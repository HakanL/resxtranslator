using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.Properties;
using ResxTranslator.ResourceOperations;

namespace ResxTranslator.Controls
{
    public partial class ResourceTreeView : UserControl
    {
        public ResourceTreeView()
        {
            InitializeComponent();

            treeViewResx.ImageList = new ImageList();
            treeViewResx.ImageList.Images.Add(Resources.folderHS);
            treeViewResx.ImageList.Images.Add(Resources.DocumentHS);
            treeViewResx.ImageList.Images.Add(Resources.Book_openHS);

            treeViewResx.SelectedImageIndex = 2;
        }

        public event EventHandler<ResourceOpenedEventArgs> ResourceOpened;

        public void LoadResources(ResourceLoader loader)
        {
            treeViewResx.Nodes.Clear();

            foreach (var resource in loader.Resources)
            {
                BuildTreeView(resource);
            }

            treeViewResx.ExpandAll();
        }

        public void Clear()
        {
            treeViewResx.Nodes.Clear();
        }

        private void treeViewResx_DoubleClick(object sender, EventArgs e)
        {
            SelectResourceFromTree();
        }

        private void treeViewResx_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectResourceFromTree();
        }

        private void SelectResourceFromTree()
        {
            var selectedTreeNode = treeViewResx.SelectedNode;
            if (selectedTreeNode == null)
                return;

            if (selectedTreeNode.Tag is PathHolder)
                return;

            Debug.Assert(selectedTreeNode.Tag is ResourceHolder);

            OnResourceOpened(new ResourceOpenedEventArgs((ResourceHolder)selectedTreeNode.Tag));
        }

        private void BuildTreeView(ResourceHolder resource)
        {
            TreeNode parentNode = null;
            var topFolders = resource.DisplayFolder.Split('\\');
            foreach (var subFolder in topFolders)
            {
                var searchNodes = parentNode?.Nodes ?? treeViewResx.Nodes;
                var found = false;
                foreach (TreeNode treeNode in searchNodes)
                {
                    var holder = treeNode.Tag as PathHolder;
                    if (holder != null && holder.Id.Equals(subFolder, StringComparison.InvariantCultureIgnoreCase))
                    {
                        found = true;
                        parentNode = treeNode;
                        break;
                    }
                }

                if (found) continue;

                var pathTreeNode = new TreeNode("[" + subFolder + "]") { Tag = new PathHolder(subFolder), ImageIndex = 0 };
                searchNodes.Add(pathTreeNode);
                parentNode = pathTreeNode;
            }

            var leafNode = new TreeNode(resource.Id) { Tag = resource, ImageIndex = 1 };

            resource.DirtyChanged += (sender, args) => SetTreeNodeDirty(leafNode, resource);

            SetTreeNodeTitle(leafNode, resource);

            resource.LanguageChange += (sender, args) => SetTreeNodeTitle(leafNode, resource);

            parentNode?.Nodes.Add(leafNode);
        }

        private void SetTreeNodeTitle(TreeNode node, ResourceHolder res)
        {
            this.InvokeIfRequired(
                c => { node.Text = res.Caption; });
        }

        private void SetTreeNodeDirty(TreeNode node, ResourceHolder res)
        {
            this.InvokeIfRequired(
                c => { node.ForeColor = res.IsDirty ? Color.Red : Color.Black; });
        }

        protected virtual void OnResourceOpened(ResourceOpenedEventArgs e)
        {
            ResourceOpened?.Invoke(this, e);
        }

        public void ExecuteFindInNodes(SearchParams searchParams)
        {
            ExecuteFindInNodes(treeViewResx.Nodes, searchParams);
        }

        private static void ExecuteFindInNodes(TreeNodeCollection searchNodes, SearchParams searchParams)
        {
            foreach (TreeNode treeNode in searchNodes)
            {
                treeNode.BackColor = Color.White;
                ExecuteFindInNodes(treeNode.Nodes, searchParams);

                if (MatchNodeToSearch(searchParams, treeNode))
                    treeNode.BackColor = Color.GreenYellow;
            }
        }

        private static bool MatchNodeToSearch(SearchParams searchParams, TreeNode treeNode)
        {
            var resource = treeNode.Tag as ResourceHolder;
            if (resource == null) return false;

            if (searchParams.Match(SearchParams.TargetType.Lang, resource.NoLanguageLanguage))
                return true;

            var file = resource.Filename.Split('\\');
            if (searchParams.Match(SearchParams.TargetType.File, file[file.Length - 1]))
                return true;

            if (resource.Languages.Values.Any(lng => searchParams.Match(SearchParams.TargetType.Lang, lng.LanguageId)))
                return true;

            foreach (DataRow row in resource.StringsTable.Rows)
            {
                if (searchParams.Match(SearchParams.TargetType.Key, row["Key"].ToString()))
                    return true;
                if (searchParams.Match(SearchParams.TargetType.Text, row["NoLanguageValue"].ToString()))
                    return true;
                if (resource.Languages.Values.Any(
                    lng => searchParams.Match(SearchParams.TargetType.Text, row[lng.LanguageId].ToString())))
                    return true;
            }

            return false;
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