using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetManager.Data;

namespace BudgetManager.BusinessLayar
{
    public class TransactionNotValidException : Exception
    {
        private CategorizedTransaction _transaction = null;


        public TransactionNotValidException(CategorizedTransaction transaction)
            : base()
        {
            this._transaction = transaction;
        }


        public TransactionNotValidException(CategorizedTransaction transaction, String message)
            : base(message)
        {
            this._transaction = transaction;
        }


        public CategorizedTransaction Transaction
        {
            get { return this._transaction; }
        }
    }
}
