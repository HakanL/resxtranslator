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
    public partial class MissingTranslationView : UserControl
    {
        private ResourceLoader _resourceLoader;

        public MissingTranslationView()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
        }

        public ResourceLoader ResourceLoader
        {
            get { return _resourceLoader; }
            set
            {
                if(_resourceLoader != null)
                    _resourceLoader.ResourcesChanged -= ResourceLoaderOnResourcesChanged;

                _resourceLoader = value;

                comboBox1.SelectedIndex = 0;

                if (value != null)
                {
                    _resourceLoader.ResourcesChanged += ResourceLoaderOnResourcesChanged;
                    ResourceLoaderOnResourcesChanged(this, EventArgs.Empty);
                }
            }
        }

        private void ResourceLoaderOnResourcesChanged(object sender, EventArgs eventArgs)
        {
            comboBox1.SelectedIndex = 0;

            // Remove old items except for the default value
            while (comboBox1.Items.Count >= 2)
                comboBox1.Items.RemoveAt(1);

            comboBox1.Items.AddRange(_resourceLoader.GetUsedLanguages().OrderBy(x => x.Name)
                .Select(x=>new ComboBoxWrapper<CultureInfo>(x, info => $"{info.Name} - {info.DisplayName}")).Cast<object>().ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.BeginUpdate();

            listView1.Items.Clear();
            if (comboBox1.SelectedIndex <= 0)
            {
                listView1.Enabled = false;
            }
            else
            {//TODO only missing, click to open, if missing entire file ask to create

                listView1.Enabled = true;

                var selectedCulture = ((ComboBoxWrapper<CultureInfo>) comboBox1.SelectedItem).WrappedObject.Name;

                var missingItems = ResourceLoader.Resources.Where(res => res.HasMissingTranslations(selectedCulture));
                
                listView1.Items.AddRange(missingItems.OrderBy(x=>x.Id).Select(x=>new ListViewItem(x.Id) {Tag = x}).ToArray());
            }

            listView1.EndUpdate();
        }
    }
}
