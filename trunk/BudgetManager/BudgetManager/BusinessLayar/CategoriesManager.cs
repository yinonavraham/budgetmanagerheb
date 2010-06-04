using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetManager.Data;

namespace BudgetManager.BusinessLayar
{
    public class CategoriesManager
    {
        private static CategoriesManager __instance = null;

        public event EventHandler CategoriesLoaded = null;
        public event EventHandler CategoriesSaved = null;
        public event EventHandler CategoriesReset = null;

        private static readonly int ROOT_CATEGORY = 0;
        private static readonly int EXPENSES_CATEGORY = 1;
        private static readonly int INCOME_CATEGORY = 2;
        private static readonly int NOT_FOR_CALC_CATEGORY = 3;

        private Category _rootCategory = null;


        private CategoriesManager()
        {
            Category.MaxLevel = 3;
        }


        public static CategoriesManager Instance
        {
            get
            {
                if (__instance == null) __instance = new CategoriesManager();
                return __instance;
            }
        }


        public bool IsCategoryForCalculation(Category category)
        {
            if (category == null || category.Parent == null) return false;
            Category cat = category;
            while (cat != null)
            {
                if (cat.Code.Equals(NOT_FOR_CALC_CATEGORY)) return false;
                cat = cat.Parent;
            }
            return true;
        }


        public void Load(String filename)
        {
            CategoriesXmlAdapter adapter = new CategoriesXmlAdapter(filename);
            this._rootCategory = adapter.Load();
            OnCategoriesLoaded(new EventArgs());
        }


        public void Reset()
        {
            if (this.RootCategory != null) this.RootCategory.RemoveAllSubCategories();
            Category.Reset();
            this._rootCategory = new Category(ROOT_CATEGORY, "הכל");
            this._rootCategory.AddSubCategory(EXPENSES_CATEGORY, "הוצאות");
            this._rootCategory.AddSubCategory(INCOME_CATEGORY, "הכנסות");
            this._rootCategory.AddSubCategory(NOT_FOR_CALC_CATEGORY, "לא לחישוב");
            OnCategoriesReset(new EventArgs());
        }


        public void Save(String filename)
        {
            CategoriesXmlAdapter adapter = new CategoriesXmlAdapter(filename);
            adapter.Save(this.RootCategory);
            OnCategoriesSaved(new EventArgs());
        }


        public Category RootCategory
        {
            get { return this._rootCategory; }
        }


        public Category ExpensesCategory
        {
            get { return this._rootCategory.GetSubCategory(EXPENSES_CATEGORY); }
        }


        public Category IncomeCategory
        {
            get { return this._rootCategory.GetSubCategory(INCOME_CATEGORY); }
        }


        public Category NotForCalculationCategory
        {
            get { return this._rootCategory.GetSubCategory(NOT_FOR_CALC_CATEGORY); }
        }


        public List<Category> GetAllSubCategories(List<Category> categories)
        {
            List<Category> results = new List<Category>();
            if (categories == null) return results;
            foreach (Category cat in categories)
            {
                FillAllSubCategories(ref results, cat);
                if (!results.Contains(cat)) results.Add(cat);
            }
            return results;
        }


        private void FillAllSubCategories(ref List<Category> results, Category category)
        {
            if (category == null) return;
            foreach (Category cat in category.SubCategories)
            {
                if (!results.Contains(cat)) results.Add(cat);
                FillAllSubCategories(ref results, cat);
            }
        }


        public List<Category> GetAllCategories()
        {
            List<Category> results = new List<Category>();
            FillAllSubCategories(ref results, this.RootCategory);
            return results;
        }


        public bool RemoveCategory(Category category)
        {
            int code = category.Code;
            Category parent = category.Parent;
            if (parent == null) return false;
            if (code == ROOT_CATEGORY || code == EXPENSES_CATEGORY ||
                code == INCOME_CATEGORY || code == NOT_FOR_CALC_CATEGORY) return false;
            return parent.RemoveSubCategory(code);
        }


        public bool RemoveCategory(int code)
        {
            Category category = this._rootCategory.GetSubCategory(code);
            if (category == null) return false;
            return RemoveCategory(category);
        }


        public bool IsCategoryCanHaveNewSubCategories(Category category)
        {
            return !category.Code.Equals(ROOT_CATEGORY) &&
                category.Level < Category.MaxLevel;
        }


        public bool IsCategoryCanBeRemoved(Category category)
        {
            return !category.Code.Equals(ROOT_CATEGORY) &&
                   !category.Code.Equals(EXPENSES_CATEGORY) &&
                   !category.Code.Equals(INCOME_CATEGORY) &&
                   !category.Code.Equals(NOT_FOR_CALC_CATEGORY);
        }


        protected void OnCategoriesLoaded(EventArgs e)
        {
            if (this.CategoriesLoaded != null) this.CategoriesLoaded(this, e);
        }


        protected void OnCategoriesSaved(EventArgs e)
        {
            if (this.CategoriesSaved != null) this.CategoriesSaved(this, e);
        }


        protected void OnCategoriesReset(EventArgs e)
        {
            if (this.CategoriesReset != null) this.CategoriesReset(this, e);
        }
    }
}
