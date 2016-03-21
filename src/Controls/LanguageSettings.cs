using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

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
            List<CultureInfo> storedDisabled = null;
            if(perserveState)
                storedDisabled = DisabledLanguages.ToList();

            listView1.SuspendLayout();
            listView1.BeginUpdate();

            listView1.Items.Clear();

            foreach (var cultureInfo in languages)
            {
                listView1.Items.Add(new ListViewItem(new[] { cultureInfo.Name, cultureInfo.DisplayName })
                {
                    Tag = cultureInfo,
                    Checked = !perserveState || !storedDisabled.Contains(cultureInfo)
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

        public IEnumerable<CultureInfo> DisabledLanguages
        {
            get
            {
                var enabledItems = listView1.CheckedItems.Cast<ListViewItem>();
                return listView1.Items.Cast<ListViewItem>()
                    .Where(x => !enabledItems.Contains(x))
                    .Select(x => x.Tag as CultureInfo);
            }
        }

        public void SetLanguageState(string languageId, bool newState)
        {
            var item = listView1.Items.Cast<ListViewItem>()
                .FirstOrDefault(x=>((CultureInfo) x.Tag).Name.Equals(languageId, StringComparison.OrdinalIgnoreCase));

            if (item == null || item.Checked == newState) return;
            
            item.Checked = newState;
        }

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
