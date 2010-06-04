using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.Data
{
    public class CategorizedTransaction : TransactionRow
    {
        private static long __nextInternalID = 0;

        private long _internalID = -1;
        private Category _category = null;
        private DateTime _dateForCalc;


        public CategorizedTransaction() : base()
        {
            this._internalID = __nextInternalID++;
        }


        public CategorizedTransaction(TransactionRow transaction) : base(transaction) 
        {
            this._dateForCalc = (DateTime)transaction.Date;
            this._internalID = __nextInternalID++;
        }


        public CategorizedTransaction(CategorizedTransaction transaction)
            : base(transaction)
        {
            this._dateForCalc = (DateTime)transaction.DateForCalculation;
            this._category = transaction.Category;
            this._internalID = __nextInternalID++;
        }


        public CategorizedTransaction(TransactionRow transaction, Category category) : base(transaction) 
        {
            this._category = category;
            this._dateForCalc = (DateTime)transaction.Date;
            this._internalID = __nextInternalID++;
        }


        public CategorizedTransaction(TransactionRow transaction, Category category, DateTime dateForCalculate)
            : base(transaction)
        {
            this._category = category;
            this._dateForCalc = dateForCalculate;
            this._internalID = __nextInternalID++;
        }


        public long InternalID
        {
            get { return this._internalID; }
        }


        public Category Category
        {
            get { return this._category; }
            set { this._category = value; }
        }


        public DateTime? DateForCalculation
        {
            get { return this._dateForCalc; }
            set 
            {
                if (value != null) this._dateForCalc = (DateTime)value;
                else this._dateForCalc = (DateTime)this.Date;
            }
        }


        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(" | ");
            sb.Append(this._category);
            sb.Append(" | ");
            sb.Append(this._dateForCalc.ToShortDateString());
            return sb.ToString();
        }


        public new bool IsValid()
        {
            return base.IsValid() & this.Category != null;
        }
    }
}
