using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ResxTranslator.Controls
{
    partial class ResourceGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            this.dataGridView1 = new DataGridView();
            this.contextMenuStripCell = new ContextMenuStrip(this.components);
            this.autoTranslateThisCellToolStripMenuItem = new ToolStripMenuItem();
            this.selectSourceColumnToolStripMenuItem = new ToolStripMenuItem();
            this.noLanguageToolStripMenuItem = new ToolStripMenuItem();
            ((ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripCell.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new Size(150, 150);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView1_CellContextMenuStripNeeded);
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseDown += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CellMouseLeave += new DataGridViewCellEventHandler(this.dataGridView1_CellMouseLeave);
            this.dataGridView1.CellMouseUp += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.DragDrop += new DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new DragEventHandler(this.dataGridView1_DragEnter);
            this.dataGridView1.DragOver += new DragEventHandler(this.dataGridView1_DragOver);
            // 
            // contextMenuStripCell
            // 
            this.contextMenuStripCell.Items.AddRange(new ToolStripItem[] {
            this.autoTranslateThisCellToolStripMenuItem});
            this.contextMenuStripCell.Name = "contextMenuStripLanguage";
            this.contextMenuStripCell.Size = new Size(192, 48);
            // 
            // autoTranslateThisCellToolStripMenuItem
            // 
            this.autoTranslateThisCellToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.selectSourceColumnToolStripMenuItem,
            this.noLanguageToolStripMenuItem});
            this.autoTranslateThisCellToolStripMenuItem.Name = "autoTranslateThisCellToolStripMenuItem";
            this.autoTranslateThisCellToolStripMenuItem.Size = new Size(191, 22);
            this.autoTranslateThisCellToolStripMenuItem.Text = "Auto translate this cell";
            this.autoTranslateThisCellToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.autoTranslateThisCellToolStripMenuItem_DropDownItemClicked);
            this.autoTranslateThisCellToolStripMenuItem.Click += new EventHandler(this.autoTranslateThisCellToolStripMenuItem_Click);
            // 
            // selectSourceColumnToolStripMenuItem
            // 
            this.selectSourceColumnToolStripMenuItem.BackColor = SystemColors.ButtonFace;
            this.selectSourceColumnToolStripMenuItem.Enabled = false;
            this.selectSourceColumnToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.selectSourceColumnToolStripMenuItem.ForeColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.selectSourceColumnToolStripMenuItem.Name = "selectSourceColumnToolStripMenuItem";
            this.selectSourceColumnToolStripMenuItem.Size = new Size(198, 22);
            this.selectSourceColumnToolStripMenuItem.Text = "Select Source Column";
            // 
            // noLanguageToolStripMenuItem
            // 
            this.noLanguageToolStripMenuItem.Checked = true;
            this.noLanguageToolStripMenuItem.CheckOnClick = true;
            this.noLanguageToolStripMenuItem.CheckState = CheckState.Checked;
            this.noLanguageToolStripMenuItem.Name = "noLanguageToolStripMenuItem";
            this.noLanguageToolStripMenuItem.Size = new Size(198, 22);
            this.noLanguageToolStripMenuItem.Tag = "NoLanguageValue";
            this.noLanguageToolStripMenuItem.Text = "Non-translated column";
            // 
            // ResourceGrid
            // 
            this.Controls.Add(this.dataGridView1);
            this.Name = "ResourceGrid";
            ((ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripCell.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private ContextMenuStrip contextMenuStripCell;
        private ToolStripMenuItem autoTranslateThisCellToolStripMenuItem;
        private ToolStripMenuItem selectSourceColumnToolStripMenuItem;
        private ToolStripMenuItem noLanguageToolStripMenuItem;
    }
}
