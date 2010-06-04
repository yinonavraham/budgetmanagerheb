using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetManager.Data;

namespace BudgetManager
{
    public delegate void CategoryEventHandler(Object sender, CategoryEventArgs e);


    public class CategoryEventArgs
    {
        private Category _category = null;


        public Category Category
        {
            get { return this._category; }
            set { this._category = value; }
        }
    }
}
