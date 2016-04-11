using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.ResourceOperations;
using ResxTranslator.Windows;

namespace ResxTranslator.Controls
{
    public partial class ResourceGrid : UserControl
    {
        public const string ColNameComment = "Comment";
        public const string ColNameError = "Error";
        public const string ColNameKey = "Key";
        public const string ColNameNoLang = "NoLanguageValue";
        public const string ColNameTranslated = "Translated";

        private static readonly string[] SpecialColNames =
        {
            ColNameComment, ColNameError, ColNameKey, ColNameNoLang,
            ColNameTranslated
        };

        private ResourceHolder _currentResource;
        private SearchParams _currentSearch;

        public ResourceGrid()
        {
            InitializeComponent();
        }

        public int RowCount => dataGridView1.RowCount;

        public ResourceHolder CurrentResource
        {
            get { return _currentResource; }
            set
            {
                _currentResource = value;
                ShowResourceInGrid(value);
            }
        }

        public SearchParams CurrentSearch
        {
            get { return _currentSearch; }
            set
            {
                _currentSearch = value;
                ApplyConditionalFormatting();
            }
        }

        public void ApplyConditionalFormatting()
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                ApplyConditionalFormatting(r);
            }
        }

        public void DeleteSelectedRow()
        {
            var dataRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            dataRow?.Row.Delete();
        }

        public void RefreshResourceDisplay()
        {
            ShowResourceInGrid(CurrentResource);
        }

        public void SetLanguageColumnVisible(string languageId, bool visible)
        {
            if (dataGridView1.Columns.Contains(languageId) && dataGridView1.Columns[languageId] != null)
                dataGridView1.Columns[languageId].Visible = visible;
        }

        public void SetVisibleLanguageColumns(params string[] languageIds)
        {
            foreach (
                var column in
                    dataGridView1.Columns.Cast<DataGridViewColumn>()
                        .Where(column => !SpecialColNames.Contains(column.Name)))
            {
                column.Visible = languageIds.Any(x => x.Equals(column.Name, StringComparison.OrdinalIgnoreCase));
            }
        }

        private void ApplyConditionalFormatting(DataGridViewRow r)
        {
            if (r.Cells[ColNameError].Value != null && (bool) r.Cells[ColNameError].Value)
            {
                r.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                r.DefaultCellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            }

            if (CurrentSearch != null)
            {
                ApplyConditionalFormattingFromCurrentSearch(r.Cells[ColNameKey], SearchParams.TargetType.Key);

                ApplyConditionalFormattingFromCurrentSearch(r.Cells[ColNameNoLang], SearchParams.TargetType.Text);

                foreach (var lng in CurrentResource.Languages.Values)
                {
                    ApplyConditionalFormattingFromCurrentSearch(r.Cells[lng.LanguageId], SearchParams.TargetType.Text);
                }
            }
        }

        private void ApplyConditionalFormattingFromCurrentSearch(DataGridViewCell cell, SearchParams.TargetType targType)
        {
            string matchText = cell.Value as string;

            if (matchText != null && CurrentSearch.Match(targType, matchText))
            {
                cell.Style.BackColor = Color.GreenYellow;
            }
            else
            {
                cell.Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
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

            var frm = new CellEditorWindow();
            var value = dataGridView1.CurrentCell.Value;
            if (value == DBNull.Value)
                frm.textBoxString.Text = string.Empty;
            else
                frm.textBoxString.Text = (string) value;

            frm.Icon = ParentForm?.Icon;
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog(ParentForm) == DialogResult.OK)
            {
                dataGridView1.CurrentCell.Value = frm.textBoxString.Text;
                dataGridView1.EndEdit();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ApplyConditionalFormatting(dataGridView1.Rows[e.RowIndex]);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ((DataGridViewTextBoxEditingControl) e.Control).AcceptsReturn = true;
            ((DataGridViewTextBoxEditingControl) e.Control).Multiline = true;
        }

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
    }
}