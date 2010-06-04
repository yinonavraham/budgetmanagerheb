using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using BudgetManager.Data;

namespace BudgetManager.Adapters.Isracard
{
    public class IsracardExcelAdapter : MarshalByRefObject, ITransactionsImportAdapter
    {
        private enum Headers { Date, Description, Code, Sum, AdditionalInfo }
        private enum HeadersOther { Date, Description, Code, Sum, City, Currency, OriginalSum }

        private Dictionary<String, Headers> _headersText = null;
        private Dictionary<Headers, int> _headersPositions = null;
        private Dictionary<String, HeadersOther> _headersOtherText = null;
        private Dictionary<HeadersOther, int> _headersOtherPositions = null;
        private int _year = DateTime.Today.Year;
        private bool _useGUI = true;

        public IsracardExcelAdapter()
        {
            InitializeHeaders();
        }

        private void InitializeHeaders()
        {
            this._headersText = new Dictionary<String, Headers>();
            this._headersText.Add("תאריך רכישה", Headers.Date);
            this._headersText.Add("שם בית עסק", Headers.Description);
            this._headersText.Add("מספר שובר", Headers.Code);
            this._headersText.Add("סכום לחיוב", Headers.Sum);
            this._headersText.Add("פרוט נוסף", Headers.AdditionalInfo);

            this._headersPositions = new Dictionary<Headers, int>();

            this._headersOtherText = new Dictionary<String, HeadersOther>();
            this._headersOtherText.Add("תאריך קניה", HeadersOther.Date);
            this._headersOtherText.Add("שם בית עסק", HeadersOther.Description);
            this._headersOtherText.Add("מספר שובר", HeadersOther.Code);
            this._headersOtherText.Add("סכום לחיוב", HeadersOther.Sum);
            this._headersOtherText.Add("עיר", HeadersOther.City);
            this._headersOtherText.Add("מטבע מקורי", HeadersOther.Currency);
            this._headersOtherText.Add("סכום מקורי", HeadersOther.OriginalSum);

            this._headersOtherPositions = new Dictionary<HeadersOther, int>();
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
                // Check that the date cell is not null
                col = this._headersPositions[Headers.Date];
                cell = (Excel.Range)range[row, col];
                // If the date is null - break
                if (cell == null) break;
                bool allNull = true;
                String additionalInfo = "";
                TransactionRow transaction = new TransactionRow();
                foreach (Headers header in this._headersPositions.Keys)
                {
                    col = this._headersPositions[header];
                    cell = (Excel.Range)range[row, col];
                    val = cell.Value2;
                    if (!header.Equals(Headers.AdditionalInfo))
                        SetTransactionFieldValue(ref transaction, header, val);
                    else if (val != null) additionalInfo = val.ToString();
                    if (val != null) allNull = false;
                }
                if (allNull) break;
                if (!String.IsNullOrEmpty(additionalInfo)) transaction.Description += String.Format(" ({0})", additionalInfo);
                if (transaction.IsValid()) transactions.Add(transaction);
            }
            // Look for payments in Dollars / Euros
            bool otherPayments = false;
            for (; row <= range.Rows.Count; row++)
            {
                for (col = 1; col <= range.Columns.Count; col++)
                {
                    cell = (Excel.Range)range[row, 1];
                    val = cell.Value2;
                    if (val != null && val.ToString().StartsWith("עסקאות בחו\"ל")) otherPayments = true;
                    if (otherPayments) break;
                }
                if (otherPayments) break;
            }
            // If payments in Dollars / Euros are found
            if (otherPayments)
            {
                row++;
                // Read the headers and save the locations (column) for each header
                for (col = 1; col <= range.Columns.Count; col++)
                {
                    cell = (Excel.Range)range[row, col];
                    val = cell.Value2;
                    if (val != null && this._headersOtherText.ContainsKey(val.ToString()))
                        this._headersOtherPositions.Add(this._headersOtherText[val.ToString()], col);
                }
                row++;
                // Read the payments
                for (; row <= range.Rows.Count; row++)
                {
                    // Check that the date cell is not null
                    col = this._headersOtherPositions[HeadersOther.Date];
                    cell = (Excel.Range)range[row, col];
                    // If the date is null - break
                    if (cell == null) break;
                    bool allNull = true;
                    String city = "";
                    String originalSum = "";
                    String currency = "";
                    TransactionRow transaction = new TransactionRow();
                    foreach (HeadersOther header in this._headersOtherPositions.Keys)
                    {
                        col = this._headersOtherPositions[header];
                        cell = (Excel.Range)range[row, col];
                        val = cell.Value2;
                        switch (header)
                        {
                            case HeadersOther.City:
                                if (val != null) city = val.ToString();
                                break;
                            case HeadersOther.Currency:
                                if (val != null) currency = val.ToString();
                                break;
                            case HeadersOther.OriginalSum:
                                if (val != null) originalSum = val.ToString();
                                break;
                            default: SetTransactionFieldValueOther(ref transaction, header, val);
                                break;
                        }
                        if (val != null) allNull = false;
                    }
                    if (allNull) break;
                    transaction.Description += String.Format(" ({0},{1},{2})", city, originalSum, currency);
                    if (transaction.IsValid()) transactions.Add(transaction);
                }
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
                case Headers.Sum:
                    if (val != null && double.TryParse(val.ToString(), out sum))
                    {
                        transaction.Sum = sum * -1;
                    }
                    break;
            }
        }


        private void SetTransactionFieldValueOther(ref TransactionRow transaction, HeadersOther header, object val)
        {
            if (transaction == null) return;
            double sum;
            switch (header)
            {
                case HeadersOther.Date:
                    transaction.Date = ExcelDate2DateTime(val);
                    break;
                case HeadersOther.Description:
                    if (val != null) transaction.Description = val.ToString();
                    break;
                case HeadersOther.Code:
                    int code;
                    if (val != null && int.TryParse(val.ToString(), out code)) transaction.Code = code;
                    break;
                case HeadersOther.Sum:
                    if (val != null && double.TryParse(val.ToString(), out sum))
                    {
                        transaction.Sum = sum * -1;
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
