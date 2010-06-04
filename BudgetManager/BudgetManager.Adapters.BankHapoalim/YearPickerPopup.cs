using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.Adapters.BankHapoalim
{
    public partial class YearPickerPopup : Form
    {
        public YearPickerPopup()
        {
            InitializeComponent();
            this.fldYear.Value = DateTime.Today.Year;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        public int SelectedYear
        {
            get { return (int)this.fldYear.Value; }
        }
    }
}
