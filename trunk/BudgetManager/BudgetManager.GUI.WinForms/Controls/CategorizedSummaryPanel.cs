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
using BudgetManager.GUI.WinForms.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace BudgetManager.GUI.WinForms.Controls
{
    public partial class CategorizedSummaryPanel : UserControl, ITabPageSelectionChangeHandler
    {
        private IDictionary<Category, YearSummaryByCategoryRow> _summaryRows = 
            new Dictionary<Category, YearSummaryByCategoryRow>();


        public CategorizedSummaryPanel()
        {
            InitializeComponent();
            this.dgvSummary.AutoGenerateColumns = false;
            LoadSettings();

            CategoriesManager.Instance.CategoriesLoaded += new EventHandler(CategoriesManager_CategoriesLoaded);
            CategoriesManager.Instance.CategoriesReset += new EventHandler(CategoriesManager_CategoriesLoaded);
            TransactionsManager.Instance.TransactionsLoaded += new EventHandler(TransactionsManager_TransactionsLoaded);
            TransactionsManager.Instance.TransactionsUpdated += new EventHandler(TransactionsManager_TransactionsUpdated);
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


        void TransactionsManager_TransactionsLoaded(object sender, EventArgs e)
        {
            //UpdateTableData();
        }


        void TransactionsManager_TransactionsUpdated(object sender, EventArgs e)
        {
            RefreshSummaryData();
        }


        private void RefreshSummaryData()
        {
            FillAvailableYears();
            UpdateTableData();
        }


        private void CategoriesManager_CategoriesLoaded(object sender, EventArgs e)
        {
            Category expensesCategory = CategoriesManager.Instance.ExpensesCategory;
            Category incomeCategory = CategoriesManager.Instance.IncomeCategory;
            this.treeCategories.Nodes.Clear();
            if (expensesCategory != null) Utilities.CommonMethods.AddCategoriesTreeFirstLevel(ref this.treeCategories, expensesCategory);
            if (incomeCategory != null) Utilities.CommonMethods.AddCategoriesTreeFirstLevel(ref this.treeCategories, incomeCategory);
        }


        private void UpdateTableData()
        {
            // 1. Get all the relevant summary data
            CollectSummaryData();
            //this._summaryRows.Clear();
            //this._summaryRows.Add(new YearSummaryByCategoryRow("שורה1", new double?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }));
            //this._summaryRows.Add(new YearSummaryByCategoryRow("שורה2", new double?[] { 21, 22, 23, 24, 25, 26, 27, 28, 29, 210, 211, 212 }));
            //this._summaryRows.Add(new YearSummaryByCategoryRow("שורה3", new double?[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
            //this._summaryRows.Add(new YearSummaryByCategoryRow("שורה4", new double?[] { 1, null, 1, null, 1, null, 1, null, 1, null, 1, null }));
            // 2. Add the total summary row
            List<YearSummaryByCategoryRow> summaryRowsList = this._summaryRows.Values.ToList<YearSummaryByCategoryRow>();
            summaryRowsList.Add(GetTotalSummaryRow());
            // 3. Set the DataSource for the table
            this.dgvSummary.DataSource = summaryRowsList;
            // 4. Apply the table style
            ApplyTableStyle();
            UpdateChart();
        }


        private void UpdateChart()
        {
            this.chartSummary.Series.Clear();
            Category category = this.treeCategories.SelectedNode == null ? 
                null : this.treeCategories.SelectedNode.Tag as Category;
            if (category == null) return;
            List<YearSummaryByCategoryRow> summaryRowsList = this._summaryRows.Values.ToList<YearSummaryByCategoryRow>();
            this.chartSummary.AntiAliasing = AntiAliasingStyles.All;
            this.chartSummary.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            this.chartSummary.Titles.Clear();
            this.chartSummary.Titles.Add(category.Name);
            this.chartSummary.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
            this.chartSummary.RightToLeft = RightToLeft.No;
            this.chartSummary.ChartAreas[0].Area3DStyle.Enable3D = false;
            this.chartSummary.ChartAreas[0].AxisX.Interval = 1;
            foreach (YearSummaryByCategoryRow row in summaryRowsList)
            {
                this.chartSummary.Series.Add(row.Category);
                for (int month = 0; month < row.NumberOfMonths; month++)
                {
                    double value = row[month] == null ? 0 : (double)row[month];
                    //this.chartSummary.Series[row.Category].Points.AddY(value);
                    this.chartSummary.Series[row.Category].Points.AddXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month + 1), value);
                }
                this.chartSummary.Series[row.Category].ChartType = SeriesChartType.StackedColumn;
                this.chartSummary.Series[row.Category].IsValueShownAsLabel = false;
                this.chartSummary.Series[row.Category].IsVisibleInLegend = true;
            }
        }


        private void CollectSummaryData()
        {
            this._summaryRows.Clear();
            if (this.treeCategories.SelectedNode == null ||
                this.fldYear.SelectedItem == null) return;
            int year = (int)this.fldYear.SelectedItem;
            Category category = this.treeCategories.SelectedNode.Tag as Category;
            DateTime startDate;
            DateTime endDate;
            for (int month = 0; month < 12; month++)
            {
                startDate = new DateTime(year, month + 1, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
                TransactionsSummaryByCategoryResult result =
                    TransactionsManager.Instance.GetSummary(startDate, endDate, category);
                AddMonthSummaryToCollection(result, month);
            }
        }


        private void AddMonthSummaryToCollection(TransactionsSummaryByCategoryResult result, int month)
        {
            foreach (Category category in result.SummaryByCategory.Keys)
            {
                if (!this._summaryRows.ContainsKey(category))
                {
                    this._summaryRows.Add(category, new YearSummaryByCategoryRow());
                    this._summaryRows[category].Category = category.Name;
                }
                YearSummaryByCategoryRow row = this._summaryRows[category];
                row[month] = Math.Abs(result.SummaryByCategory[category]);
            }
        }


        private void dgvSummary_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvSummary.CurrentCell = null;
        }


        private YearSummaryByCategoryRow GetTotalSummaryRow()
        {
            YearSummaryByCategoryRow summaryRow = new YearSummaryByCategoryRow();
            summaryRow.Category = "סה\"כ";
            for (int i = 0; i < summaryRow.NumberOfMonths; i++)
            {
                summaryRow[i] = 0;
                foreach (YearSummaryByCategoryRow row in this._summaryRows.Values)
                {
                    summaryRow[i] += row[i] != null ? row[i].Value : 0;
                }
            }
            return summaryRow;
        }


        private void ApplyTableStyle()
        {
        }


        #region ITabPageSelectionChangeHandler Members


        public void TabPageSelected()
        {
            RefreshSummaryData();
        }


        public void TabPageDeselected() { }


        #endregion

        private void treeCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateTableData();
        }

        private void chartSummary_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    DataPoint data = e.HitTestResult.Object as DataPoint;
                    String value = data == null ? "" : data.YValues[0].ToString();
                    e.Text = String.Format("{0} ({1}) : {2}", e.HitTestResult.Series.Name, data.AxisLabel, value);
                    break;
            }
        }


        private void fldYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTableData();
        }


        private void FillAvailableYears()
        {
            this.fldYear.DataSource = TransactionsManager.Instance.GetAvailableYears();
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Properties.Settings.Default.MainFormSplitterDistance = this.splitContainer.SplitterDistance;
        }
    }
}
