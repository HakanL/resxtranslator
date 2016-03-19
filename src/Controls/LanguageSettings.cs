using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ResxTranslator.ResourceOperations;

namespace ResxTranslator.Controls
{
    public partial class LanguageSettings : UserControl
    {
        public LanguageSettings()
        {
            InitializeComponent();
        }
        
        public void RefreshLanguages(IEnumerable<CultureInfo> languages, bool perserveState)
        {
            List<CultureInfo> storedEnabled = null;
            if(perserveState)
                storedEnabled = EnabledLanguages.ToList();

            listView1.SuspendLayout();
            listView1.BeginUpdate();

            listView1.Items.Clear();

            foreach (var cultureInfo in languages)
            {
                listView1.Items.Add(new ListViewItem(new[] { cultureInfo.Name, cultureInfo.DisplayName })
                {
                    Tag = cultureInfo,
                    Checked = !perserveState || storedEnabled.Contains(cultureInfo)
                });
            }
            
            listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            if (listView1.Columns[1].Width < 100)
                listView1.Columns[1].Width = 100;

            listView1.EndUpdate();
            listView1.ResumeLayout();
        }

        public IEnumerable<CultureInfo> EnabledLanguages
            => listView1.CheckedItems.Cast<ListViewItem>().Select(x => x.Tag as CultureInfo);

        public event EventHandler EnabledLanguagesChanged;

        protected virtual void OnEnabledLanguagesChanged()
        {
            EnabledLanguagesChanged?.Invoke(this, EventArgs.Empty);
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            OnEnabledLanguagesChanged();
        }
    }
}
