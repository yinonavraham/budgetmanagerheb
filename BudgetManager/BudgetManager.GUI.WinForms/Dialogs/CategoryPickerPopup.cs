using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetManager.BusinessLayar;
using BudgetManager.Data;

namespace BudgetManager.GUI.WinForms.Dialogs
{
    public partial class CategoryPickerPopup : Form
    {
        public CategoryPickerPopup()
        {
            InitializeComponent();
        }


        public Category SelectedCategory
        {
            get { return this.treeView1.SelectedNode == null ? null : this.treeView1.SelectedNode.Tag as Category; }
        }


        private void CategoryPickerPopup_Load(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            Utilities.CommonMethods.AddCategoriesTreeFirstLevel(ref this.treeView1, CategoriesManager.Instance.ExpensesCategory);
            Utilities.CommonMethods.AddCategoriesTreeFirstLevel(ref this.treeView1, CategoriesManager.Instance.IncomeCategory);
            Utilities.CommonMethods.AddCategoriesTreeFirstLevel(ref this.treeView1, CategoriesManager.Instance.NotForCalculationCategory);
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            AcceptSelectedCategory();
        }


        private void AcceptSelectedCategory()
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
