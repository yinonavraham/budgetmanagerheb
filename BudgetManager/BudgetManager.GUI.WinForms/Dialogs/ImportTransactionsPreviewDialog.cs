using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetManager.Data;
using BudgetManager.GUI.WinForms.Data;
using BudgetManager.BusinessLayar;
using BudgetManager.Adapters;
using System.Reflection;
using System.IO;

namespace BudgetManager.GUI.WinForms.Dialogs
{
    public partial class ImportTransactionsPreviewDialog : Form
    {
        private List<CategorizedTransaction> _categorizedTransactions = new List<CategorizedTransaction>();
        private ImportTransactionsSource _source = null;
        private String _filepath = null;
        private Color _transactionNotValidColor = Color.Pink;
        private Color _categorySuggestedColor = Color.LightYellow;


        public ImportTransactionsPreviewDialog(ImportTransactionsSource source, String filepath)
        {
            InitializeComponent();
            this.dgvTransactions.AutoGenerateColumns = false;
            this.btnOK.Enabled = false;

            this._source = source;
            this._filepath = filepath;
        }


        public List<CategorizedTransaction> Transactions
        {
            get { return this._categorizedTransactions; }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveSelectedRows();
        }


        private void bgwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            ITransactionsImportAdapter adapter = null;
            AppDomain app = null;
            try
            {
                AppDomainSetup setup = new AppDomainSetup();
                setup.ApplicationBase = Path.GetDirectoryName(this._source.SourceDllFilepath);
                app = AppDomain.CreateDomain("ImportTransactionsPlugin", null, setup);
                //Assembly assembly = Assembly.LoadFile(this._source.SourceDllFilepath);

                adapter = (ITransactionsImportAdapter)app.CreateInstanceAndUnwrap(
                    this._source.AssemblyFullName, this._source.TypeName);
                List<TransactionRow> transactions = adapter.ImportTransactions(this._filepath);
                foreach (TransactionRow t in transactions)
                {
                    this._categorizedTransactions.Add(new CategorizedTransaction(t));
                }
            }
            //catch (Exception)
            //{
            //    throw;
            //}
            finally
            {
                if (app != null) AppDomain.Unload(app);
                app = null;
            }
        }


        private void bgwImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    this.dgvTransactions.DataSource = this._categorizedTransactions;
                }
                else
                {
                    MessageBox.Show(e.Error.Message, "שגיאה");
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }


        private void ImportTransactionsPreviewDialog_Shown(object sender, EventArgs e)
        {
            this.bgwImport.RunWorkerAsync();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.bgwImport.CancelAsync();
        }


        private bool TransactionsValidated()
        {
            bool result = true;
            foreach (DataGridViewRow row in this.dgvTransactions.Rows)
            {
                result = RowValidated(row) ? result : false;
            }
            return result;
        }


        private void PaintRow(DataGridViewRow row, Color color)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = color;
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (TransactionsValidated())
            {
                this.DialogResult = DialogResult.OK;
            }            
        }


        private void ImportTransactionsPreviewDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        private void RemoveSelectedRows()
        {
            foreach (DataGridViewRow row in this.dgvTransactions.SelectedRows)
            {
                this._categorizedTransactions.RemoveAt(row.Index);
            }
            this.dgvTransactions.DataSource = null;
            this.dgvTransactions.DataSource = this._categorizedTransactions;
        }


        private void UpdateDateForSelectedRows(DateTime date)
        {
            foreach (DataGridViewRow row in this.dgvTransactions.SelectedRows)
            {
                CategorizedTransaction t = row.DataBoundItem as CategorizedTransaction;
                if (t != null)
                {
                    t.DateForCalculation = date;
                }
            }
            this.dgvTransactions.Refresh();
        }


        private void UpdateCategoryForSelectedRows(Category category)
        {
            foreach (DataGridViewRow row in this.dgvTransactions.SelectedRows)
            {
                CategorizedTransaction t = row.DataBoundItem as CategorizedTransaction;
                if (t != null)
                {
                    t.Category = category;
                }
            }
            this.dgvTransactions.Refresh();
        }


        public Color TransactionNotValidColor
        {
            get { return this._transactionNotValidColor; }
            set { this._transactionNotValidColor = value; }
        }


        public Color CategorySuggestedColor
        {
            get { return this._categorySuggestedColor; }
            set { this._categorySuggestedColor = value; }
        }


        private void dgvTransactions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.dgvTransactions.RowCount > 0 &&
                !RowValidated(this.dgvTransactions.Rows[e.RowIndex]))
            {
            }
        }


        private bool RowValidated(DataGridViewRow row)
        {
            if (row == null) return true;
            CategorizedTransaction t = row.DataBoundItem as CategorizedTransaction;
            bool result = true;
            if (t != null)
            {
                Color c = this.dgvTransactions.DefaultCellStyle.BackColor;
                if (!t.IsValid())
                {
                    c = this.TransactionNotValidColor;
                    result = false;
                }
                PaintRow(row, c);
            }
            return result;
        }


        private void ctxMenuItemModifyDate_Click(object sender, EventArgs e)
        {
            DatePickerPopup popup = new DatePickerPopup();
            DialogResult result = popup.ShowDialog();
            if (result.Equals(DialogResult.OK)) UpdateDateForSelectedRows(popup.SelectedDate);
        }


        private void ctxMenuItemChooseCategory_Click(object sender, EventArgs e)
        {
            CategoryPickerPopup popup = new CategoryPickerPopup();
            DialogResult result = popup.ShowDialog();
            if (result.Equals(DialogResult.OK)) UpdateCategoryForSelectedRows(popup.SelectedCategory);
        }


        private void ctxMenuItemRemove_Click(object sender, EventArgs e)
        {
            RemoveSelectedRows();
        }


        private void dgvTransactions_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            UpdateContextMenu();
        }


        private void UpdateContextMenu()
        {
            bool enabled = this.dgvTransactions.SelectedRows != null && this.dgvTransactions.SelectedRows.Count > 0;
            this.ctxMenuItemChooseCategory.Enabled = enabled;
            this.ctxMenuItemModifyDate.Enabled = enabled;
            this.ctxMenuItemRemove.Enabled = enabled;
        }


        private void dgvTransactions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetCategoriesSuggestions();
            this.btnOK.Enabled = true;
        }


        private void SetCategoriesSuggestions()
        {
            foreach (DataGridViewRow row in this.dgvTransactions.Rows)
            {
                CategorizedTransaction ct = row.DataBoundItem as CategorizedTransaction;
                if (ct != null)
                {
                    Category category = CategorySuggestionManager.Instance.GetSuggestedCategory(ct);
                    if (category != null)
                    {
                        ct.Category = category;
                        PaintRow(row, this._categorySuggestedColor);
                    }
                }
            }
        }


        private void AcceptCategorySuggestionsForSelectedRows()
        {
            foreach (DataGridViewRow row in this.dgvTransactions.SelectedRows)
            {
                PaintRow(row, this.dgvTransactions.DefaultCellStyle.BackColor);
            }
        }


        private void ctxMenuItemAcceptCategorySuggestion_Click(object sender, EventArgs e)
        {
            AcceptCategorySuggestionsForSelectedRows();
        }
    }
}
