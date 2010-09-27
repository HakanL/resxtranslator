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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            Project project = new Project();
            mainFrame.Content = project;

            ResxManager.Solution solution =
                new ResxManager.Scanner().ScanRootFolder(@"C:\Projects\Kick\KickP4\Client");
        }

        private void SetAsMainContent(UIElement uiElement)
        {
            //mainFrame.Content = uiChildren.Clear();
            //mainFrame.Children.Add(uiElement);
            uiElement.SetValue(WidthProperty, Double.NaN);
            uiElement.SetValue(HeightProperty, Double.NaN);
        }
    }
}
