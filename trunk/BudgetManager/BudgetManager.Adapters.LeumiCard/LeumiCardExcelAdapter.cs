using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using BudgetManager.Data;

namespace BudgetManager.Adapters.LeumiCard
{
    [Name("לאומיקארד - קובץ אקסל")]
    [Description("ייבוא תנועות מגליון אקסל שנוצר באתר האינטרנט של לאומיקארד - עסקאות בכרטיס האשראי.")]
    public class LeumiCardExcelAdapter : MarshalByRefObject, ITransactionsImportAdapter
    {
        private enum Headers { ActionDate, BusinessName, Type, ActionSum, PaymentDate, PaymentSum, Comments }

        private Dictionary<String, Headers> _headersText = null;
        private Dictionary<Headers, int> _headersPositions = null;
        private int _year = DateTime.Today.Year;
        private bool _useGUI = true;

        public LeumiCardExcelAdapter()
        {
            InitializeHeaders();
        }

        private void InitializeHeaders()
        {
            this._headersText = new Dictionary<String, Headers>();
            this._headersText.Add("תאריך עסקה", Headers.ActionDate);
            this._headersText.Add("שם בית עסק", Headers.BusinessName);
            this._headersText.Add("סוג עסקה", Headers.Type);
            this._headersText.Add("סכום עסקה", Headers.ActionSum);
            this._headersText.Add("תאריך חיוב", Headers.PaymentDate);
            this._headersText.Add("סכום חיוב", Headers.PaymentSum);
            this._headersText.Add("הערות", Headers.Comments);

            this._headersPositions = new Dictionary<Headers, int>();
        }

        #region ITransactionsImportAdapter Members

        public List<TransactionRow> ImportTransactions(String filepath)
        {
            Excel.Application app;
            Excel.Workbook book;
            Excel.Worksheet sheet;
            Excel.Range range;

            app = new Excel.ApplicationClass();
            book = app.Workbooks.Open(filepath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
            sheet = (Excel.Worksheet)book.Sheets[1];
            range = sheet.UsedRange;

            int row = 1;
            int col = 1;
            bool stop = false;
            Excel.Range cell = null;
            Object val = null;
            // Go to where the table starts - the headers row
            for (row = 1; row <= range.Rows.Count; row++)
            {
                for (col = 1; col <= range.Columns.Count; col++)
                {
                    cell = (Excel.Range)range[row, 1];
                    val = cell.Value2;
                    if (val != null && this._headersText.ContainsKey(val.ToString())) stop = true;
                    if (stop) break;
                }
                if (stop) break;
            }
            // Read the headers and save the locations (column) for each header
            for (col = 1; col <= range.Columns.Count; col++)
            {
                cell = (Excel.Range)range[row, col];
                val = cell.Value2;
                if (val != null && this._headersText.ContainsKey(val.ToString()))
                    this._headersPositions.Add(this._headersText[val.ToString()], col);
            }
            row++;
            // Read the transaction rows, one by one
            List<TransactionRow> transactions = new List<TransactionRow>();
            for (; row <= range.Rows.Count; row++)
            {
                bool allNull = true;
                TransactionRow transaction = new TransactionRow();
                foreach (Headers header in this._headersPositions.Keys)
                {
                    col = this._headersPositions[header];
                    cell = (Excel.Range)range[row, col];
                    val = cell.Value2;
                    SetTransactionFieldValue(ref transaction, header, val);
                    if (val != null) allNull = false;
                }
                if (allNull) break;
                // Set the transaction code to 0 because there is no code in the Excel sheet...
                transaction.Code = 0;
                if (transaction.IsValid()) transactions.Add(transaction);
            }
            // Close the input excel file and quit the MS Excel application
            book.Close(false, null, null);
            app.Quit();

            // Return the transactions
            return transactions;
        }

        #endregion


        private void SetTransactionFieldValue(ref TransactionRow transaction, Headers header, object val)
        {
            if (transaction == null) return;
            double sum;
            switch (header)
            {
                case Headers.ActionDate:
                    break;
                case Headers.BusinessName:
                    if (val != null) transaction.Description = val.ToString();
                    break;
                case Headers.Type:
                    break;
                case Headers.ActionSum:
                    break;
                case Headers.PaymentDate:
                    transaction.Date = ExcelDate2DateTime(val);
                    break;
                case Headers.PaymentSum:
                    if (val != null && double.TryParse(val.ToString(), out sum))
                    {
                        transaction.Sum = sum;
                    }
                    break;
                case Headers.Comments:
                    if (val != null)
                    {
                        transaction.Description += String.Format(" ({0})", val.ToString());
                    }
                    break;
            }
        }


        private DateTime? ExcelDate2DateTime(Object value)
        {
            if (value == null) return null;
            int days = Convert.ToInt32(value);
            TimeSpan ts = new TimeSpan(days - 2, 0, 0, 0);
            DateTime date = new DateTime(1900, 1, 1).Add(ts);
            date = new DateTime(this._year, date.Month, date.Day);
            return date;
        }
    }
}
