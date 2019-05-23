using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.ResourceOperations;
using ResxTranslator.Windows;
using System.Text.RegularExpressions;
using ResxTranslator.Tools;

namespace ResxTranslator.Controls
{
    public partial class ResourceGrid : UserControl
    {
        private static readonly string[] SpecialColNames =
        {
            Properties.Resources.ColNameComment,
            Properties.Resources.ColNameError,
            Properties.Resources.ColNameKey,
            Properties.Resources.ColNameNoLang,
            Properties.Resources.ColNameTranslated
        };

        private ResourceHolder _currentResource;
        private SearchParams _currentSearch;
        private bool _showNullValuesAsGrayed;

        public ResourceGrid()
        {
            InitializeComponent();
        }

        public int RowCount => dataGridView1.RowCount;

        public int SelectedCellCount => dataGridView1.SelectedCells.Count;

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
                dataGridView1.Refresh();
                SelectNextSearchResult();
            }
        }

        public bool ShowNullValuesAsGrayed
        {
            get { return _showNullValuesAsGrayed; }
            set
            {
                _showNullValuesAsGrayed = value;
                dataGridView1.Refresh();
            }
        }

        public void DeleteSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

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

            var colNameError = Properties.Resources.ColNameError;
            var colNameKey = Properties.Resources.ColNameKey;
            if (!string.IsNullOrEmpty(r.Cells[colNameError].Value?.ToString()) && (bool)r.Cells[colNameError].Value)
            {
                r.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                r.DefaultCellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            }

            if (r == dataGridView1.Rows[RowCount - 1] && string.IsNullOrEmpty(r.Cells[colNameKey].Value?.ToString()))
                return;


            ApplyConditionalCellFormatting(r.Cells[Properties.Resources.ColNameKey], SearchParams.TargetType.Key);

            ApplyConditionalCellFormatting(r.Cells[Properties.Resources.ColNameNoLang], SearchParams.TargetType.Text);

            foreach (var lng in CurrentResource.Languages.Values)
            {
                ApplyConditionalCellFormatting(r.Cells[lng.LanguageId], SearchParams.TargetType.Text);
            }


            if (!string.IsNullOrEmpty(r.Cells[colNameKey].Value?.ToString()) && r.Cells[colNameKey].Value.ToString().ToLower().Contains(".name"))
            {
                foreach (DataGridViewCell cell in r.Cells)
                {
                    cell.Style.BackColor = Color.LightYellow;                   
                }               
                
            }
            

        }

        private void ApplyConditionalCellFormatting(DataGridViewCell cell, SearchParams.TargetType targType)
        {
            var modified = false;


            if (CurrentSearch != null)
            {
                var matchText = cell.Value as string;

                if (matchText != null && CurrentSearch.Match(targType, matchText))
                {
                    cell.Style.BackColor = Color.GreenYellow;
                    modified = true;
                }
            }

            if (cell.Value.ToString().EndsWith("$$"))
            {
                cell.Value = cell.Value.ToString().Replace("$$", "");
                cell.Style.ForeColor = Color.Green;
            }

            if (cell.Style.BackColor == Color.LightYellow)
                return;

            if (ShowNullValuesAsGrayed && string.IsNullOrWhiteSpace(cell.Value as string))
            {
                cell.Style.BackColor = Color.Gainsboro;
                modified = true;
            }

            if (!modified)
                cell.Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;

            if (!string.IsNullOrEmpty(cell.Value?.ToString()) && cell.Value.ToString().ToLower().Contains(".name"))
                cell.Style.BackColor = Color.LightYellow;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                return;
            }
            if (dataGridView1.CurrentCell.IsInEditMode)
            {
                dataGridView1.EndEdit();
            }

            using (var frm = new CellEditorWindow())
            {
                var value = dataGridView1.CurrentCell.Value;
                if (value == DBNull.Value)
                    frm.textBoxString.Text = string.Empty;
                else
                    frm.textBoxString.Text = (string)value;

                frm.Icon = ParentForm?.Icon;
                frm.StartPosition = FormStartPosition.CenterParent;

                if (frm.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    dataGridView1.CurrentCell.Value = frm.textBoxString.Text;
                    dataGridView1.EndEdit();
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ((DataGridViewTextBoxEditingControl)e.Control).AcceptsReturn = true;
            ((DataGridViewTextBoxEditingControl)e.Control).Multiline = true;
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

            dataGridView1.Columns[Properties.Resources.ColNameNoLang].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[Properties.Resources.ColNameComment].DisplayIndex = dataGridView1.Columns.Count - 1;

            dataGridView1.Columns[Properties.Resources.ColNameTranslated].Visible = false;
            dataGridView1.Columns[Properties.Resources.ColNameError].Visible = false;

            dataGridView1.Columns[Properties.Resources.ColNameKey].ReadOnly = true;
        }

        private void CopyToClipboard()
        {
            if (dataGridView1.SelectedCells.Count == 0)
                return;

            // Add the selection to the clipboard.
            var data = dataGridView1.GetClipboardContent();
            if (data != null) Clipboard.SetDataObject(data);
        }

        private void PasteFromClipboard()
        {
            var currentCell = dataGridView1.CurrentCell;
            var dataObject = Clipboard.GetDataObject() as DataObject;

            if (dataObject == null || !dataObject.GetDataPresent(DataFormats.UnicodeText) || currentCell == null) return;

            var columns = dataGridView1.Columns.Cast<DataGridViewColumn>().OrderBy(c => c.DisplayIndex)
                .Where(c => c.Visible && c.ValueType == typeof(string) &&
                            c.DisplayIndex >= dataGridView1.Columns[currentCell.ColumnIndex].DisplayIndex);

            var rowData = Regex.Split(
                dataObject.GetData(DataFormats.UnicodeText).ToString().TrimEnd(Environment.NewLine.ToCharArray()), Environment.NewLine);

            var data = rowData.Select(r => r.Split('\t')).ToArray();

            var pasteRows = data.Length;
            if (currentCell.RowIndex + pasteRows > dataGridView1.RowCount)
                pasteRows = dataGridView1.RowCount - currentCell.RowIndex;

            if (data.Min(x => x.Length) != data.Max(x => x.Length))
                return;

            var pasteColumns = data[0].Length;

            var j = 0;
            foreach (var column in columns)
            {
                for (var i = 0; i < pasteRows; i++)
                {
                    var cell = dataGridView1.Rows[i + currentCell.RowIndex].Cells[column.Name];
                    if (!cell.ReadOnly)
                        cell.Value = data[i][j];
                }

                j++;

                if (j >= pasteColumns)
                    break;
            }
        }

        private void DeleteSelection()
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (!cell.ReadOnly && cell.Value is string)
                    cell.Value = DBNull.Value;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopyToClipboard();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                PasteFromClipboard();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteSelection();
            }

            if (e.Control && e.Shift && e.KeyCode == Keys.F2)
            {

                if (dataGridView1.SelectedCells.Count == 0)
                    return;

                bool? toUpper = null;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    string texto = cell.Value.ToString();
                    if (string.IsNullOrEmpty(texto))
                        continue;

                    if (toUpper == null)
                    {
                        string lastChar = texto.Substring(texto.Length - 1, 1);
                        if (lastChar.ToUpper().Equals(lastChar))
                            toUpper = true;
                        else
                            toUpper = false;
                    }

                    if ((bool)toUpper)
                    {
                        char[] chars = texto.ToLower().ToCharArray();
                        chars[0] = System.Convert.ToChar(chars[0].ToString().ToUpper());
                        texto = new string(chars);
                    }

                    else
                        texto = texto.ToUpper();

                    cell.Value = texto;
                }
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                var c = dataGridView1[e.ColumnIndex, e.RowIndex];
                if (c.Selected) return;
                c.DataGridView.ClearSelection();
                c.DataGridView.CurrentCell = c;
                c.Selected = true;
            }
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = contextMenuStrip1;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteFromClipboard();
        }

        private void setToEmptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelection();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            ApplyConditionalFormatting(dataGridView1.Rows[e.RowIndex]);
        }

        public void TrimWhitespaceFromSelectedCells()
        {
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                var str = selectedCell.Value as string;
                if (str != null)
                {
                    var start = str.TakeWhile(char.IsWhiteSpace).Count();
                    var end = str.Reverse().TakeWhile(char.IsWhiteSpace).Count();
                    var len = str.Length - start - end;

                    // Don't update the cells if no changes will be made
                    if (len < str.Length)
                    {
                        if (len > 0)
                        {
                            selectedCell.Value = str.Substring(start, len);
                        }
                        else
                        {
                            Debug.Assert(len == 0);
                            selectedCell.Value = string.Empty;
                        }
                    }
                }
            }
        }

        public void ApplyCurrentCellEdit()
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        public void SelectNextMissingTranslation(string languageName)
        {
            if (!dataGridView1.Columns.Contains(languageName)) return;

            var targets = dataGridView1.Rows.Cast<DataGridViewRow>();

            // Get the next element after the current selection if something is already selected
            if (dataGridView1.CurrentCell != null)
            {
                var rowIndex = dataGridView1.Rows.IndexOf(dataGridView1.CurrentCell.OwningRow);
                targets = targets.ToList().Rotate(rowIndex + 1);
            }

            var missingCell = targets.Select((x, i) =>
            {
                var cell = x.Cells[languageName];
                if (cell == null) return null;

                var hasTranslation = cell.Value is string s &&
                    !string.IsNullOrWhiteSpace(s) &&
                    !(s.StartsWith("[") && s.TrimEnd().EndsWith("]"));

                return hasTranslation ? null : cell;
            }).FirstOrDefault(x => x != null);

            if (missingCell != null) dataGridView1.CurrentCell = missingCell;
        }

        public void SelectNextSearchResult()
        {
            if (CurrentSearch == null) return;

            var keyColumn = dataGridView1.Columns[Properties.Resources.ColNameKey];

            var currentRow = dataGridView1.CurrentCell?.RowIndex ?? dataGridView1.RowCount;
            var currentColumn = dataGridView1.CurrentCell?.ColumnIndex ?? -1;

            foreach (DataGridViewRow row in dataGridView1.Rows.Cast<DataGridViewRow>().ToList().Rotate(currentRow))
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex <= currentColumn) continue;

                    if (!(cell.Value is string s)) continue;

                    if (CurrentSearch.Match(cell.OwningColumn == keyColumn ? SearchParams.TargetType.Key : SearchParams.TargetType.Text, s))
                    {
                        dataGridView1.CurrentCell = cell;
                        return;
                    }
                }
                // Skip cells only in the currently selected row (the selected row is first in order thanks to Rotate call)
                currentColumn = -1;
            }
        }
    }
}