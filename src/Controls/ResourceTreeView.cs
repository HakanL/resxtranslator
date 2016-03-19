using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ResxTranslator.ResourceOperations;

namespace ResxTranslator.Controls
{
    public partial class ResourceTreeView : UserControl
    {
        public ResourceTreeView()
        {
            InitializeComponent();
        }

        public event EventHandler<ResourceOpenedEventArgs> ResourceOpened;

        public void LoadResources(ResourceLoader loader)
        {
            treeViewResx.Nodes.Clear();

            foreach (var resource in loader.Resources.Values)
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

            OnResourceOpened(new ResourceOpenedEventArgs((ResourceHolder) selectedTreeNode.Tag));
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

                var pathTreeNode = new TreeNode("[" + subFolder + "]");
                var pathHolder = new PathHolder();
                pathHolder.Id = subFolder;
                pathTreeNode.Tag = pathHolder;
                searchNodes.Add(pathTreeNode);

                parentNode = pathTreeNode;
            }

            var leafNode = new TreeNode(resource.Id);
            leafNode.Tag = resource;

            resource.DirtyChanged
                += delegate { SetTreeNodeDirty(leafNode, resource); };

            SetTreeNodeTitle(leafNode, resource);

            resource.LanguageChange
                += delegate { SetTreeNodeTitle(leafNode, resource); };

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
                c => { node.ForeColor = res.IsDirty ? Color.Blue : Color.Black; });
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
            var matchColor = Color.GreenYellow;
            foreach (TreeNode treeNode in searchNodes)
            {
                treeNode.BackColor = Color.White;
                ExecuteFindInNodes(treeNode.Nodes, searchParams);
                var resourceHolder = treeNode.Tag as ResourceHolder;
                if (resourceHolder != null)
                {
                    var resource = resourceHolder;
                    if (searchParams.Match(SearchParams.TargetType.Lang, resource.NoLanguageLanguage))
                    {
                        treeNode.BackColor = matchColor;
                    }
                    var file = resource.Filename.Split('\\');

                    if (searchParams.Match(SearchParams.TargetType.File, file[file.Length - 1]))
                    {
                        treeNode.BackColor = matchColor;
                    }
                    foreach (var lng in resource.Languages.Values)
                    {
                        if (searchParams.Match(SearchParams.TargetType.Lang, lng.LanguageId))
                        {
                            treeNode.BackColor = matchColor;
                        }
                    }
                    foreach (DataRow row in resource.StringsTable.Rows)
                    {
                        if (searchParams.Match(SearchParams.TargetType.Key, row["Key"].ToString()))
                        {
                            treeNode.BackColor = matchColor;
                        }
                        if (searchParams.Match(SearchParams.TargetType.Text, row["NoLanguageValue"].ToString()))
                        {
                            treeNode.BackColor = matchColor;
                        }
                        foreach (var lng in resource.Languages.Values)
                        {
                            if (searchParams.Match(SearchParams.TargetType.Text, row[lng.LanguageId].ToString()))
                            {
                                treeNode.BackColor = matchColor;
                            }
                        }
                    }
                }
            }
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