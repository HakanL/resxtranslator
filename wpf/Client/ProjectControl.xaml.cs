using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Hauksoft.ResxTranslator
{
    /// <summary>
    /// Interaction logic for ProjectControl.xaml
    /// </summary>
    public partial class ProjectControl : UserControl
    {
        private Data.Solution solution;


        public ProjectControl(Data.Solution solution)
        {
            InitializeComponent();

            this.solution = solution;

            treeView1.Items.Clear();
            TreeViewItem solutionItem = new TreeViewItem
            {
                Header = "Solution",
                IsExpanded = true,
                IsSelected = true
            };
            treeView1.Items.Add(solutionItem);

            PopulateTreeView(solutionItem.Items, solution);

            PopulateDataGridColumns();

            labelResource.Content = string.Empty;
        }


        private void PopulateDataGridColumns()
        {
            dataGrid1.Columns.Clear();

            dataGrid1.Columns.Add(new DataGridTextColumn
            {
                Header = "Key",
                Binding = new Binding("Key"),
                Width = 150,
                IsReadOnly = true
            });
            dataGrid1.Columns.Add(new DataGridTextColumn
            {
                Header = "Base Value",
                Binding = new Binding("BaseData"),
                Width = 150
            });

            foreach (var language in solution.Languages)
            {
                dataGrid1.Columns.Add(new DataGridTextColumn
                {
                    Header = language.Id,
                    Binding = new Binding(string.Format("[{0}]", language.Id))
                });
            }

            dataGrid1.Columns.Add(new DataGridTextColumn
            {
                Header = "Comments",
                Binding = new Binding("Comments"),
                Width = 150
            });
        }


        private void PopulateTreeView(ItemCollection items, Data.IFileHolder fileHolder)
        {
            List<TreeViewItem> folderList = new List<TreeViewItem>();
            foreach (var folder in fileHolder.Folders.Values)
            {
                if (!folder.HasData)
                    continue;

                TreeViewItem item = new TreeViewItem
                {
                    Header = folder.Name,
                    IsExpanded = true,
                    Tag = folder
                };
                folderList.Add(item);

                PopulateTreeView(item.Items, folder);
            }
            folderList.Sort((a, b) => a.Header.ToString().CompareTo(b.Header.ToString()));
            folderList.ForEach(a => items.Add(a));


            List<TreeViewItem> projectList = new List<TreeViewItem>();
            foreach (var project in fileHolder.Projects.Values)
            {
                if (!project.HasData)
                    continue;

                TreeViewItem item = new TreeViewItem
                {
                    Header = project.Name,
                    Tag = project
                };
                projectList.Add(item);

                List<TreeViewItem> resourceList = new List<TreeViewItem>();
                foreach (var resource in project.Resources)
                {
                    if (!resource.HasData)
                        continue;

                    TreeViewItem resourceItem = new TreeViewItem
                    {
                        Header = resource.Name,
                        Tag = resource
                    };
                    resourceList.Add(resourceItem);
                }
                resourceList.Sort((a, b) => a.Header.ToString().CompareTo(b.Header.ToString()));
                resourceList.ForEach(a => item.Items.Add(a));
            }
            projectList.Sort((a, b) => a.Header.ToString().CompareTo(b.Header.ToString()));
            projectList.ForEach(a => items.Add(a));
        }


        public Data.Solution Solution
        {
            get { return solution; }
        }


        private void CommandBindingSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Save");
        }


        private List<Data.ResourceData> GetResourceList(Data.Resource resource)
        {
            List<Data.ResourceData> list = new List<Data.ResourceData>(resource.ResourceData.Values);

            list.Sort((a, b) => a.Key.CompareTo(b.Key));

            return list;
        }


        private List<Data.ResourceData> GetResourceList(Data.Project project)
        {
            List<Data.ResourceData> list = new List<Data.ResourceData>();

            foreach (var resource in project.Resources)
            {
                list.AddRange(resource.ResourceData.Values);
            }

            list.Sort((a, b) => a.Key.CompareTo(b.Key));

            return list;
        }


        private void SetColumnWidths()
        {
            for (int index = 2; index < dataGrid1.Columns.Count; index++)
                dataGrid1.Columns[index].Width = 150;
        }


        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            object tag = (e.NewValue as TreeViewItem).Tag;
            if (tag == null)
            {
                dataGrid1.ItemsSource = null;
                return;
            }

            SetColumnWidths();

            Data.Resource resource = tag as Data.Resource;
            if (resource != null)
            {
                dataGrid1.ItemsSource = GetResourceList(resource);
                return;
            }

            Data.Project project = tag as Data.Project;
            if (project != null)
            {
                dataGrid1.ItemsSource = GetResourceList(project);
                return;
            }

            dataGrid1.ItemsSource = null;
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Data.ResourceData data = e.AddedItems[0] as Data.ResourceData;
                if (data != null)
                    labelResource.Content = data.Parent.Name;
                else
                    labelResource.Content = string.Empty;
            }
            else
                labelResource.Content = string.Empty;
        }
    }
}
