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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectControl activeProject = null;


        public MainWindow()
        {
            InitializeComponent();

            ActiveProject = null;
        }

        private void CommandBindingExit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private ProjectControl ActiveProject
        {
            get { return activeProject; }
            set
            {
                if (value == null)
                {
                    menuItemLanguages.IsEnabled = false;
                    mainGrid.Children.Clear();
                }
                else
                {
                    activeProject = value;

                    mainGrid.Children.Clear();
                    mainGrid.Children.Add(activeProject);

                    menuItemLanguages.IsEnabled = true;
                    menuItemLanguages.Items.Clear();
                    foreach (var language in activeProject.Solution.Languages)
                    {
                        MenuItem menuItem = new MenuItem
                        {
                            Header = language.Id,
                            IsCheckable = true,
                            IsChecked = true
                        };
                        menuItemLanguages.Items.Add(menuItem);
                    }
                }
            }
        }

        private void CommandBindingOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Data.Solution solution =
                new Data.Scanner().ScanRootFolder(@"C:\Projects\Kick\KickP4");

            ProjectControl project = new ProjectControl(solution);

            ActiveProject = project;
        }

        private void CommandBindingClose_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ActiveProject = null;
        }

    }
}
