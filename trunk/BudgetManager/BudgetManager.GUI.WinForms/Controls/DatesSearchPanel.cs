using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.GUI.WinForms.Controls
{
    public partial class DatesSearchPanel : UserControl
    {
        public DatesSearchPanel()
        {
            InitializeComponent();
        }

        public DateTime DateFrom
        {
            get { return this.fldFromDate.Value; }
            set { this.fldFromDate.Value = value; }
        }

        public DateTime DateTo
        {
            get { return this.fldToDate.Value; }
            set { this.fldToDate.Value = value; }
        }
    }
}
