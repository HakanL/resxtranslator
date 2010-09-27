using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ResxTranslator
{
    public partial class AddKey : Form
    {
        private ResourceHolder resourceHolder;


        public AddKey(ResourceHolder resourceHolder)
        {
            InitializeComponent();

            this.resourceHolder = resourceHolder;
        }


        public string Key
        {
            get
            {
                return txtKey.Text;
            }
        }


        public string NoXlateValue
        {
            get
            {
                return txtNoXlateValue.Text;
            }
        }

        
        public string DefaultValue
        {
            get
            {
                return txtDefaultValue.Text;
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            txtDefaultValue.Text =
            txtNoXlateValue.Text = Common.GetDefaultValue(txtKey.Text);

            string error = null;
            if (resourceHolder.KeyExists(txtKey.Text))
                error = "Key exists";

            errorProvider.SetError(txtKey, error);

            btnAdd.Enabled = string.IsNullOrEmpty(error);
        }
    }


}
