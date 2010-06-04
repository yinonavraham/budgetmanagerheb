using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.GUI.WinForms.Controls
{
    public class DataGridViewDateColumn : DataGridViewColumn
    {
        public DataGridViewDateColumn()
            : base(new DataGridViewDateCell())
        {
        }


        public override object Clone()
        {
            // Clone the basic column
            DataGridViewDateColumn col = base.Clone() as DataGridViewDateColumn;
            // Set all the added properties of this type to the cloned column

            // Return the cloned column
            return col;
        }


        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value == null || !(value is DataGridViewDateCell))
                    throw new ArgumentException("Invalid cell type, a date column can only contain a date cell");
                base.CellTemplate = value;
            }
        }
    }
}
