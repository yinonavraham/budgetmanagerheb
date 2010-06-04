namespace BudgetManager.GUI.WinForms.Controls
{
    partial class TransactionsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode4});
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeCategories = new System.Windows.Forms.TreeView();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.Column_InternalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OriginalDate = new BudgetManager.GUI.WinForms.Controls.DataGridViewDateColumn();
            this.Column_Date = new BudgetManager.GUI.WinForms.Controls.DataGridViewDateColumn();
            this.Column_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Sum = new BudgetManager.GUI.WinForms.Controls.DataGridViewNumberColumn();
            this.Column_Category = new BudgetManager.GUI.WinForms.Controls.DataGridViewCategoryColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.datesSearchPanel = new BudgetManager.GUI.WinForms.Controls.DatesSearchPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.ctxMenuTransactions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMenuItemNewTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuItemDuplicateTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuItemDeleteTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuItemRestoreDate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMenuItemSellectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuItemSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuCategories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMenuCategoriesItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuCategoriesItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuCategoriesItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.ctxMenuTransactions.SuspendLayout();
            this.ctxMenuCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(3, 31);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeCategories);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvTransactions);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer.Size = new System.Drawing.Size(657, 324);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.TabIndex = 1;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // treeCategories
            // 
            this.treeCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCategories.HideSelection = false;
            this.treeCategories.Location = new System.Drawing.Point(0, 0);
            this.treeCategories.Name = "treeCategories";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node3";
            treeNode2.Text = "Node3";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Node2";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Node4";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Node0";
            this.treeCategories.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.treeCategories.RightToLeftLayout = true;
            this.treeCategories.Size = new System.Drawing.Size(196, 320);
            this.treeCategories.TabIndex = 0;
            this.treeCategories.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeCategories_AfterLabelEdit);
            this.treeCategories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeCategories_AfterSelect);
            this.treeCategories.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeCategories_NodeMouseClick);
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToResizeRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_InternalID,
            this.Column_OriginalDate,
            this.Column_Date,
            this.Column_Description,
            this.Column_Code,
            this.Column_Sum,
            this.Column_Category});
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.Location = new System.Drawing.Point(0, 0);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new System.Drawing.Size(449, 320);
            this.dgvTransactions.TabIndex = 0;
            this.dgvTransactions.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellLeave);
            this.dgvTransactions.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvTransactions_RowValidating);
            this.dgvTransactions.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvTransactions_CancelRowEdit);
            this.dgvTransactions.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvTransactions_CellContextMenuStripNeeded);
            this.dgvTransactions.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_RowLeave);
            this.dgvTransactions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTransactions_KeyDown);
            this.dgvTransactions.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransactions_DataBindingComplete);
            this.dgvTransactions.Resize += new System.EventHandler(this.dgvTransactions_Resize);
            this.dgvTransactions.SelectionChanged += new System.EventHandler(this.dgvTransactions_SelectionChanged);
            // 
            // Column_InternalID
            // 
            this.Column_InternalID.DataPropertyName = "InternalID";
            this.Column_InternalID.HeaderText = "InternalID";
            this.Column_InternalID.Name = "Column_InternalID";
            this.Column_InternalID.ReadOnly = true;
            this.Column_InternalID.Visible = false;
            this.Column_InternalID.Width = 78;
            // 
            // Column_OriginalDate
            // 
            this.Column_OriginalDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column_OriginalDate.DataPropertyName = "Date";
            this.Column_OriginalDate.HeaderText = "תאריך מקורי";
            this.Column_OriginalDate.Name = "Column_OriginalDate";
            this.Column_OriginalDate.ReadOnly = true;
            this.Column_OriginalDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_OriginalDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_OriginalDate.Visible = false;
            // 
            // Column_Date
            // 
            this.Column_Date.DataPropertyName = "DateForCalculation";
            this.Column_Date.HeaderText = "תאריך";
            this.Column_Date.MinimumWidth = 80;
            this.Column_Date.Name = "Column_Date";
            this.Column_Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_Date.Width = 80;
            // 
            // Column_Description
            // 
            this.Column_Description.DataPropertyName = "Description";
            this.Column_Description.HeaderText = "תיאור";
            this.Column_Description.Name = "Column_Description";
            this.Column_Description.Width = 63;
            // 
            // Column_Code
            // 
            this.Column_Code.DataPropertyName = "Code";
            this.Column_Code.HeaderText = "אסמכתא";
            this.Column_Code.Name = "Column_Code";
            this.Column_Code.Width = 76;
            // 
            // Column_Sum
            // 
            this.Column_Sum.DataPropertyName = "Sum";
            this.Column_Sum.HeaderText = "סכום";
            this.Column_Sum.MinimumWidth = 80;
            this.Column_Sum.Name = "Column_Sum";
            this.Column_Sum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Sum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_Sum.Width = 80;
            // 
            // Column_Category
            // 
            this.Column_Category.DataPropertyName = "Category";
            this.Column_Category.HeaderText = "סיווג";
            this.Column_Category.MinimumWidth = 180;
            this.Column_Category.Name = "Column_Category";
            this.Column_Category.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_Category.Width = 180;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlSearch, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(663, 358);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.datesSearchPanel);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnClear);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(663, 28);
            this.pnlSearch.TabIndex = 2;
            // 
            // datesSearchPanel
            // 
            this.datesSearchPanel.DateFrom = new System.DateTime(2010, 1, 5, 23, 24, 29, 963);
            this.datesSearchPanel.DateTo = new System.DateTime(2010, 1, 5, 23, 24, 29, 966);
            this.datesSearchPanel.Location = new System.Drawing.Point(245, 3);
            this.datesSearchPanel.MaximumSize = new System.Drawing.Size(600, 25);
            this.datesSearchPanel.MinimumSize = new System.Drawing.Size(350, 25);
            this.datesSearchPanel.Name = "datesSearchPanel";
            this.datesSearchPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datesSearchPanel.Size = new System.Drawing.Size(415, 25);
            this.datesSearchPanel.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(194, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(45, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "חפש";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(143, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(45, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "נקה";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ctxMenuTransactions
            // 
            this.ctxMenuTransactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuItemNewTransaction,
            this.ctxMenuItemDuplicateTransaction,
            this.ctxMenuItemDeleteTransaction,
            this.ctxMenuItemRestoreDate,
            this.toolStripMenuItem1,
            this.ctxMenuItemSellectAll,
            this.ctxMenuItemSelectNone});
            this.ctxMenuTransactions.Name = "ctxMenuTransactions";
            this.ctxMenuTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxMenuTransactions.Size = new System.Drawing.Size(167, 142);
            this.ctxMenuTransactions.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuTransactions_Opening);
            // 
            // ctxMenuItemNewTransaction
            // 
            this.ctxMenuItemNewTransaction.Name = "ctxMenuItemNewTransaction";
            this.ctxMenuItemNewTransaction.Size = new System.Drawing.Size(166, 22);
            this.ctxMenuItemNewTransaction.Text = "תנועה חדשה";
            this.ctxMenuItemNewTransaction.Click += new System.EventHandler(this.ctxMenuItemNewTransaction_Click);
            // 
            // ctxMenuItemDuplicateTransaction
            // 
            this.ctxMenuItemDuplicateTransaction.Name = "ctxMenuItemDuplicateTransaction";
            this.ctxMenuItemDuplicateTransaction.Size = new System.Drawing.Size(166, 22);
            this.ctxMenuItemDuplicateTransaction.Text = "שכפל תנועה";
            this.ctxMenuItemDuplicateTransaction.Click += new System.EventHandler(this.ctxMenuItemDuplicateTransaction_Click);
            // 
            // ctxMenuItemDeleteTransaction
            // 
            this.ctxMenuItemDeleteTransaction.Name = "ctxMenuItemDeleteTransaction";
            this.ctxMenuItemDeleteTransaction.Size = new System.Drawing.Size(166, 22);
            this.ctxMenuItemDeleteTransaction.Text = "מחק תנועה";
            this.ctxMenuItemDeleteTransaction.Click += new System.EventHandler(this.ctxMenuItemDeleteTransaction_Click);
            // 
            // ctxMenuItemRestoreDate
            // 
            this.ctxMenuItemRestoreDate.Name = "ctxMenuItemRestoreDate";
            this.ctxMenuItemRestoreDate.Size = new System.Drawing.Size(166, 22);
            this.ctxMenuItemRestoreDate.Text = "שחזר תאריך מקורי";
            this.ctxMenuItemRestoreDate.Click += new System.EventHandler(this.ctxMenuItemRestoreDate_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // ctxMenuItemSellectAll
            // 
            this.ctxMenuItemSellectAll.Name = "ctxMenuItemSellectAll";
            this.ctxMenuItemSellectAll.Size = new System.Drawing.Size(166, 22);
            this.ctxMenuItemSellectAll.Text = "בחר הכל";
            this.ctxMenuItemSellectAll.Click += new System.EventHandler(this.ctxMenuItemSellectAll_Click);
            // 
            // ctxMenuItemSelectNone
            // 
            this.ctxMenuItemSelectNone.Name = "ctxMenuItemSelectNone";
            this.ctxMenuItemSelectNone.Size = new System.Drawing.Size(166, 22);
            this.ctxMenuItemSelectNone.Text = "נקה בחירה";
            this.ctxMenuItemSelectNone.Click += new System.EventHandler(this.ctxMenuItemSelectNone_Click);
            // 
            // ctxMenuCategories
            // 
            this.ctxMenuCategories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuCategoriesItemAdd,
            this.ctxMenuCategoriesItemEdit,
            this.ctxMenuCategoriesItemRemove});
            this.ctxMenuCategories.Name = "ctxMenuCategories";
            this.ctxMenuCategories.Size = new System.Drawing.Size(100, 70);
            // 
            // ctxMenuCategoriesItemAdd
            // 
            this.ctxMenuCategoriesItemAdd.Name = "ctxMenuCategoriesItemAdd";
            this.ctxMenuCategoriesItemAdd.Size = new System.Drawing.Size(99, 22);
            this.ctxMenuCategoriesItemAdd.Text = "הוסף";
            this.ctxMenuCategoriesItemAdd.Click += new System.EventHandler(this.ctxMenuCategoriesItemAdd_Click);
            // 
            // ctxMenuCategoriesItemEdit
            // 
            this.ctxMenuCategoriesItemEdit.Name = "ctxMenuCategoriesItemEdit";
            this.ctxMenuCategoriesItemEdit.Size = new System.Drawing.Size(99, 22);
            this.ctxMenuCategoriesItemEdit.Text = "ערוך";
            this.ctxMenuCategoriesItemEdit.Click += new System.EventHandler(this.ctxMenuCategoriesItemEdit_Click);
            // 
            // ctxMenuCategoriesItemRemove
            // 
            this.ctxMenuCategoriesItemRemove.Name = "ctxMenuCategoriesItemRemove";
            this.ctxMenuCategoriesItemRemove.Size = new System.Drawing.Size(99, 22);
            this.ctxMenuCategoriesItemRemove.Text = "מחק";
            this.ctxMenuCategoriesItemRemove.Click += new System.EventHandler(this.ctxMenuCategoriesItemRemove_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "InternalID";
            this.dataGridViewTextBoxColumn1.HeaderText = "InternalID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn2.HeaderText = "תאריך מקורי";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DateForCalculation";
            this.dataGridViewTextBoxColumn3.HeaderText = "תאריך";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn4.HeaderText = "תיאור";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn5.HeaderText = "אסמכתא";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Sum";
            this.dataGridViewTextBoxColumn6.HeaderText = "סכום";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn7.HeaderText = "סיווג";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // TransactionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TransactionsPanel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(663, 358);
            this.Load += new System.EventHandler(this.TransactionsPanel_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.ctxMenuTransactions.ResumeLayout(false);
            this.ctxMenuCategories.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DatesSearchPanel datesSearchPanel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel pnlSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TreeView treeCategories;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTransactions;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemNewTransaction;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemDeleteTransaction;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemRestoreDate;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemDuplicateTransaction;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemSellectAll;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemSelectNone;
        private System.Windows.Forms.ContextMenuStrip ctxMenuCategories;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuCategoriesItemAdd;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuCategoriesItemEdit;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuCategoriesItemRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InternalID;
        private DataGridViewDateColumn Column_OriginalDate;
        private DataGridViewDateColumn Column_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Code;
        private DataGridViewNumberColumn Column_Sum;
        private DataGridViewCategoryColumn Column_Category;
    }
}
