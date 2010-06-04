using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.GUI.WinForms.Data
{
    public class ImportTransactionsSource
    {
        private String _sourceDllFilepath = null;
        private String _typeName = null;
        private String _name = null;
        private String _description = null;
        private String _assemblyFullName = null;


        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }


        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }


        public String SourceDllFilepath
        {
            get { return this._sourceDllFilepath; }
            set { this._sourceDllFilepath = value; }
        }


        public String TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }


        public String AssemblyFullName 
        {
            get { return this._assemblyFullName; }
            set { this._assemblyFullName = value; }  
        }


        public override string ToString()
        {
            return this._name;
        }


        public override bool Equals(object obj)
        {
            ImportTransactionsSource other = obj as ImportTransactionsSource;
            if (other == null) return false;
            else return this._typeName.Equals(other.TypeName);
        }
    }
}
