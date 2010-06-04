using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.Adapters
{
    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class NameAttribute : Attribute
    {
        readonly String _name;

        // This is a positional argument
        public NameAttribute(String name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return this._name; }
        }
    }
}
