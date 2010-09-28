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
        }


        public Data.Solution Solution
        {
            get { return solution; }
        }


        private void CommandBindingSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Save");
       }
    }
}
