using BudgetManager.GUI.WinForms.Controls;
namespace BudgetManager.GUI.WinForms.Dialogs
{
    partial class ImportTransactionsPreviewDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.Column_Date = new BudgetManager.GUI.WinForms.Controls.DataGridViewDateColumn();
            this.Column_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Sum = new BudgetManager.GUI.WinForms.Controls.DataGridViewNumberColumn();
            this.Column_Category = new BudgetManager.GUI.WinForms.Controls.DataGridViewCategoryColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMenuItemModifyDate = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuItemChooseCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwImport = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewDateColumn1 = new BudgetManager.GUI.WinForms.Controls.DataGridViewDateColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewNumberColumn1 = new BudgetManager.GUI.WinForms.Controls.DataGridViewNumberColumn();
            this.dataGridViewCategoryColumn1 = new BudgetManager.GUI.WinForms.Controls.DataGridViewCategoryColumn();
            this.ctxMenuItemAcceptCategorySuggestion = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(703, 349);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(249, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "ביטול";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(380, 323);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "אישור";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvTransactions, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(697, 314);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnRemove);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(53, 308);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(3, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(47, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "הסר";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Date,
            this.Column_Description,
            this.Column_Code,
            this.Column_Sum,
            this.Column_Category});
            this.dgvTransactions.ContextMenuStrip = this.contextMenu;
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.Location = new System.Drawing.Point(62, 3);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new System.Drawing.Size(632, 308);
            this.dgvTransactions.TabIndex = 1;
            this.dgvTransactions.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvTransactions_CellContextMenuStripNeeded);
            this.dgvTransactions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellEndEdit);
            this.dgvTransactions.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransactions_DataBindingComplete);
            // 
            // Column_Date
            // 
            this.Column_Date.DataPropertyName = "DateForCalculation";
            this.Column_Date.HeaderText = "תאריך";
            this.Column_Date.Name = "Column_Date";
            // 
            // Column_Description
            // 
            this.Column_Description.DataPropertyName = "Description";
            this.Column_Description.HeaderText = "תיאור";
            this.Column_Description.Name = "Column_Description";
            // 
            // Column_Code
            // 
            this.Column_Code.DataPropertyName = "Code";
            this.Column_Code.HeaderText = "אסמכתא";
            this.Column_Code.Name = "Column_Code";
            // 
            // Column_Sum
            // 
            this.Column_Sum.DataPropertyName = "Sum";
            this.Column_Sum.HeaderText = "סכום";
            this.Column_Sum.Name = "Column_Sum";
            // 
            // Column_Category
            // 
            this.Column_Category.DataPropertyName = "Category";
            this.Column_Category.HeaderText = "סיווג";
            this.Column_Category.Name = "Column_Category";
            this.Column_Category.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuItemModifyDate,
            this.ctxMenuItemChooseCategory,
            this.ctxMenuItemAcceptCategorySuggestion,
            this.toolStripMenuItem1,
            this.ctxMenuItemRemove});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(154, 120);
            // 
            // ctxMenuItemModifyDate
            // 
            this.ctxMenuItemModifyDate.Name = "ctxMenuItemModifyDate";
            this.ctxMenuItemModifyDate.Size = new System.Drawing.Size(153, 22);
            this.ctxMenuItemModifyDate.Text = "שנה תאריך";
            this.ctxMenuItemModifyDate.Click += new System.EventHandler(this.ctxMenuItemModifyDate_Click);
            // 
            // ctxMenuItemChooseCategory
            // 
            this.ctxMenuItemChooseCategory.Name = "ctxMenuItemChooseCategory";
            this.ctxMenuItemChooseCategory.Size = new System.Drawing.Size(153, 22);
            this.ctxMenuItemChooseCategory.Text = "בחר סיווג";
            this.ctxMenuItemChooseCategory.Click += new System.EventHandler(this.ctxMenuItemChooseCategory_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // ctxMenuItemRemove
            // 
            this.ctxMenuItemRemove.Name = "ctxMenuItemRemove";
            this.ctxMenuItemRemove.Size = new System.Drawing.Size(153, 22);
            this.ctxMenuItemRemove.Text = "מחק";
            this.ctxMenuItemRemove.Click += new System.EventHandler(this.ctxMenuItemRemove_Click);
            // 
            // bgwImport
            // 
            this.bgwImport.WorkerSupportsCancellation = true;
            this.bgwImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwImport_DoWork);
            this.bgwImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwImport_RunWorkerCompleted);
            // 
            // dataGridViewDateColumn1
            // 
            this.dataGridViewDateColumn1.DataPropertyName = "DateForCalculation";
            this.dataGridViewDateColumn1.HeaderText = "תאריך";
            this.dataGridViewDateColumn1.Name = "dataGridViewDateColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn1.HeaderText = "תיאור";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn2.HeaderText = "אסמכתא";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewNumberColumn1
            // 
            this.dataGridViewNumberColumn1.DataPropertyName = "Sum";
            this.dataGridViewNumberColumn1.HeaderText = "סכום";
            this.dataGridViewNumberColumn1.Name = "dataGridViewNumberColumn1";
            // 
            // dataGridViewCategoryColumn1
            // 
            this.dataGridViewCategoryColumn1.DataPropertyName = "Category";
            this.dataGridViewCategoryColumn1.HeaderText = "סיווג";
            this.dataGridViewCategoryColumn1.Name = "dataGridViewCategoryColumn1";
            this.dataGridViewCategoryColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ctxMenuItemAcceptCategorySuggestion
            // 
            this.ctxMenuItemAcceptCategorySuggestion.Name = "ctxMenuItemAcceptCategorySuggestion";
            this.ctxMenuItemAcceptCategorySuggestion.Size = new System.Drawing.Size(153, 22);
            this.ctxMenuItemAcceptCategorySuggestion.Text = "קבל הצעת סיווג";
            this.ctxMenuItemAcceptCategorySuggestion.Click += new System.EventHandler(this.ctxMenuItemAcceptCategorySuggestion_Click);
            // 
            // ImportTransactionsPreviewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(703, 349);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImportTransactionsPreviewDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "תנועות שהובאו - תצוגה מקדימה";
            this.Shown += new System.EventHandler(this.ImportTransactionsPreviewDialog_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportTransactionsPreviewDialog_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.ComponentModel.BackgroundWorker bgwImport;
        private DataGridViewDateColumn Column_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Code;
        private DataGridViewNumberColumn Column_Sum;
        private DataGridViewCategoryColumn Column_Category;
        private DataGridViewDateColumn dataGridViewDateColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewNumberColumn dataGridViewNumberColumn1;
        private DataGridViewCategoryColumn dataGridViewCategoryColumn1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemModifyDate;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemChooseCategory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemRemove;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemAcceptCategorySuggestion;
    }
}