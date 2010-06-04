using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BudgetManager.GUI.WinForms.Data
{
    /// <summary>
    /// Following is the stracture of the XML:
    /// <code>
    /// <ImportTransactionsSources>
    ///     <Source Name=".." Type=".." DllFilepath=".." Assembly=".." Description=".."/>
    ///     <Source ...
    /// </ImportTransactionsSources>
    /// </code>
    /// </summary>
    class ImportTransactionsSourcesXmlAdapter
    {
        private readonly String ROOT_ELEMENT = "ImportTransactionsSources";
        private readonly String SOURCE_ELEMENT = "Source";

        private String _filepath = null;

        public ImportTransactionsSourcesXmlAdapter(String filepath) 
        {
            this._filepath = filepath;
        }


        public String Filepath
        {
            get { return this._filepath; }
            set { this._filepath = value; }
        }


        public void Save(List<ImportTransactionsSource> sources)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement(ROOT_ELEMENT);
            AppendXmlSources(doc, ref root, sources);
            doc.AppendChild(root);
            doc.Save(this._filepath);
        }


        private void AppendXmlSources(XmlDocument doc, ref XmlElement root, List<ImportTransactionsSource> sources)
        {
            if (sources == null) return;
            foreach (ImportTransactionsSource source in sources)
            {
                XmlElement element = doc.CreateElement(SOURCE_ELEMENT);

                XmlAttribute nameAttr = doc.CreateAttribute("Name");
                nameAttr.Value = source.Name;
                element.Attributes.Append(nameAttr);

                XmlAttribute typeAttr = doc.CreateAttribute("Type");
                typeAttr.Value = source.TypeName;
                element.Attributes.Append(typeAttr);

                XmlAttribute dllAttr = doc.CreateAttribute("DllFilepath");
                dllAttr.Value = source.SourceDllFilepath;
                element.Attributes.Append(dllAttr);

                XmlAttribute asmAttr = doc.CreateAttribute("Assembly");
                asmAttr.Value = source.AssemblyFullName;
                element.Attributes.Append(asmAttr);

                XmlAttribute descAttr = doc.CreateAttribute("Description");
                descAttr.Value = source.Description;
                element.Attributes.Append(descAttr);

                root.AppendChild(element);
            }
        }


        public List<ImportTransactionsSource> Load()
        {
            List<ImportTransactionsSource> sources = null;

            XmlDocument doc = new XmlDocument();
            doc.Load(this._filepath);
            XmlElement root = doc.DocumentElement;
            if (!root.Name.Equals(ROOT_ELEMENT))
                throw new XmlException(
                    String.Format("Expected root element of the import transactions sources XML is \"{0}\", not {1}",
                    ROOT_ELEMENT, root.Name));
            sources = ReadXmlSources(root.ChildNodes);

            return sources;
        }


        private List<ImportTransactionsSource> ReadXmlSources(XmlNodeList nodes)
        {
            if (nodes == null) return null;
            List<ImportTransactionsSource> sources = new List<ImportTransactionsSource>();
            foreach (XmlNode node in nodes)
            {
                ImportTransactionsSource source = ReadXmlSource(node);
                sources.Add(source);
            }
            return sources;
        }


        private ImportTransactionsSource ReadXmlSource(XmlNode node)
        {
            if (node == null) return null;
            if (!node.Name.Equals(SOURCE_ELEMENT))
                throw new XmlException(
                    String.Format("Expected import transaction source XML element is \"{0}\", not {1}",
                    SOURCE_ELEMENT, node.Name));
            ImportTransactionsSource source = new ImportTransactionsSource();
            
            XmlAttribute nameAttr = node.Attributes["Name"];
            source.Name = nameAttr.Value;

            XmlAttribute typeAttr = node.Attributes["Type"];
            source.TypeName = typeAttr.Value;

            XmlAttribute dllAttr = node.Attributes["DllFilepath"];
            source.SourceDllFilepath = dllAttr.Value;

            XmlAttribute asmAttr = node.Attributes["Assembly"];
            source.AssemblyFullName = asmAttr.Value;

            XmlAttribute descAttr = node.Attributes["Description"];
            source.Description = descAttr.Value;

            return source;
        }
    }
}
