using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetManager.Data;
using BudgetManager.BusinessLayar;
using System.Reflection;
using System.Collections;

namespace BudgetManager.GUI.WinForms.Controls
{
    public partial class TransactionsPanel : UserControl, ITabPageSelectionChangeHandler
    {
        private CategorizedTransaction _newTransaction = null;
        private Category _newCategoryParent = null;


        public TransactionsPanel()
        {
            InitializeComponent();
            LoadSettings();

            this.dgvTransactions.AutoGenerateColumns = false;
            TransactionsManager.Instance.TransactionAdded += new TransactionEventHandler(TransactionsManager_TransactionAdded);
            TransactionsManager.Instance.TransactionDuplicated += new TransactionEventHandler(TransactionsManager_TransactionDuplicated);
            TransactionsManager.Instance.TransactionRemoved += new TransactionEventHandler(TransactionsManager_TransactionRemoved);
            TransactionsManager.Instance.TransactionsLoaded += new EventHandler(TransactionsManager_TransactionsLoaded);
            CategoriesManager.Instance.CategoriesLoaded += new EventHandler(CategoriesManager_CategoriesLoaded);
            CategoriesManager.Instance.CategoriesReset += new EventHandler(CategoriesManager_CategoriesLoaded);
        }


        private void LoadSettings()
        {
            this.splitContainer.SplitterDistance = Properties.Settings.Default.MainFormSplitterDistance;
            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Settings_PropertyChanged);
        }


        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("MainFormSplitterDistance"))
                this.splitContainer.SplitterDistance = Properties.Settings.Default.MainFormSplitterDistance;
        }


        private void TransactionsManager_TransactionsLoaded(object sender, EventArgs e)
        {
            PerformSearch();
        }


        private void CategoriesManager_CategoriesLoaded(object sender, EventArgs e)
        {
            this.TransactionsPanel_Load(null, null);
        }


        private void TransactionsManager_TransactionRemoved(object sender, TransactionEventArgs e)
        {
            //PerformSearch();
        }


        private void TransactionsManager_TransactionDuplicated(object sender, TransactionEventArgs e)
        {
            //PerformSearch();
        }


        private void TransactionsManager_TransactionAdded(object sender, TransactionEventArgs e)
        {
            PerformSearch();
        }


        #region Events handlers


        private void TransactionsPanel_Load(object sender, EventArgs e)
        {
            //CategoriesManager.Instance.Load();
            //TransactionsManager.Instance.Load();
            
            Category root = CategoriesManager.Instance.RootCategory;
            if (root != null) Utilities.CommonMethods.FillCategoriesTree(ref this.treeCategories, root);

            SetDefaultSearchValues();
            PerformSearch();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }


        private TransactionSearchDefinition GetSearchDefinition()
        {
            TransactionSearchDefinition sd = new TransactionSearchDefinition();
            sd.FromDate = this.datesSearchPanel.DateFrom == DateTime.MinValue ?
                            (DateTime?)null : this.datesSearchPanel.DateFrom;
            sd.ToDate = this.datesSearchPanel.DateTo == DateTime.MaxValue ?
                            (DateTime?)null : this.datesSearchPanel.DateTo;
            if (this.treeCategories.SelectedNode != null)
            {
                Category cat = this.treeCategories.SelectedNode.Tag as Category;
                if (cat != null) sd.Categories = new List<Category>(new Category[] { cat });
            }
            return sd;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            SetDefaultSearchValues();
            PerformSearch();
        }


        private void treeCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        #endregion


        private void SetDefaultSearchValues()
        {
            this.datesSearchPanel.DateFrom = DateTime.Today.AddMonths(-1);
            this.datesSearchPanel.DateTo = DateTime.Today;
            this.treeCategories.SelectedNode = this.treeCategories.Nodes[0];
        }


        private void PerformSearch()
        {
            TransactionSearchDefinition searchDef = GetSearchDefinition();
            IEnumerable<CategorizedTransaction> transactions = TransactionsManager.Instance.GetTransactions(searchDef);
            this.dgvTransactions.DataSource = null;
            this.dgvTransactions.DataSource = transactions == null ? null : transactions.ToList<CategorizedTransaction>();
            //UpdateColumnsWidth();

            DeselectAllTransactionTableCells();
        }


        private void UpdateColumnsWidth()
        {
            this.dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            int totalColWidth = 0;
            int[] colWidths = new int[this.dgvTransactions.Columns.Count];
            for (int i = 0; i < this.dgvTransactions.Columns.Count; i++)
            {
                DataGridViewColumn col = this.dgvTransactions.Columns[i];
                if (col.Visible)
                {
                    totalColWidth += col.Width;
                    colWidths[i] = col.Width;
                }
            }
            if (totalColWidth + this.dgvTransactions.RowHeadersWidth < this.dgvTransactions.Width)
            {
                this.dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                int newTotalColWidth = 0;
                int totalWidth = this.dgvTransactions.Width - this.dgvTransactions.RowHeadersWidth;
                for (int i = 0; i < this.dgvTransactions.Columns.Count; i++)
                {
                    DataGridViewColumn col = this.dgvTransactions.Columns[i];
                    if (col.Visible)
                    {
                        float ratio = (float)colWidths[i] / (float)totalColWidth;
                        int newWidth = (int)(ratio * totalWidth);
                        newTotalColWidth += newWidth;
                        col.Width = newWidth;
                    }
                }
                if (newTotalColWidth + this.dgvTransactions.RowHeadersWidth + 2 > this.dgvTransactions.Width)
                {
                    int lastColIndex = this.dgvTransactions.Columns.Count-1;
                    int delta = newTotalColWidth + this.dgvTransactions.RowHeadersWidth + 2 - this.dgvTransactions.Width;
                    this.dgvTransactions.Columns[lastColIndex].Width -= delta;
                }
            }
        }

        private void dgvTransactions_Resize(object sender, EventArgs e)
        {
            //UpdateColumnsWidth();
        }


        private void ctxMenuItemNewTransaction_Click(object sender, EventArgs e)
        {
            StartEditNewTransaction();
        }


        private void ctxMenuItemDuplicateTransaction_Click(object sender, EventArgs e)
        {
            DuplicateSelectedTransaction();
        }


        private void ctxMenuItemDeleteTransaction_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows();
        }


        private void ctxMenuItemRestoreDate_Click(object sender, EventArgs e)
        {
            RestoreDateForSelectedRows();
        }


        private void ctxMenuTransactions_Opening(object sender, CancelEventArgs e)
        {
            UpdateTransactionsContextMenu();
        }


        private void UpdateTransactionsContextMenu()
        {
            this.ctxMenuItemNewTransaction.Enabled = this.dgvTransactions.SelectedRows.Count > 1 ? false : true;
            this.ctxMenuItemDuplicateTransaction.Enabled = this.dgvTransactions.SelectedRows.Count > 1 ? false : true;
            this.ctxMenuItemDeleteTransaction.Enabled = true;
            this.ctxMenuItemRestoreDate.Enabled = true;
        }


        private void dgvTransactions_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && this._newTransaction == null)
            {
                e.ContextMenuStrip = this.ctxMenuTransactions;
                if (this.dgvTransactions.SelectedRows == null || this.dgvTransactions.SelectedRows.Count == 0)
                {
                    DeselectAllTransactionTableCells();
                    this.dgvTransactions.Rows[e.RowIndex].Selected = true;
                }
                else if (!this.dgvTransactions.Rows[e.RowIndex].Selected)
                {
                    DeselectAllTransactionTableCells();
                    this.dgvTransactions.Rows[e.RowIndex].Selected = true;
                }
            }
        }


        private void DeselectAllTransactionTableCells()
        {
            foreach (DataGridViewRow row in this.dgvTransactions.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Selected = false;
                }
            }
        }


        private void StartEditNewTransaction()
        {
            CategorizedTransaction transaction = TransactionsManager.Instance.NewTransaction();
            transaction.DateForCalculation = DateTime.Today;
            List<CategorizedTransaction> list = dgvTransactions.DataSource as List<CategorizedTransaction>;
            list.Add(transaction);
            this.dgvTransactions.DataSource = null;
            this.dgvTransactions.DataSource = list;
            EnterNewTransactionEditMode(transaction, -1);
            this._newTransaction = transaction;
        }


        private void EnterNewTransactionEditMode(CategorizedTransaction transaction, int colIndex)
        {
            DeselectAllTransactionTableCells();
            bool stop = false;
            foreach (DataGridViewRow row in this.dgvTransactions.Rows)
            {
                if (((CategorizedTransaction)row.DataBoundItem).InternalID.Equals(transaction.InternalID))
                {
                    if (colIndex >= 0)
                    {
                        this.dgvTransactions.CurrentCell = row.Cells[colIndex];
                        break;
                    }
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            this.dgvTransactions.CurrentCell = cell;
                            stop = true;
                            break;
                        }
                    }
                }
                if (stop) break;
            }
            this.dgvTransactions.BeginEdit(true);
        }


        private void RestoreDateForSelectedRows()
        {
            DataGridViewSelectedRowCollection selectedRows = this.dgvTransactions.SelectedRows;
            if (selectedRows.Count > 0)
            {
                List<long> internalIds = new List<long>();
                foreach (DataGridViewRow row in selectedRows)
                {
                    internalIds.Add(((CategorizedTransaction)row.DataBoundItem).InternalID);
                    TransactionsManager.Instance.RestoreTransactionOriginalDate((CategorizedTransaction)row.DataBoundItem);
                }
                PerformSearch();
                ReselectTransactionsRows(internalIds);
            }
        }


        private void DeleteSelectedRows()
        {
            foreach (DataGridViewRow row in this.dgvTransactions.SelectedRows)
            {
                TransactionsManager.Instance.RemoveTransaction((CategorizedTransaction)row.DataBoundItem);
            }
            PerformSearch();
            DeselectAllTransactionTableCells();
        }


        private void DuplicateSelectedTransaction()
        {
            CategorizedTransaction transaction = this.dgvTransactions.SelectedRows[0].DataBoundItem
                as CategorizedTransaction;
            if (transaction != null) 
            {
                CategorizedTransaction newTransaction = null;
                newTransaction = TransactionsManager.Instance.DuplicateTransaction(transaction);
                PerformSearch();
                if (newTransaction != null)
                {
                    ReselectTransactionsRows(new List<long>() { newTransaction.InternalID });
                }
            }
        }


        private void ReselectTransactionsRows(List<long> internalIds)
        {
            foreach (DataGridViewRow row in this.dgvTransactions.Rows)
            {
                if (internalIds.Contains(((CategorizedTransaction)row.DataBoundItem).InternalID)) row.Selected = true;
                else row.Selected = false;
            }
        }


        private void dgvTransactions_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void dgvTransactions_CancelRowEdit(object sender, QuestionEventArgs e)
        {

        }


        private void dgvTransactions_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatusMessage();
        }


        private void dgvTransactions_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void dgvTransactions_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (this._newTransaction != null)
            {
                try
                {
                    this._newTransaction.Date = this._newTransaction.DateForCalculation;
                    TransactionsManager.Instance.AddTransaction(this._newTransaction);
                    this._newTransaction = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    EnterNewTransactionEditMode(this._newTransaction, e.ColumnIndex);
                    e.Cancel = true;
                }
            }
        }


        private void dgvTransactions_KeyDown(object sender, KeyEventArgs e)
        {
            if (this._newTransaction != null)
            {
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    CancelNewTransaction();
                }
            }
        }


        private void CancelNewTransaction()
        {
            this._newTransaction = null;
            PerformSearch();
        }


        private void ctxMenuItemSellectAll_Click(object sender, EventArgs e)
        {
            SelectAllRows();
        }


        private void SelectAllRows()
        {
            foreach (DataGridViewRow row in this.dgvTransactions.Rows)
            {
                row.Selected = true;
            }
        }


        private void ctxMenuItemSelectNone_Click(object sender, EventArgs e)
        {
            DeselectAllTransactionTableCells();
        }


        private void SetStatusMessage(String message)
        {
            Form form = this.ParentForm;
            if (form == null) return;
            MethodInfo method = form.GetType().GetMethod("SetStatusMessage");
            if (method != null)
            {
                if (method.GetParameters().Count() == 1 &&
                    method.GetParameters()[0].ParameterType.Equals(typeof(String)))
                {
                    method.Invoke(form, new Object[] { message });
                }
            }
        }


        private double GetTotalSum()
        {
            double sum = 0;
            if (this.dgvTransactions.SelectedRows != null && this.dgvTransactions.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.dgvTransactions.SelectedRows)
                {
                    double? tmp = ((CategorizedTransaction)row.DataBoundItem).Sum;
                    sum += tmp == null ? 0 : (double)tmp;
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.dgvTransactions.Rows)
                {
                    double? tmp = ((CategorizedTransaction)row.DataBoundItem).Sum;
                    sum += tmp == null ? 0 : (double)tmp;
                }
            }
            return sum;
        }


        public void UpdateStatusMessage()
        {
            double totalSum = GetTotalSum();
            String sign = totalSum < 0 ? "-" : "";
            totalSum = Math.Abs(totalSum);
            int rowsCount = this.dgvTransactions.RowCount;
            int selectedCount = this.dgvTransactions.SelectedRows.Count;
            String message = String.Format("מוצגות {0} תנועות, נבחרו {1}. סכום: {2}{3}", 
                rowsCount, selectedCount, totalSum, sign);
            SetStatusMessage(message);
        }


        private void dgvTransactions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateStatusMessage();
        }


        private void ctxMenuCategoriesItemAdd_Click(object sender, EventArgs e)
        {
            Category category = this.treeCategories.SelectedNode.Tag as Category;
            if (!CategoriesManager.Instance.IsCategoryCanHaveNewSubCategories(category)) return;
            this._newCategoryParent = category;
            TreeNode newNode = this.treeCategories.SelectedNode.Nodes.Add("");
            this.treeCategories.SelectedNode = newNode;
            this.treeCategories.LabelEdit = true;
            this.treeCategories.SelectedNode.BeginEdit();
        }


        private void ctxMenuCategoriesItemEdit_Click(object sender, EventArgs e)
        {
            this.treeCategories.LabelEdit = true;
            this.treeCategories.SelectedNode.BeginEdit();
        }


        private void ctxMenuCategoriesItemRemove_Click(object sender, EventArgs e)
        {
            Category category = this.treeCategories.SelectedNode.Tag as Category;
            if (category != null && CategoriesManager.Instance.RemoveCategory(category))
            {
                this.treeCategories.Nodes.Remove(this.treeCategories.SelectedNode);
            }
        }


        private void treeCategories_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                this.treeCategories.SelectedNode = e.Node;
                UpdateCategoriesContextMenu(e.Node);
                this.ctxMenuCategories.Show(this.treeCategories,e.Location);
            }
        }


        private void UpdateCategoriesContextMenu(TreeNode node)
        {
            Category category = node.Tag as Category;
            if (category == null)
            {
                this.ctxMenuCategoriesItemAdd.Enabled = false;
                this.ctxMenuCategoriesItemEdit.Enabled = false;
                this.ctxMenuCategoriesItemRemove.Enabled = false;
            }
            else
            {
                this.ctxMenuCategoriesItemAdd.Enabled =
                    //(category.Level < Category.MaxLevel) &&
                    CategoriesManager.Instance.IsCategoryCanHaveNewSubCategories(category);
                this.ctxMenuCategoriesItemEdit.Enabled = true;
                this.ctxMenuCategoriesItemRemove.Enabled =
                    CategoriesManager.Instance.IsCategoryCanBeRemoved(category);
            }
        }


        private void treeCategories_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            this.treeCategories.LabelEdit = false;
            if (this._newCategoryParent != null)
            {
                try
                {
                    // Add the new category
                    if (e.Label != null)
                    {
                        Category cat = this._newCategoryParent.AddSubCategory(null, e.Label);
                        e.Node.Tag = cat;
                    }
                    // Remove the node from the tree
                    else
                    {
                        this.treeCategories.Nodes.Remove(e.Node);
                    }
                }
                finally
                {
                    this._newCategoryParent = null;
                }
            }
            // Just edit an existing node
            else if (e.Label != null)
            {
                ((Category)e.Node.Tag).Name = e.Label;
            }
        }


        #region ITabPageSelectionChangeHandler Members


        public void TabPageSelected()
        {
            UpdateStatusMessage();
        }


        public void TabPageDeselected() { }


        #endregion

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Properties.Settings.Default.MainFormSplitterDistance = this.splitContainer.SplitterDistance;
        }
    }
}
