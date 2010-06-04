using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.Data
{
    public class CategoryNotValidException : Exception
    {
        private Category _category = null;

        public CategoryNotValidException(String message, Category category) : base(message)
        {
            this._category = category;
        }

        public Category Category
        {
            get { return this._category; }
        }
    }
}
