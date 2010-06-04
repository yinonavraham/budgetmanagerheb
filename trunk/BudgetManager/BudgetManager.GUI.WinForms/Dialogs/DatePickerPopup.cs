using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.GUI.WinForms.Dialogs
{
    public partial class DatePickerPopup : Form
    {
        public DatePickerPopup()
        {
            InitializeComponent();
        }


        public DateTime SelectedDate
        {
            get { return this.monthCalendar.SelectionStart; }
            set { this.monthCalendar.SelectionStart = value; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            AcceptSelectedDate();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

        }


        private void AcceptSelectedDate()
        {
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }
    }
}
