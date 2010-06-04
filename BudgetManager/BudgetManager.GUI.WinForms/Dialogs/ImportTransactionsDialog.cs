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
using System.Reflection;

namespace BudgetManager.GUI.WinForms.Dialogs
{
    public partial class ImportTransactionsDialog : Form
    {
        public event EventHandler IsSourceSelectedChanged = null;

        private List<CategorizedTransaction> _importedTransactions = new List<CategorizedTransaction>();
        //private List<ImportTransactionsSource> _sources = new List<ImportTransactionsSource>();
        private ImportTransactionsSourceList _sources = new ImportTransactionsSourceList();

        public ImportTransactionsDialog()
        {
            InitializeComponent();

            //InitSources();
            _sources.Load(Properties.Settings.Default.ImportTransactionsSourcesFilepath);

            this.listBoxSources.DataSource = this._sources.Sources;

            InitializeControlsPropertyBindings();
        }

        private void InitSources()
        {
            ImportTransactionsSource source = null;
            Assembly assembly = null;
            _sources.Clear();

            source = new ImportTransactionsSource();
            source.Name = "בנק הפועלים - גליון אקסל";
            source.Description =
                "ייבוא תנועות מגליון אקסל שנוצר באתר האינטרנט של בנק הפועלים (תנועות בעו\"ש).\r\n" +
                "בחר את קובץ האקסל ממנו יש לבצע את הייבוא.\r\n" +
                "* נא לשים לב - התאריכים בקובץ האקסל לא כוללים שנה - יש לוודא את השנה המשוייכת.";
            source.SourceDllFilepath = @"C:\Users\Yinon Avraham\Documents\Visual Studio 2008\Projects\BudgetManager\BudgetManager.Adapters.BankHapoalim\bin\Debug\BudgetManager.Adapters.BankHapoalim.dll";
            source.TypeName = "BudgetManager.Adapters.BankHapoalim.BankHapoalimAdapter";
            assembly = Assembly.LoadFile(source.SourceDllFilepath);
            source.AssemblyFullName = assembly.FullName;
            _sources.Add(source);

            source = new ImportTransactionsSource();
            source.Name = "ישראכרט - גליון אקסל";
            source.Description =
                "ייבוא תנועות מגליון אקסל שנוצר באתר האינטרנט של ישראכרט - עסקאות בכרטיס האשראי.\r\n" +
                "בחר את קובץ האקסל ממנו יש לבצע את הייבוא..\r\n" +
                "* נא לשים לב - התאריכים בקובץ האקסל לא כוללים שנה - יש לוודא את השנה המשוייכת.";
            source.SourceDllFilepath = @"C:\Users\Yinon Avraham\Documents\Visual Studio 2008\Projects\BudgetManager\BudgetManager.Adapters.Isracard\bin\Debug\BudgetManager.Adapters.Isracard.dll";
            source.TypeName = "BudgetManager.Adapters.Isracard.IsracardExcelAdapter";
            assembly = Assembly.LoadFile(source.SourceDllFilepath);
            source.AssemblyFullName = assembly.FullName;
            _sources.Add(source);

            source = new ImportTransactionsSource();
            source.Name = "לאומיקארד - גליון אקסל";
            source.Description =
                "ייבוא תנועות מגליון אקסל שנוצר באתר האינטרנט של לאומיקארד - עסקאות בכרטיס האשראי.\r\n" +
                "בחר את קובץ האקסל ממנו יש לבצע את הייבוא.";
            source.SourceDllFilepath = @"C:\Users\Yinon Avraham\Documents\Visual Studio 2008\Projects\BudgetManager\BudgetManager.Adapters.LeumiCard\bin\Debug\BudgetManager.Adapters.LeumiCard.dll";
            source.TypeName = "BudgetManager.Adapters.LeumiCard.LeumiCardExcelAdapter";
            assembly = Assembly.LoadFile(source.SourceDllFilepath);
            source.AssemblyFullName = assembly.FullName;
            _sources.Add(source);
            _sources.Save(Properties.Settings.Default.ImportTransactionsSourcesFilepath);
        }


        public List<CategorizedTransaction> ImportedTransactions
        {
            get { return this._importedTransactions; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            StartImport();
        }


        private void StartImport()
        {
            ImportTransactionsPreviewDialog previewDialog = 
                new ImportTransactionsPreviewDialog(this.SelectedSource, this.fldFilepath.Text);
            this.DialogResult = previewDialog.ShowDialog();
            if (this.DialogResult.Equals(DialogResult.OK))
            {
                this._importedTransactions = previewDialog.Transactions;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void listBoxSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnIsSourceSelectedChanged(new EventArgs());
            ImportTransactionsSource source = this.listBoxSources.SelectedItem as ImportTransactionsSource;
            this.fldSourceDescription.Text = source == null ? "" : source.Description;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                this.fldFilepath.Text = this.openFileDialog.FileName;
            }
        }


        [Bindable(true)]
        public bool IsSourceSelected
        {
            get 
            {
                return this.SelectedSource != null;
            }
            set { }
        }


        private ImportTransactionsSource SelectedSource
        {
            get { return this.listBoxSources.SelectedItem as ImportTransactionsSource; }
        }


        protected void OnIsSourceSelectedChanged(EventArgs e)
        {
            if (IsSourceSelectedChanged != null) IsSourceSelectedChanged(this, e);
        }


        private void InitializeControlsPropertyBindings()
        {
            this.btnOK.DataBindings.Add("Enabled", this, "IsSourceSelected", false, DataSourceUpdateMode.OnPropertyChanged);
            this.groupBoxSourceDetails.DataBindings.Add("Enabled", this, "IsSourceSelected", false, DataSourceUpdateMode.OnPropertyChanged);
            this.btnEdit.DataBindings.Add("Enabled", this, "IsSourceSelected", false, DataSourceUpdateMode.OnPropertyChanged);
            this.btnRemove.DataBindings.Add("Enabled", this, "IsSourceSelected", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
