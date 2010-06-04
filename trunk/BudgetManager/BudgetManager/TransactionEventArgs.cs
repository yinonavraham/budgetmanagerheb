using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetManager.Data;

namespace BudgetManager
{
    public delegate void TransactionEventHandler(Object sender, TransactionEventArgs e);


    public class TransactionEventArgs : EventArgs
    {
        private CategorizedTransaction _transaction = null;


        public CategorizedTransaction Transaction
        {
            get { return this._transaction; }
            set { this._transaction = value; }
        }
    }
}
