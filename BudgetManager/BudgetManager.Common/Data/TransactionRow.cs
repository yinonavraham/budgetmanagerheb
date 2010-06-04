using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.Data
{
    [Serializable]
    public class TransactionRow
    {
        private DateTime? _date = null; // תאריך חיוב התנועה
        private String _description = null; // תיאור התנועה
        private int? _code = null; // אסמכתא
        private double? _sum = null; //  סכום התנועה


        public TransactionRow() { }


        public TransactionRow(DateTime date, String desc, int code, double sum)
        {
            this._date = date;
            this._description = desc;
            this._code = code;
            this._sum = sum;
        }


        public TransactionRow(TransactionRow transaction)
        {
            this._date = transaction.Date;
            this._description = transaction.Description;
            this._code = transaction.Code;
            this._sum = transaction.Sum;
        }


        public DateTime? Date
        {
            get { return this._date; }
            set { this._date = value; }
        }


        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }


        public int? Code
        {
            get { return this._code; }
            set { this._code = value; }
        }


        public double? Sum
        {
            get { return this._sum; }
            set { this._sum = value; }
        }


        public bool IsValid()
        {
            return this._date != null &&
                   this._description != null &&
                   this._code != null &&
                   this._sum != null;
        }


        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            String date = this.Date == null ? "" : ((DateTime)this.Date).ToShortDateString();
            sb.Append(date);
            sb.Append(" | ");
            sb.Append(this.Description);
            sb.Append(" | ");
            sb.Append(this.Code);
            sb.Append(" | ");
            sb.Append(this.Sum);
            return sb.ToString();
        }
    }
}
