using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetManager.Data;
using BudgetManager.Adapters;

namespace BudgetManager.BusinessLayar
{
    public class TransactionsManager
    {
        private static TransactionsManager __instance = null;

        public event TransactionEventHandler TransactionAdded = null;
        public event TransactionEventHandler TransactionRemoved = null;
        public event TransactionEventHandler TransactionDuplicated = null;
        public event EventHandler TransactionsUpdated = null;
        public event EventHandler TransactionsLoaded = null;
        public event EventHandler TransactionsSaved = null;

        private ICollection<CategorizedTransaction> _transactions = null;
        private double _baseSum = 0.0;


        private TransactionsManager()
        {
            this._transactions = new LinkedList<CategorizedTransaction>();
        }


        public static TransactionsManager Instance
        {
            get
            {
                if (__instance == null) __instance = new TransactionsManager();
                return __instance;
            }
        }


        public double BaseSum
        {
            get { return this._baseSum; }
            set { this._baseSum = value; }
        }


        public double CalculateSum(Category category, DateTime startDate, DateTime endDate)
        {
            double sum = 0.0;
            var sums = from ct in this._transactions
                       where ct.DateForCalculation >= startDate &&
                             ct.DateForCalculation <= endDate &&
                             ct.Category.Equals(category)
                       select ct.Sum;
            if (sums != null && sums.Count() > 0) sum = (double)sums.Sum();
            foreach (Category cat in category.SubCategories)
            {
                sum += CalculateSum(cat, startDate, endDate);
            }
            return sum;
        }


        public ICollection<CategorizedTransaction> Transactions
        {
            get { return this._transactions; }
        }


        public void AddTransaction(CategorizedTransaction transaction)
        {
            if (transaction.IsValid())
            {
                this._transactions.Add(transaction);
                TransactionEventArgs args = new TransactionEventArgs();
                args.Transaction = transaction;
                OnTransactionAdded(args);
            }
            else throw new TransactionNotValidException(transaction, "Given transaction is not valid!");
        }


        public void AddTransaction(TransactionRow transaction)
        {
            CategorizedTransaction ct = new CategorizedTransaction(transaction);
            this._transactions.Add(ct);
            TransactionEventArgs args = new TransactionEventArgs();
            args.Transaction = ct;
            OnTransactionAdded(args);
        }


        public CategorizedTransaction NewTransaction()
        {
            CategorizedTransaction ct = new CategorizedTransaction();
            return ct;
        }


        public CategorizedTransaction DuplicateTransaction(CategorizedTransaction transaction)
        {
            CategorizedTransaction newTrans = new CategorizedTransaction(transaction);
            this._transactions.Add(newTrans);
            TransactionEventArgs args = new TransactionEventArgs();
            args.Transaction = newTrans;
            OnTransactionDuplicated(args);
            return newTrans;
        }


        public void RemoveTransaction(CategorizedTransaction transaction)
        {
            this._transactions.Remove(transaction);
            TransactionEventArgs args = new TransactionEventArgs();
            args.Transaction = transaction;
            OnTransactionRemoved(args);
        }


        public void RestoreTransactionOriginalDate(CategorizedTransaction transaction)
        {
            transaction.DateForCalculation = transaction.Date;
        }


        public void Load(String filename)
        {
            TransactionsXmlAdapter adapter = new TransactionsXmlAdapter(filename);
            //List<CategorizedTransaction> transactions = adapter.Load();
            //foreach (CategorizedTransaction t in transactions)
            //{
            //    this._transactions.Add(t);
            //}
            this._transactions = adapter.Load();
            OnTransactionsLoaded(new EventArgs());
        }


        public void Save(String filename)
        {
            TransactionsXmlAdapter adapter = new TransactionsXmlAdapter(filename);
            adapter.Save(this._transactions.ToList<CategorizedTransaction>());
            OnTransactionsSaved(new EventArgs());
        }


        public IEnumerable<CategorizedTransaction> GetTransactions(TransactionSearchDefinition searchDefinition)
        {
            if (searchDefinition == null) return from t in this._transactions select t;

            DateTime? fromDate = searchDefinition.FromDate;
            DateTime? toDate = searchDefinition.ToDate;
            bool includeCat = searchDefinition.IncludeCategories;
            List<Category> categories = CategoriesManager.Instance.GetAllSubCategories(searchDefinition.Categories);

            IEnumerable<CategorizedTransaction> results = null;
            results = from t in this._transactions
                      where (fromDate == null || t.DateForCalculation >= fromDate) &&
                            (toDate == null || t.DateForCalculation <= toDate) &&
                            (categories == null || !(includeCat ^ categories.Contains(t.Category))) // ^ is XOR
                      select t;
            return results;
        }


        public TransactionsSummaryByCategoryResult GetSummary(DateTime? fromDate, DateTime? toDate, Category category)
        {
            TransactionsSummaryByCategoryResult result = null;
            DateTime startDate = fromDate == null ? DateTime.MinValue : fromDate.Value;
            DateTime endDate = toDate == null ? DateTime.MaxValue : toDate.Value;
            double totalSum = 0;
            IDictionary<Category, double> summary = new Dictionary<Category, double>();

            foreach (Category cat in category.SubCategories)
            {
                double sum = CalculateSum(cat, startDate, endDate);
                summary.Add(cat, sum);
                totalSum += sum;
            }
            // If the parent category has its own sum (different from the total sum of its sub categories)
            // add it to the summary
            double catSum = CalculateSum(category, startDate, endDate);
            if (catSum != totalSum) summary.Add(category, catSum - totalSum);

            result = new TransactionsSummaryByCategoryResult(startDate, endDate, category, totalSum, summary);
            return result;
        }


        public List<int> GetAvailableYears()
        {
            List<int> years = new List<int>();
            IEnumerable<int> results = null;
            results = from t in this._transactions
                      select t.Date.Value.Year;
            if (results != null && results.Count() > 0) years = results.Distinct().ToList<int>();
            return years;
        }


        protected void OnTransactionAdded(TransactionEventArgs e)
        {
            if (this.TransactionAdded != null) this.TransactionAdded(this, e);
            OnTransactionsUpdated(new EventArgs());
        }


        protected void OnTransactionRemoved(TransactionEventArgs e)
        {
            if (this.TransactionRemoved != null) this.TransactionRemoved(this, e);
            OnTransactionsUpdated(new EventArgs());
        }


        protected void OnTransactionDuplicated(TransactionEventArgs e)
        {
            if (this.TransactionDuplicated != null) this.TransactionDuplicated(this, e);
            OnTransactionsUpdated(new EventArgs());
        }


        private void OnTransactionsUpdated(EventArgs e)
        {
            if (this.TransactionsUpdated != null) this.TransactionsUpdated(this, e);
        }


        private void OnTransactionsLoaded(EventArgs e)
        {
            if (this.TransactionsLoaded != null) this.TransactionsLoaded(this, e);
            OnTransactionsUpdated(new EventArgs());
        }


        private void OnTransactionsSaved(EventArgs e)
        {
            if (this.TransactionsSaved != null) this.TransactionsSaved(this, e);
        }
    }
}
