using System.Windows.Forms;
using ResxTranslator.Properties;

namespace ResxTranslator.Windows
{
    public partial class CellEditorWindow : Form
    {
        public CellEditorWindow()
        {
            InitializeComponent();

            Settings.Binder.BindControl(checkBox1, settings => settings.CellEditorWrapContents, this);
            Settings.Binder.Subscribe((sender, args) => textBoxString.WordWrap = args.NewValue, 
                settings => settings.CellEditorWrapContents, this);
            Settings.Binder.SendUpdates(this);
        }

        private void ZoomWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Binder.RemoveHandlers(this);
        }
    }
}