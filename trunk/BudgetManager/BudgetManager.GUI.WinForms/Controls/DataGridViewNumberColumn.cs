using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.GUI.WinForms.Controls
{
    public class DataGridViewNumberColumn : DataGridViewColumn
    {
        public DataGridViewNumberColumn()
            : base(new DataGridViewNumberCell())
        {
        }


        public override object Clone()
        {
            // Clone the basic column
            DataGridViewNumberColumn col = base.Clone() as DataGridViewNumberColumn;
            // Set all the added properties of this type to the cloned column

            // Return the cloned column
            return col;
        }


        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value == null || !(value is DataGridViewNumberCell))
                    throw new ArgumentException("Invalid cell type, a numeric column can only contain a numeric cell");
                base.CellTemplate = value;
            }
        }
    }
}
