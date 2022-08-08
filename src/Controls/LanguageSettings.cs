using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.Properties;

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
            var storedDisabled = perserveState ? DisabledLanguages.ToList() : Settings.Default.DisabledDisplayedLanguages?.Cast<string>().Select(CultureInfo.GetCultureInfo).ToList() ?? new List<CultureInfo>();

            listView1.SuspendLayout();
            listView1.BeginUpdate();

            listView1.Items.Clear();

            foreach (var cultureInfo in languages)
            {
                listView1.Items.Add(new ListViewItem(new[] { cultureInfo.Name, cultureInfo.DisplayName })
                {
                    Tag = cultureInfo,
                    Checked = !storedDisabled.Contains(cultureInfo)
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
                .FirstOrDefault(x => ((CultureInfo)x.Tag).Name.Equals(languageId, StringComparison.OrdinalIgnoreCase));

            if (item == null || item.Checked == newState) return;

            item.Checked = newState;
        }

        public event EventHandler EnabledLanguagesChanged;

        protected virtual void OnEnabledLanguagesChanged()
        {
            Settings.Default.DisabledDisplayedLanguages = new StringCollection();
            Settings.Default.DisabledDisplayedLanguages.AddRange(DisabledLanguages.Select(x => x.Name).ToArray());

            EnabledLanguagesChanged?.Invoke(this, EventArgs.Empty);
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            OnEnabledLanguagesChanged();
        }

        private void toolStripButtonSelectAll_Click(object sender, EventArgs e)
        {
            SetAllItemsChecked(CheckState.Checked);
        }

        private void toolStripButtonSelectNone_Click(object sender, EventArgs e)
        {
            SetAllItemsChecked(CheckState.Unchecked);
        }

        private void toolStripButtonSelectInvert_Click(object sender, EventArgs e)
        {
            SetAllItemsChecked(CheckState.Indeterminate);
        }

        private void SetAllItemsChecked(CheckState state)
        {
            listView1.BeginUpdate();
            listView1.ItemChecked -= listView1_ItemChecked;

            foreach (ListViewItem item in listView1.Items)
            {
                switch (state)
                {
                    case CheckState.Checked:
                        item.Checked = true;
                        break;
                    case CheckState.Unchecked:
                        item.Checked = false;
                        break;
                    case CheckState.Indeterminate:
                        item.Checked = !item.Checked;
                        break;
                }
            }

            listView1.ItemChecked += listView1_ItemChecked;
            listView1.EndUpdate();

            OnEnabledLanguagesChanged();
        }
    }
}
