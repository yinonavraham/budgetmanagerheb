using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetManager.Data;

namespace BudgetManager.BusinessLayar
{
    public class TransactionSearchDefinition
    {
        private DateTime? _fromDate = null;
        private DateTime? _toDate = null;
        private List<Category> _categories = null;
        private bool _includeCategories = true;


        /// <summary>
        /// Construct a search definition for transactions
        /// </summary>
        public TransactionSearchDefinition() { }


        /// <summary>
        /// Construct a search definition for transactions
        /// </summary>
        /// <param name="fromDate">Lower limit for date. Can be <code>null</code> to set no limit.</param>
        /// <param name="toDate">Upper limit for date. Can be <code>null</code> to set no limit.</param>
        public TransactionSearchDefinition(DateTime? fromDate, DateTime? toDate)
        {
            this._fromDate = fromDate;
            this._toDate = toDate;
        }


        /// <summary>
        /// Construct a search definition for transactions
        /// </summary>
        /// <param name="fromDate">Lower limit for date. Can be <code>null</code> to set no limit.</param>
        /// <param name="toDate">Upper limit for date. Can be <code>null</code> to set no limit.</param>
        /// <param name="categories">
        ///     The categories for the search. Use IncludeCategories to set whether to include the categories in the 
        ///     search result (<code>true</code>) or to exclude them (<code>false</code>).
        /// </param>
        public TransactionSearchDefinition(DateTime? fromDate, DateTime? toDate, List<Category> categories)
        {
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._categories = categories;
        }


        /// <summary>
        /// Construct a search definition for transactions
        /// </summary>
        /// <param name="fromDate">Lower limit for date. Can be <code>null</code> to set no limit.</param>
        /// <param name="toDate">Upper limit for date. Can be <code>null</code> to set no limit.</param>
        /// <param name="categories">
        ///     The categories for the search. Use IncludeCategories to set whether to include the categories in the 
        ///     search result (<code>true</code>) or to exclude them (<code>false</code>).
        /// </param>
        /// <param name="includeCategories">
        ///     Set whether to include the given categories in the search result (<code>true</code>) 
        ///     or to exclude them (<code>false</code>).
        /// </param>
        public TransactionSearchDefinition(DateTime? fromDate, DateTime? toDate, List<Category> categories, bool includeCategories)
        {
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._categories = categories;
            this._includeCategories = includeCategories;
        }


        /// <summary>
        /// Construct a search definition for transactions
        /// </summary>
        /// <param name="categories">
        ///     The categories for the search. Use IncludeCategories to set whether to include the categories in the 
        ///     search result (<code>true</code>) or to exclude them (<code>false</code>).
        /// </param>
        /// <param name="includeCategories">
        ///     Set whether to include the given categories in the search result (<code>true</code>) 
        ///     or to exclude them (<code>false</code>).
        /// </param>
        public TransactionSearchDefinition(List<Category> categories, bool includeCategories)
        {
            this._categories = categories;
            this._includeCategories = includeCategories;
        }


        /// <summary>
        /// Get or set the minimum date for the search.
        /// If set to <code>null</code> - no lower limit for the search.
        /// </summary>
        public DateTime? FromDate
        {
            get { return this._fromDate; }
            set { this._fromDate = value; }
        }


        /// <summary>
        /// Get or set the maximum date for the search.
        /// If set to <code>null</code> - no upper limit for the search.
        /// </summary>
        public DateTime? ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }


        /// <summary>
        /// Get or set the list of categories for the search. 
        /// If set to <code>null</code> - all categories will be handled.
        /// </summary>
        public List<Category> Categories
        {
            get { return this._categories; }
            set { this._categories = value; }
        }


        /// <summary>
        /// Get or set whether to include the list of categories in the search or to exclude them.
        /// </summary>
        public bool IncludeCategories
        {
            get { return this._includeCategories; }
            set { this._includeCategories = value; }
        }
    }
}
