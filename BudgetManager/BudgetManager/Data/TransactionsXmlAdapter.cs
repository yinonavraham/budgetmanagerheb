using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using BudgetManager.BusinessLayar;

namespace BudgetManager.Data
{
    /// <summary>
    /// Following is the stracture of the XML:
    /// <code>
    /// <Transactions>
    ///     <Transaction Date="..." DateForCalculation="..." Code="..." Description="..." Sum="..." Category="..." />
    /// </Transactions>
    /// </code>
    /// For the category attribute, only the category ID is stored.
    /// </summary>
    public class TransactionsXmlAdapter
    {
        private readonly String ROOT_ELEMENT = "Transactions";
        private readonly String TRANSACTION_ELEMENT = "Transaction";
        private readonly String DATE_FORMAT = "dd-MM-yyyy";

        private String _filepath = null;


        public TransactionsXmlAdapter(String filepath)
        {
            this._filepath = filepath;
        }


        public String Filepath
        {
            get { return this._filepath; }
            set { this._filepath = value; }
        }


        public void Save(List<CategorizedTransaction> transactions)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement(ROOT_ELEMENT);
            AppendXmlTransactions(doc, ref root, transactions);
            doc.AppendChild(root);
            doc.Save(this._filepath);
        }


        private void AppendXmlTransactions(XmlDocument doc, ref XmlElement root, List<CategorizedTransaction> transactions)
        {
            foreach (CategorizedTransaction transaction in transactions)
            {
                XmlElement element = GetXmlTransactionElement(doc, transaction);
                root.AppendChild(element);
            }
        }


        private XmlElement GetXmlTransactionElement(XmlDocument doc, CategorizedTransaction transaction)
        {
            XmlElement element = doc.CreateElement(TRANSACTION_ELEMENT);
            XmlAttribute attr = null;

            //Date
            attr = doc.CreateAttribute("Date");
            attr.Value = transaction.Date.Value.ToString(DATE_FORMAT);
            element.Attributes.Append(attr);
            //DateForCalculation
            attr = doc.CreateAttribute("DateForCalculation");
            attr.Value = transaction.DateForCalculation.Value.ToString(DATE_FORMAT);
            element.Attributes.Append(attr);
            //Code
            attr = doc.CreateAttribute("Code");
            attr.Value = transaction.Code.ToString();
            element.Attributes.Append(attr);
            //Description
            attr = doc.CreateAttribute("Description");
            attr.Value = transaction.Description;
            element.Attributes.Append(attr);
            //Sum
            attr = doc.CreateAttribute("Sum");
            attr.Value = transaction.Sum.ToString();
            element.Attributes.Append(attr);
            //Category
            attr = doc.CreateAttribute("Category");
            attr.Value = transaction.Category.Code.ToString();
            element.Attributes.Append(attr);

            return element;
        }


        public List<CategorizedTransaction> Load()
        {
            List<CategorizedTransaction> transactions = new List<CategorizedTransaction>();

            XmlDocument doc = new XmlDocument();
            doc.Load(this._filepath);
            XmlElement root = doc.DocumentElement;
            if (!root.Name.Equals("Transactions")) 
                throw new XmlException(
                    String.Format("Expected root element of the transactions XML is \"{0}\", not {1}",
                    ROOT_ELEMENT, root.Name));
            ReadXmlTransactions(root, ref transactions);

            return transactions;
        }


        private void ReadXmlTransactions(XmlElement parent, ref List<CategorizedTransaction> transactions)
        {
            if (parent == null) throw new XmlException("Parent element of the transactions is null");
            foreach (XmlElement element in parent.ChildNodes)
            {
                if (element.Name.Equals(TRANSACTION_ELEMENT))
                {
                    CategorizedTransaction t = ReadXmlTransaction(element);
                    if (t != null) transactions.Add(t);
                }
            }
        }


        private CategorizedTransaction ReadXmlTransaction(XmlElement element)
        {
            if (element == null) throw new XmlException("The transaction element is null");
            CategorizedTransaction transaction = new CategorizedTransaction();
            foreach (XmlAttribute attr in element.Attributes)
            {
                SetTransactionPropertyValue(ref transaction, attr.Name, attr.Value);
            }
            return transaction;
        }


        private void SetTransactionPropertyValue(ref CategorizedTransaction transaction, String propName, String propValue)
        {
            //PropertyInfo propInfo = transaction.GetType().GetProperty(propName);
            //if (propInfo == null || !propInfo.CanWrite) return;
            //MethodInfo setMethod = propInfo.GetSetMethod();
            //ParameterInfo[] paramsInfo = setMethod.GetParameters();
            //if (paramsInfo == null || paramsInfo.Length != 1) return;
            //ParameterInfo param = paramsInfo[0];
            //Type paramType = param.ParameterType;
            switch (propName)
            {
                case "Date":
                    transaction.Date = Convert.ToDateTime(propValue);
                    break;
                case "DateForCalculation":
                    transaction.DateForCalculation = Convert.ToDateTime(propValue);
                    break;
                case "Code":
                    transaction.Code = int.Parse(propValue);
                    break;
                case "Description":
                    transaction.Description = propValue;
                    break;
                case "Sum":
                    transaction.Sum = Convert.ToDouble(propValue);
                    break;
                case "Category":
                    int categoryCode = int.Parse(propValue);
                    Category category = CategoriesManager.Instance.RootCategory.GetSubCategory(categoryCode);
                    transaction.Category = category;
                    break;
            }
        }
    }
}
