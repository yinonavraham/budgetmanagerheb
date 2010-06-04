using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.GUI.WinForms.Controls
{
    public class DataGridViewCategoryColumn : DataGridViewColumn
    {
        public DataGridViewCategoryColumn()
            : base(new DataGridViewCategoryCell())
        {
        }


        public override object Clone()
        {
            // Clone the basic column
            DataGridViewCategoryColumn col = base.Clone() as DataGridViewCategoryColumn;
            // Set all the added properties of this type to the cloned column

            // Return the cloned column
            return col;
        }


        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value == null || !(value is DataGridViewCategoryCell))
                    throw new ArgumentException("Invalid cell type, a category column can only contain a category cell");
                base.CellTemplate = value;
            }
        }
    }
}
