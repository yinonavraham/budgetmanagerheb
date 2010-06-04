using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetManager.Adapters;
using BudgetManager.Adapters.BankHapoalim;
using BudgetManager.Adapters.LeumiCard;
using BudgetManager.Data;
using BudgetManager.BusinessLayar;

namespace BudgetManager.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransactionsImportAdapter adapter = null;
            //adapter = new BankHapoalimAdapter();
            adapter = new LeumiCardExcelAdapter();
            //String filepath = @"c:\temp\poalwwwc.xls";
            String filepath = @"C:\Temp\Transaction Sources\2010Feb-LeumiCard.xls";
            List<TransactionRow> transactions = adapter.ImportTransactions(filepath);
            System.Console.WriteLine("Number of transactions imported: {0}", transactions.Count);
            foreach (TransactionRow transaction in transactions)
            {
                System.Console.WriteLine(transaction);
            }
            /*
            try
            {
                Category root = new Category(0, "Root");
                root.AddSubCategory(null, "Cat1");
                root.AddSubCategory(null, "Cat2");
                root.AddSubCategory(null, "Cat3");
                root.AddSubCategory(null, "Cat4");
                root.GetSubCategory(2).AddSubCategory(null, "Cat2 A");
                root.GetSubCategory(2).AddSubCategory(null, "Cat2 B");
                root.GetSubCategory(3).AddSubCategory(null, "Cat3 A");
                root.GetSubCategory(3).AddSubCategory(null, "Cat3 B");
                root.GetSubCategory(3).AddSubCategory(null, "Cat3 C");
                PrintCategories(root);
                TransactionsManager tManager = TransactionsManager.Instance;
                int i = 0;
                foreach (TransactionRow row in transactions)
                {
                    CategorizedTransaction ct = new CategorizedTransaction(row,root.GetSubCategory(i % 9 + 1));
                    tManager.AddTransaction(ct);
                    i++;
                    System.Console.WriteLine(ct);
                }
                System.Console.WriteLine("Total sum: {0}", tManager.CalculateSum(root.GetSubCategory(7),new DateTime(2009,1,1),new DateTime(2010,12,31)));
            }
            catch (CategoryNotValidException e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.Category);
            }
            */
        }

        private static void PrintCategories(Category cat)
        {
            if (cat == null) return;
            System.Console.WriteLine("{0}",cat.QualifiedName);
            foreach (Category sub in cat.SubCategories)
                PrintCategories(sub);
        }
    }
}
