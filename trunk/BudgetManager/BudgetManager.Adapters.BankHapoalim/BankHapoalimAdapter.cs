using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using BudgetManager.Data;

namespace BudgetManager.Adapters.BankHapoalim
{
    public class BankHapoalimAdapter : MarshalByRefObject, ITransactionsImportAdapter
    {
        private enum Headers { Date, Description, Code, Credit, Debt, OperationValue, TotalSum }

        private Dictionary<String, Headers> _headersText = null;
        private Dictionary<Headers, int> _headersPositions = null;
        private int _year = DateTime.Today.Year;
        private bool _useGUI = true;

        public BankHapoalimAdapter()
        {
            InitializeHeaders();
        }

        private void InitializeHeaders()
        {
            this._headersText = new Dictionary<String, Headers>();
            this._headersText.Add("תאריך", Headers.Date);
            this._headersText.Add("תיאור פעולה", Headers.Description);
            this._headersText.Add("אסמכתא", Headers.Code);
            this._headersText.Add("ערך הפעולה", Headers.OperationValue);
            this._headersText.Add("חובה", Headers.Debt);
            this._headersText.Add("זכות", Headers.Credit);
            this._headersText.Add("יתרה בש\"ח", Headers.TotalSum);

            this._headersPositions = new Dictionary<Headers, int>();
        }


        public int Year
        {
            get { return this._year; }
            set { this._year = value; }
        }


        public bool UseGUI
        {
            get { return this._useGUI; }
            set { this._useGUI = value; }
        }


        #region ITransactionsImportAdapter Members

        public List<TransactionRow> ImportTransactions(String filepath)
        {
            Excel.Application app;
            Excel.Workbook book;
            Excel.Worksheet sheet;
            Excel.Range range;

            if (this._useGUI)
            {
                YearPickerPopup popup = new YearPickerPopup();
                popup.ShowDialog();
                this._year = popup.SelectedYear;
            }

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
                case Headers.Date:
                    transaction.Date = ExcelDate2DateTime(val);
                    break;
                case Headers.Description:
                    if (val != null) transaction.Description = val.ToString();
                    break;
                case Headers.Code:
                    int code;
                    if (val != null && int.TryParse(val.ToString(), out code)) transaction.Code = code;
                    break;
                case Headers.Credit:
                    if (val != null && double.TryParse(val.ToString(), out sum))
                    {
                        transaction.Sum = sum;
                    }
                    break;
                case Headers.Debt:
                    if (val != null && double.TryParse(val.ToString(), out sum))
                    {
                        transaction.Sum = -sum;
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

    class Program
    {
        static DateTime ExcelDate2DateTime(Object value)
        {
            int days = Convert.ToInt32(value);
            TimeSpan ts = new TimeSpan(days - 2, 0, 0, 0);
            return new DateTime(1900, 1, 1).Add(ts);
        }

        static void Main(string[] args)
        {
            Excel.Application app;
            Excel.Workbook book;
            Excel.Worksheet sheet;
            Excel.Range range;

            app = new Excel.ApplicationClass();
            book = app.Workbooks.Open(@"c:\temp\poalwwwc.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
            sheet = (Excel.Worksheet)book.Sheets[1];
            range = sheet.UsedRange;

            FileStream fs = new FileStream(@"C:\temp\output.txt", FileMode.Create);
            byte[] bytes = null;

            List<String> headersList = new List<String>(
                new String[] { "תאריך", "תיאור פעולה", "אסמכתא", "ערך הפעולה", "חובה", "זכות", "יתרה בש\"ח" });
            bool write = false;

            for (int row = 1; row <= range.Rows.Count; row++)
            {
                Excel.Range cell = (Excel.Range)range[row, 1];
                Object val = cell.Value2;
                if (!write && val != null && headersList.Contains(val.ToString())) write = true;
                if (!write) continue;
                bytes = Encoding.Unicode.GetBytes("|");
                fs.Write(bytes, 0, bytes.Length);
                for (int col = 1; col <= range.Columns.Count; col++)
                {
                    cell = (Excel.Range)range[row, col];
                    val = cell.Value2;

                    String s = val == null ? "" : val.ToString();
                    bytes = Encoding.Unicode.GetBytes(s);
                    fs.Write(bytes, 0, bytes.Length);
                    bytes = Encoding.Unicode.GetBytes(" | ");
                    fs.Write(bytes, 0, bytes.Length);
                }
                bytes = Encoding.Unicode.GetBytes("\r\n");
                fs.Write(bytes, 0, bytes.Length);
            }

            fs.Close();

            book.Close(false, null, null);
            app.Quit();
        }
    }
}
