using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetManager.BusinessLayar;
using BudgetManager.Data;
using BudgetManager.GUI.WinForms.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace BudgetManager.GUI.WinForms.Controls
{
    public partial class IncomeExpensesPanel : UserControl, ITabPageSelectionChangeHandler
    {
        private double[] _income = null;
        private double[] _expenses = null;

        public IncomeExpensesPanel()
        {
            InitializeComponent();

            CategoriesManager.Instance.CategoriesLoaded += new EventHandler(CategoriesManager_CategoriesLoaded);
            CategoriesManager.Instance.CategoriesReset += new EventHandler(CategoriesManager_CategoriesLoaded);
            TransactionsManager.Instance.TransactionsLoaded += new EventHandler(TransactionsManager_TransactionsLoaded);
            TransactionsManager.Instance.TransactionsUpdated += new EventHandler(TransactionsManager_TransactionsUpdated);
        }


        void TransactionsManager_TransactionsLoaded(object sender, EventArgs e)
        {
        }


        void TransactionsManager_TransactionsUpdated(object sender, EventArgs e)
        {
            RefreshSummaryData();
        }


        private void CategoriesManager_CategoriesLoaded(object sender, EventArgs e)
        {
        }

        private void RefreshSummaryData()
        {
            FillAvailableYears();
            UpdateChartData();
        }


        private void UpdateChartData()
        {
            CollectSummaryData();
            UpdateChart();
        }


        private void UpdateChart()
        {
            this.chartIncomeExpenses.Series.Clear();
            this.chartIncomeExpenses.AntiAliasing = AntiAliasingStyles.All;
            this.chartIncomeExpenses.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            this.chartIncomeExpenses.Titles.Clear();
            this.chartIncomeExpenses.Titles.Add("הוצאות מול הכנסות");
            this.chartIncomeExpenses.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
            this.chartIncomeExpenses.RightToLeft = RightToLeft.No;
            this.chartIncomeExpenses.ChartAreas[0].Area3DStyle.Enable3D = false;
            this.chartIncomeExpenses.ChartAreas[0].AxisX.Interval = 1;
            String incomeTitle = "הכנסות";
            this.chartIncomeExpenses.Series.Add(incomeTitle);
            for (int month = 0; month < 12; month++)
            {
                double value = (double)this._income[month];
                //this.chartIncomeExpenses.Series[incomeTitle].Points.AddY(value);
                this.chartIncomeExpenses.Series[incomeTitle].Points.AddXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month + 1), value);
            }
            this.chartIncomeExpenses.Series[incomeTitle].ChartType = SeriesChartType.Column;
            this.chartIncomeExpenses.Series[incomeTitle].IsValueShownAsLabel = false;
            this.chartIncomeExpenses.Series[incomeTitle].IsVisibleInLegend = true;
            this.chartIncomeExpenses.Series[incomeTitle].Color = Color.Green;
            String expensesTitle = "הוצאות";
            this.chartIncomeExpenses.Series.Add(expensesTitle);
            for (int month = 0; month < 12; month++)
            {
                double value = (double)this._expenses[month];
                //this.chartIncomeExpenses.Series[expensesTitle].Points.AddY(Math.Abs(value));
                this.chartIncomeExpenses.Series[expensesTitle].Points.AddXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month + 1), Math.Abs(value));
            }
            this.chartIncomeExpenses.Series[expensesTitle].ChartType = SeriesChartType.Column;
            this.chartIncomeExpenses.Series[expensesTitle].IsValueShownAsLabel = false;
            this.chartIncomeExpenses.Series[expensesTitle].IsVisibleInLegend = true;
            this.chartIncomeExpenses.Series[expensesTitle].Color = Color.Red;
        }


        private void CollectSummaryData()
        {
            this._income = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this._expenses = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            if (this.fldYear.SelectedItem == null) return;
            int year = (int)this.fldYear.SelectedItem;
            Category income = CategoriesManager.Instance.IncomeCategory;
            Category expenses = CategoriesManager.Instance.ExpensesCategory;
            DateTime startDate;
            DateTime endDate;
            for (int month = 0; month < 12; month++)
            {
                startDate = new DateTime(year, month + 1, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
                TransactionsSummaryByCategoryResult incomeResult =
                    TransactionsManager.Instance.GetSummary(startDate, endDate, income);
                TransactionsSummaryByCategoryResult expensesResult =
                    TransactionsManager.Instance.GetSummary(startDate, endDate, expenses);
                this._income[month] = incomeResult.TotalSum;
                this._expenses[month] = expensesResult.TotalSum;
            }
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


        private void chartIncomeExpenses_GetToolTipText(object sender, ToolTipEventArgs e)
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
            UpdateChartData();
        }


        private void FillAvailableYears()
        {
            this.fldYear.DataSource = TransactionsManager.Instance.GetAvailableYears();
        }
    }
}
