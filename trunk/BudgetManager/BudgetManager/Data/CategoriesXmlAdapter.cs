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
    /// <Categories>
    ///     <Category Code="..." Name="...">
    ///         <Category ...>
    ///             ...
    ///         </Category ...>
    ///         <Category ... />
    ///         <Category ... />
    ///         ...
    ///     </Category>
    /// </Categories>
    /// </code>
    /// </summary>
    public class CategoriesXmlAdapter
    {
        private readonly String ROOT_ELEMENT = "Categories";
        private readonly String CATEGORY_ELEMENT = "Category";

        private String _filepath = null;


        public CategoriesXmlAdapter(String filepath)
        {
            this._filepath = filepath;
        }


        public String Filepath
        {
            get { return this._filepath; }
            set { this._filepath = value; }
        }


        public void Save(Category rootCategory)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement(ROOT_ELEMENT);
            AppendXmlCategory(doc, ref root, rootCategory);
            doc.AppendChild(root);
            doc.Save(this._filepath);
        }


        private void AppendXmlCategory(XmlDocument doc, ref XmlElement parent, Category category)
        {
            if (category == null) return;
            XmlElement element = doc.CreateElement(CATEGORY_ELEMENT);

            XmlAttribute codeAttr = doc.CreateAttribute("Code");
            codeAttr.Value = category.Code.ToString();
            element.Attributes.Append(codeAttr);

            XmlAttribute nameAttr = doc.CreateAttribute("Name");
            nameAttr.Value = category.Name;
            element.Attributes.Append(nameAttr);

            foreach (Category c in category.SubCategories)
            {
                AppendXmlCategory(doc, ref element, c);
            }

            parent.AppendChild(element);
        }


        public Category Load()
        {
            Category rootCategory = null;

            XmlDocument doc = new XmlDocument();
            doc.Load(this._filepath);
            XmlElement root = doc.DocumentElement;
            if (!root.Name.Equals(ROOT_ELEMENT)) 
                throw new XmlException(
                    String.Format("Expected root element of the Categories XML is \"{0}\", not {1}",
                    ROOT_ELEMENT, root.Name));
            rootCategory = ReadXmlRootCategory(root.FirstChild);

            return rootCategory;
        }


        private Category ReadXmlRootCategory(XmlNode node)
        {
            if (node == null) return null;
            if (!node.Name.Equals(CATEGORY_ELEMENT)) 
                throw new XmlException(
                    String.Format("Expected category XML element is \"{0}\", not {1}",
                    CATEGORY_ELEMENT, node.Name));
            XmlAttribute codeAttr = node.Attributes["Code"];
            XmlAttribute nameAttr = node.Attributes["Name"];
            int code = int.Parse(codeAttr.Value);
            Category rootCategory = new Category(code, nameAttr.Value);
            ReadXmlSubCategories(node.ChildNodes, ref rootCategory);
            return rootCategory;
        }


        private void ReadXmlSubCategories(XmlNodeList childNodes, ref Category category)
        {
            if (childNodes == null) return;
            foreach (XmlNode node in childNodes)
            {
                if (!node.Name.Equals(CATEGORY_ELEMENT))
                    throw new XmlException(
                        String.Format("Expected category XML element is \"{0}\", not {1}",
                        CATEGORY_ELEMENT, node.Name));
                XmlAttribute codeAttr = node.Attributes["Code"];
                XmlAttribute nameAttr = node.Attributes["Name"];
                int code = int.Parse(codeAttr.Value);
                Category cat = category.AddSubCategory(code, nameAttr.Value);
                ReadXmlSubCategories(node.ChildNodes, ref cat);
            }
        }
    }
}
