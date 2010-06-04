using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetManager.Data;

namespace BudgetManager.Adapters
{
    public interface ITransactionsImportAdapter
    {
        List<TransactionRow> ImportTransactions(String filepath);
    }
}
