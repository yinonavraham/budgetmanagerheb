using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetManager.Data;
using System.ComponentModel;
using System.Threading;

namespace BudgetManager.BusinessLayar
{
    public class CategorySuggestionManager
    {
        public event ProgressReportEventHandler CalculationStarted = null;
        public event ProgressReportEventHandler CalculationFinished = null;
        public event ProgressReportEventHandler TransactionCounted = null;
        public event ProgressReportEventHandler SuggestionValidated = null;

        private class CategoriesCounter
        {
            private Dictionary<Category, int> _categoriesCount = new Dictionary<Category, int>();


            public void Add(Category category)
            {
                if (!this._categoriesCount.ContainsKey(category))
                {
                    this._categoriesCount.Add(category, 1);
                }
                else
                {
                    this._categoriesCount[category]++;
                }
            }


            public Category GetMaxCategory()
            {
                Category category = null;
                int max = 0;
                foreach (Category cat in this._categoriesCount.Keys)
                {
                    if (this._categoriesCount[cat] > max)
                    {
                        category = cat;
                        max = this._categoriesCount[cat];
                    }
                }
                return category;
            }


            public int GetCategoryCount(Category category)
            {
                if (this._categoriesCount.ContainsKey(category)) return this._categoriesCount[category];
                else return 0;
            }


            public void Clear()
            {
                this._categoriesCount.Clear();
            }
        }

        private class TransctionWrapper
        {
            public enum Field { Code, Description, Sum }

            private TransactionRow _transaction = null;
            private List<Field> _fields = new List<Field>();


            public TransctionWrapper(TransactionRow transaction)
            {
                this._transaction = transaction;
            }


            public TransctionWrapper(TransactionRow transaction, Field[] fields)
            {
                this._transaction = transaction;
                this._fields = new List<Field>(fields);
            }


            public TransactionRow Transaction
            {
                get { return this._transaction; }
            }


            public Field[] Fields
            {
                get { return this._fields.ToArray(); }
            }


            public void AddField(Field field)
            {
                if (!this._fields.Contains(field)) this._fields.Add(field);
            }

            
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                TransactionRow t = null;
                TransctionWrapper tw = obj as TransctionWrapper;
                if (tw != null) t = tw.Transaction;
                else t = obj as TransactionRow;
                if (t == null) return false;
                foreach (Field field in this._fields)
                {
                    switch (field)
                    {
                        case Field.Code:
                            if (!this._transaction.Code.Equals(t.Code)) return false;
                            break;
                        case Field.Description:
                            if (!this._transaction.Description.Equals(t.Description)) return false;
                            break;
                        case Field.Sum:
                            if (!this._transaction.Sum.Equals(t.Sum)) return false;
                            break;
                    }
                }
                return true;
            }


            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                bool first = true;
                foreach (Field field in this._fields)
                {
                    if (!first) sb.Append("|");
                    else first = false;
                    switch (field)
                    {
                        case Field.Code:
                            sb.Append(this._transaction.Code);
                            break;
                        case Field.Description:
                            sb.Append(this._transaction.Description);
                            break;
                        case Field.Sum:
                            sb.Append(this._transaction.Sum);
                            break;
                    }
                }
                return sb.ToString();
            }


            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }
        }

        private static CategorySuggestionManager __instance = null;

        private List<Dictionary<TransctionWrapper, Category>> _suggestions = 
            new List<Dictionary<TransctionWrapper, Category>>();
        private List<Dictionary<TransctionWrapper, CategoriesCounter>> _counters = 
            new List<Dictionary<TransctionWrapper, CategoriesCounter>>();
        private List<TransctionWrapper> _matchingLevels = new List<TransctionWrapper>();
        private int _minCountToSuggest = 2;
        private int _totalTempSuggestions = 0;


        private CategorySuggestionManager() 
        {
            InitializeMatchingLevels();
        }


        public static CategorySuggestionManager Instance
        {
            get
            {
                if (__instance == null) __instance = new CategorySuggestionManager();
                return __instance;
            }
        }


        private void InitializeMatchingLevels()
        {
            this._matchingLevels.Clear();
            this._matchingLevels.Add(new TransctionWrapper(null, new TransctionWrapper.Field[] { 
                TransctionWrapper.Field.Code,
                TransctionWrapper.Field.Description,
                TransctionWrapper.Field.Sum }));
            this._matchingLevels.Add(new TransctionWrapper(null, new TransctionWrapper.Field[] { 
                TransctionWrapper.Field.Code,
                TransctionWrapper.Field.Description }));
            this._matchingLevels.Add(new TransctionWrapper(null, new TransctionWrapper.Field[] { 
                TransctionWrapper.Field.Code,
                TransctionWrapper.Field.Sum }));
            this._matchingLevels.Add(new TransctionWrapper(null, new TransctionWrapper.Field[] { 
                TransctionWrapper.Field.Description,
                TransctionWrapper.Field.Sum }));
            this._matchingLevels.Add(new TransctionWrapper(null, new TransctionWrapper.Field[] { 
                TransctionWrapper.Field.Code }));
            this._matchingLevels.Add(new TransctionWrapper(null, new TransctionWrapper.Field[] { 
                TransctionWrapper.Field.Description }));
        }


        public void CalculateSuggestions(ICollection<CategorizedTransaction> transactions)
        {
            if (transactions == null) return;
            OnCalculationStarted(transactions.Count);
            InitializeCounters();
            int iter = 1;
            this._totalTempSuggestions = 0;
            foreach (CategorizedTransaction ct in transactions)
            {
                AddTransactionToCounters(ct);
                OnTransactionCounted(iter++, transactions.Count);
            }
            StoreSuggestions();
            ClearAllCounters();
            OnCalculationFinished(GetSuggestionsCount());
        }


        private int GetSuggestionsCount()
        {
            int count = 0;
            foreach (var dic in this._suggestions)
            {
                foreach (TransctionWrapper tw in dic.Keys) count++;
            }
            return count;
        }


        private void AddTransactionToCounters(CategorizedTransaction ct)
        {
            for (int i = 0; i < this._counters.Count; i++)
            {
                TransctionWrapper tw = new TransctionWrapper(ct, this._matchingLevels[i].Fields);
                if (!this._counters[i].Keys.Contains(tw)) this._counters[i].Add(tw, new CategoriesCounter());
                this._counters[i][tw].Add(ct.Category);
                this._totalTempSuggestions++;
            }
        }


        private void StoreSuggestions()
        {
            this._suggestions.Clear();
            int iter = 0;
            int tot = this._totalTempSuggestions;
            for (int i = 0; i < this._counters.Count; i++)
            {
                this._suggestions.Add(new Dictionary<TransctionWrapper, Category>());
                foreach (TransctionWrapper tw in this._counters[i].Keys)
                {
                    Category category = this._counters[i][tw].GetMaxCategory();
                    if (category != null)
                    {
                        int count = this._counters[i][tw].GetCategoryCount(category);
                        if (count >= this._minCountToSuggest)
                        {
                            this._suggestions[i].Add(tw, category);
                        }
                    }
                    OnSuggestionValidated(iter++, tot);
                }
            }
        }


        private void InitializeCounters()
        {
            this._counters = new List<Dictionary<TransctionWrapper, CategoriesCounter>>();
            foreach (TransctionWrapper tw in this._matchingLevels)
            {
                this._counters.Add(new Dictionary<TransctionWrapper, CategoriesCounter>());
            }
        }


        private void ClearAllCounters()
        {
            this._counters.Clear();
        }


        public Category GetSuggestedCategory(TransactionRow transaction)
        {
            Category category = null;
            for (int i = 0; i < this._suggestions.Count; i++)
            {
                TransctionWrapper tw = new TransctionWrapper(transaction, this._matchingLevels[i].Fields);
                if (this._suggestions[i].ContainsKey(tw))
                {
                    category = this._suggestions[i][tw];
                    break;
                }
            }
            return category;
        }


        private void OnCalculationStarted(int totalTransactions)
        {
            if (this.CalculationStarted != null)
            {
                this.CalculationStarted(this, new ProgressReportEventArgs(0, totalTransactions));
            }
        }


        private void OnCalculationFinished(int totalSuggestions)
        {
            if (this.CalculationFinished != null)
            {
                this.CalculationFinished(this, new ProgressReportEventArgs(totalSuggestions, totalSuggestions));
            }
        }


        private void OnTransactionCounted(int curIter, int totIter)
        {
            if (this.TransactionCounted != null)
            {
                this.TransactionCounted(this, new ProgressReportEventArgs(curIter, totIter));
            }
        }


        private void OnSuggestionValidated(int curIter, int totIter)
        {
            if (this.SuggestionValidated != null)
            {
                this.SuggestionValidated(this, new ProgressReportEventArgs(curIter, totIter));
            }
        }
    }
}
