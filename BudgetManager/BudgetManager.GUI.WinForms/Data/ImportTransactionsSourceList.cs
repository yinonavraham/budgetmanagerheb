using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.GUI.WinForms.Data
{
    public class ImportTransactionsSourceList
    {
        private List<ImportTransactionsSource> _sources = new List<ImportTransactionsSource>();


        public List<ImportTransactionsSource> Sources
        {
            get { return this._sources; }
        }


        public ImportTransactionsSource this[int index]
        {
            get { return _sources[index]; }
        }


        public int Count
        {
            get { return this._sources.Count; }
        }


        public void Add(ImportTransactionsSource source)
        {
            this._sources.Add(source);
        }


        public void Remove(ImportTransactionsSource source)
        {
            this._sources.Remove(source);
        }


        public void RemoveAt(int index)
        {
            this._sources.RemoveAt(index);
        }


        public void Clear()
        {
            this._sources.Clear();
        }


        public void Save(String filepath)
        {
            ImportTransactionsSourcesXmlAdapter adapter = new ImportTransactionsSourcesXmlAdapter(filepath);
            adapter.Save(this._sources);
        }


        public void Load(String filepath)
        {
            ImportTransactionsSourcesXmlAdapter adapter = new ImportTransactionsSourcesXmlAdapter(filepath);
            List<ImportTransactionsSource> sources = adapter.Load();
            this._sources.Clear();
            this._sources = sources;
        }
    }
}
