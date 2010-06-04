using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.Data
{
    public class TransactionsSummaryByCategoryResult
    {
        private DateTime _fromDate;
        private DateTime _toDate;
        private IDictionary<Category, double> _summaryForCategory = null;
        private Category _category = null;
        private double _totalSum = 0;


        public TransactionsSummaryByCategoryResult(
            DateTime fromDate, 
            DateTime toDate, 
            Category category, 
            double totalSum,
            IDictionary<Category, double> summary)
        {
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._category = category;
            this._totalSum = totalSum;
            this._summaryForCategory = summary;
        }


        public Category Category
        {
            get { return this._category; }
        }


        public DateTime FromDate
        {
            get { return this._fromDate; }
        }


        public DateTime ToDate
        {
            get { return this._toDate; }
        }


        public double TotalSum
        {
            get { return this._totalSum; }
        }


        public IDictionary<Category, double> SummaryByCategory
        {
            get { return this._summaryForCategory; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            sb.Append(this._fromDate.ToShortDateString());
            sb.Append("-");
            sb.Append(this._toDate.ToShortDateString());
            sb.Append(" | ");
            sb.Append(this._category.Name);
            sb.Append(" | ");
            sb.Append(this._totalSum);
            if (this._summaryForCategory.Keys.Count > 0)
            {
                sb.Append(" [ ");
                bool isFirst = true;
                foreach (Category cat in this._summaryForCategory.Keys)
                {
                    if (!isFirst) sb.Append(", ");
                    isFirst = false;
                    sb.Append(cat.Name);
                    sb.Append(":");
                    sb.Append(this._summaryForCategory[cat]);
                }
                sb.Append(" ]");
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
