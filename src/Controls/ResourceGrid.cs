using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.Properties;
using ResxTranslator.ResourceOperations;
using ResxTranslator.Windows;
// ReSharper disable PossibleNullReferenceException

namespace ResxTranslator.Controls
{
    public partial class ResourceGrid : UserControl
    {
        public ResourceHolder CurrentResource
        {
            get { return _currentResource; }
            set
            {
                _currentResource = value;
                ShowResourceInGrid(value);
            }
        }

        public bool DisplayContextMenu
        {
            get { return contextMenuStripCell.Enabled; }
            set { contextMenuStripCell.Enabled = value; }
        }

        public int RowCount => dataGridView1.RowCount;

        public void DeleteSelectedRow()
        {
            var dataRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            dataRow?.Row.Delete();
        }

        public ResourceGrid()
        {
            InitializeComponent();
        }

        public void RefreshResourceDisplay()
        {
            ShowResourceInGrid(CurrentResource);
        }

        private const string ColNameNoLang = "NoLanguageValue";
        private const string ColNameComment = "Comment";
        private const string ColNameTranslated = "Translated";
        private const string ColNameError = "Error";
        private const string ColNameKey = "Key";

        private static readonly string[] SpecialColNames = {ColNameComment, ColNameError, ColNameKey, ColNameNoLang, ColNameTranslated};

        private ResourceHolder _currentResource;

        private void ShowResourceInGrid(ResourceHolder resource)
        {
            if (resource == null)
            {
                dataGridView1.DataSource = null;
                return;
            }

            dataGridView1.DataSource = resource.StringsTable;

            foreach (var languageHolder in resource.Languages.Values)
            {
                dataGridView1.Columns[languageHolder.LanguageId].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            dataGridView1.Columns[ColNameNoLang].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[ColNameComment].DisplayIndex = dataGridView1.Columns.Count - 1;

            dataGridView1.Columns[ColNameTranslated].Visible = false;
            dataGridView1.Columns[ColNameError].Visible = false;
            
            dataGridView1.Columns[ColNameKey].ReadOnly = true;

            ApplyConditionalFormatting();
        }

        public void SetVisibleLanguageColumns(params string[] languageIds)
        {
            foreach (var column in dataGridView1.Columns.Cast<DataGridViewColumn>().Where(column => !SpecialColNames.Contains(column.Name)))
            {
                column.Visible = languageIds.Any(x => x.Equals(column.Name, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void SetLanguageColumnVisible(string languageId, bool visible)
        {
            if (dataGridView1.Columns.Contains(languageId))
            {
                dataGridView1.Columns[languageId].Visible = visible;
            }
        }

        public void ApplyConditionalFormatting()
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                ApplyConditionalFormatting(r);
            }
        }


        static int FindCheckedSubItemIndex(ToolStripDropDownItem autoTranslate)
        {
            for (var index = 0; index < autoTranslate.DropDownItems.Count; index++)
            {
                var item = autoTranslate.DropDownItems[index] as ToolStripMenuItem;
                if (item.Checked)
                {
                    return index;
                }
            }
            return -1;
        }

        private void autoTranslateThisCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colIndex = dataGridView1.CurrentCell.ColumnIndex;
            var column = dataGridView1.Columns[colIndex].Name;
            var source = dataGridView1.CurrentCell.Value.ToString();

            var autoTranslate =
                contextMenuStripCell.Items["autoTranslateThisCellToolStripMenuItem"] as ToolStripMenuItem;

            var preferred = ColNameNoLang;
            if (!(autoTranslate.DropDownItems[1] as ToolStripMenuItem).Checked)
            {
                var subChk = FindCheckedSubItemIndex(autoTranslate);
                preferred = subChk > -1 ? autoTranslate.DropDownItems[subChk].Text : Settings.Default.PreferredSourceLanguage;
            }

            if (string.IsNullOrEmpty(source.Trim()))
            {
                source = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[preferred].Value.ToString();
            }
            if (column == ColNameNoLang)
            {
                column = CurrentResource.NoLanguageLanguage;
            }

            var translation = BingTranslator.TranslateString(source, column);
            dataGridView1.CurrentCell.Value = translation;
            dataGridView1.EndEdit();
        }

        private void autoTranslateThisCellToolStripMenuItem_DropDownItemClicked(object sender,
            ToolStripItemClickedEventArgs e)
        {
            var checkedItem = e.ClickedItem as ToolStripMenuItem;
            var autoTranslate =
                contextMenuStripCell.Items["autoTranslateThisCellToolStripMenuItem"] as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in autoTranslate.DropDownItems)
                item.Checked = false;
            checkedItem.Checked = true;
            var preferred = "" + checkedItem.Tag == ColNameNoLang ? ColNameNoLang : checkedItem.Text;

            Settings.Default.PreferredSourceLanguage = preferred;

            var colIndex = dataGridView1.CurrentCell.ColumnIndex;
            var column = dataGridView1.Columns[colIndex].Name;
            if (column == ColNameNoLang)
            {
                column = CurrentResource.NoLanguageLanguage;
            }
            var source = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[preferred].Value.ToString();

            var translation = BingTranslator.TranslateString(source, column);
            dataGridView1.CurrentCell.Value = translation;
            dataGridView1.EndEdit();
        }

        private void ApplyConditionalFormatting(DataGridViewRow r)
        {
            if (r.Cells[ColNameError].Value != null && (bool)r.Cells[ColNameError].Value)
            {
                r.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                r.DefaultCellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                return;
            }
            if (dataGridView1.CurrentCell.IsInEditMode)
            {
                return;
            }

            var frm = new ZoomWindow();
            var value = dataGridView1.CurrentCell.Value;
            if (value == DBNull.Value)
            {
                frm.textBoxString.Text = "";
            }
            else
            {
                frm.textBoxString.Text = (string)value;
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.CurrentCell.Value = frm.textBoxString.Text;
                dataGridView1.EndEdit();
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ((DataGridViewTextBoxEditingControl)e.Control).AcceptsReturn = true;
            ((DataGridViewTextBoxEditingControl)e.Control).Multiline = true;
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender,
            DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            e.ContextMenuStrip = contextMenuStripCell;

            var autoTranslate = contextMenuStripCell.Items["autoTranslateThisCellToolStripMenuItem"] as ToolStripMenuItem;

            if (autoTranslate.DropDownItems.Count < 3)
            {
                //rebuild the language select drop down
                var subChk = FindCheckedSubItemIndex(autoTranslate);
                var chkedLang = "";
                if (subChk > -1)
                {
                    chkedLang = autoTranslate.DropDownItems[subChk].Text;
                }
                else
                {
                    (autoTranslate.DropDownItems[0] as ToolStripMenuItem).Checked = true;
                }

                for (var i = autoTranslate.DropDownItems.Count - 1; i > 1; --i)
                {
                    autoTranslate.DropDownItems.RemoveAt(i);
                }

                foreach (var lang in CurrentResource.Languages.Keys)
                {
                    autoTranslate.DropDownItems.Add(lang);
                    var newItem =
                        autoTranslate.DropDownItems[autoTranslate.DropDownItems.Count - 1] as ToolStripMenuItem;
                    if (chkedLang == lang)
                    {
                        newItem.Checked = true;
                    }
                }
            }


            var preferred = ColNameNoLang;
            if (!(autoTranslate.DropDownItems[1] as ToolStripMenuItem).Checked)
            {
                var subChk = FindCheckedSubItemIndex(autoTranslate);
                if (subChk > -1)
                {
                    preferred = autoTranslate.DropDownItems[subChk].Text;
                }
            }

            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var source = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[preferred].Value.ToString();
            var colIndex = dataGridView1.CurrentCell.ColumnIndex;
            var column = dataGridView1.Columns[colIndex].Name;

            var listofalternatives = InprojectTranslator.Instance.GetTranslations(CurrentResource.NoLanguageLanguage,
                source, column);

            for (var i = e.ContextMenuStrip.Items.Count - 1; i > 0; --i)
            {
                if (e.ContextMenuStrip.Items[i].Name.StartsWith("Transl"))
                {
                    e.ContextMenuStrip.Items.RemoveAt(i);
                }
            }
            foreach (var alt in listofalternatives)
            {
                e.ContextMenuStrip.Items.Add(alt);
                var newItem = e.ContextMenuStrip.Items[e.ContextMenuStrip.Items.Count - 1];
                var translation = alt;
                var cell = dataGridView1.CurrentCell;
                newItem.Click += (EventHandler)delegate
                {
                    cell.Value = translation;
                    dataGridView1.EndEdit();
                };
                newItem.Name = "Transl_" + alt;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ApplyConditionalFormatting(dataGridView1.Rows[e.RowIndex]);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //_mouseDownStart = DateTime.Now;
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //_mouseDownStart = DateTime.MaxValue;
            //dataGridView1.AllowDrop = false;
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            /*if (DateTime.Now.Subtract(_mouseDownStart).TotalMilliseconds > 50)
            {
                _mouseDownStart = DateTime.MaxValue;
                if (e.RowIndex > -1 && e.ColumnIndex > 0)
                {
                    var text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (!string.IsNullOrEmpty(text))
                    {
                        dataGridView1.AllowDrop = true;
                        DoDragDrop(text, DragDropEffects.All);
                        _dndInProgress = true;
                    }
                }
            }*/
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            /*var p = dataGridView1.PointToClient(new Point(e.X, e.Y));
            var info = dataGridView1.HitTest(p.X, p.Y);
            var value = e.Data.GetData(typeof(string));
            dataGridView1.AllowDrop = false;
            if (info.RowIndex != -1 && info.ColumnIndex != -1 && (Control.ModifierKeys & Keys.Control) != 0)
            {
                if (value != null)
                {
                    dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex].Value = value.ToString();
                }
            }
            _dndInProgress = false;*/
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.All;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            /*if (_dndInProgress)
            {
                e.Effect = (Control.ModifierKeys & Keys.Control) != 0 ? DragDropEffects.Copy : DragDropEffects.None;
            }*/
        }
    }
}
