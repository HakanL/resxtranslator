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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStripCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoTranslateThisCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectSourceColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripCell.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(150, 150);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView1_CellContextMenuStripNeeded);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseLeave);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            // 
            // contextMenuStripCell
            // 
            this.contextMenuStripCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoTranslateThisCellToolStripMenuItem});
            this.contextMenuStripCell.Name = "contextMenuStripLanguage";
            this.contextMenuStripCell.Size = new System.Drawing.Size(192, 26);
            // 
            // autoTranslateThisCellToolStripMenuItem
            // 
            this.autoTranslateThisCellToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSourceColumnToolStripMenuItem,
            this.noLanguageToolStripMenuItem});
            this.autoTranslateThisCellToolStripMenuItem.Name = "autoTranslateThisCellToolStripMenuItem";
            this.autoTranslateThisCellToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.autoTranslateThisCellToolStripMenuItem.Text = "Auto translate this cell";
            this.autoTranslateThisCellToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.autoTranslateThisCellToolStripMenuItem_DropDownItemClicked);
            this.autoTranslateThisCellToolStripMenuItem.Click += new System.EventHandler(this.autoTranslateThisCellToolStripMenuItem_Click);
            // 
            // selectSourceColumnToolStripMenuItem
            // 
            this.selectSourceColumnToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.selectSourceColumnToolStripMenuItem.Enabled = false;
            this.selectSourceColumnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSourceColumnToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.selectSourceColumnToolStripMenuItem.Name = "selectSourceColumnToolStripMenuItem";
            this.selectSourceColumnToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.selectSourceColumnToolStripMenuItem.Text = "Select Source Column";
            // 
            // noLanguageToolStripMenuItem
            // 
            this.noLanguageToolStripMenuItem.Checked = true;
            this.noLanguageToolStripMenuItem.CheckOnClick = true;
            this.noLanguageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noLanguageToolStripMenuItem.Name = "noLanguageToolStripMenuItem";
            this.noLanguageToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.noLanguageToolStripMenuItem.Tag = "NoLanguageValue";
            this.noLanguageToolStripMenuItem.Text = "Non-translated column";
            // 
            // ResourceGrid
            // 
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ResourceGrid";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
