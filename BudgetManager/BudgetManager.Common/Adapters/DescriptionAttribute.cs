using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.Adapters
{
    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DescriptionAttribute : Attribute
    {
        readonly String _desc;

        // This is a positional argument
        public DescriptionAttribute(String description)
        {
            this._desc = description;
        }

        public string Description
        {
            get { return this._desc; }
        }
    }
}
