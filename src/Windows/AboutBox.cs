using System.Reflection;
using System.Windows.Forms;

namespace ResxTranslator.Windows
{
    internal sealed partial class AboutBox : Form
    {
        private AboutBox()
        {
            InitializeComponent();
            labelProductName.Text = labelProductName.Text + @": " + AssemblyProduct;
            labelVersion.Text = labelVersion.Text + @": " + AssemblyVersion;
            labelCopyright.Text = labelCopyright.Text + @": " + AssemblyCopyright;
            labelCompanyName.Text = labelCompanyName.Text + @": " + AssemblyCompany;
        }

        public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static void ShowAboutBox(IWin32Window owner)
        {
            using (var window = new AboutBox())
                window.ShowDialog(owner);
        }
    }
}