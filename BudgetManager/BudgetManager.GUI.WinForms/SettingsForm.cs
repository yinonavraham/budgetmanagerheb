using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.GUI.WinForms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ApplySettings();
        }


        private void ApplySettings()
        {
            Properties.Settings.Default.CategoriesFilepath = this.fldCategoriesFilepath.Text;
            Properties.Settings.Default.IsLoadLastTransactionsFile = this.fldIsLoadLastTransactions.Checked;
        }


        private void btnBrowseCategoriesFilepath_Click(object sender, EventArgs e)
        {
            DialogResult result = this.browseCategoriesFileDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                this.fldCategoriesFilepath.Text = this.browseCategoriesFileDialog.FileName;
                this.toolTip.SetToolTip(this.fldCategoriesFilepath, this.fldCategoriesFilepath.Text);
            }
        }


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FillSettings();
        }


        private void FillSettings()
        {
            this.fldCategoriesFilepath.Text = Properties.Settings.Default.CategoriesFilepath;
            this.toolTip.SetToolTip(this.fldCategoriesFilepath, this.fldCategoriesFilepath.Text);
            this.fldIsLoadLastTransactions.Checked = Properties.Settings.Default.IsLoadLastTransactionsFile;
        }
    }
}
