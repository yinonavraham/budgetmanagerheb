using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetManager.Data;
using BudgetManager.BusinessLayar;

namespace BudgetManager.GUI.WinForms.Controls
{
    public class DataGridViewCategoryCell : DataGridViewTextBoxCell
    {
        
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewCategoryControl ctrl = this.DataGridView.EditingControl as DataGridViewCategoryControl;
            if (ctrl == null) return;
            ctrl.DropDownStyle = ComboBoxStyle.DropDownList;
            ctrl.FlatStyle = FlatStyle.Flat;
            ctrl.Items.Clear();
            List<Category> categories = CategoriesManager.Instance.GetAllCategories();
            DataGridViewCategoryControl.CategoryItem itemToSelect = null;
            Category catValue = this.Value as Category;
            foreach (Category cat in categories)
            {
                DataGridViewCategoryControl.CategoryItem item = new DataGridViewCategoryControl.CategoryItem(cat);
                ctrl.Items.Add(item);
                if (cat.Equals(catValue)) itemToSelect = item;
            }
            if (itemToSelect != null) ctrl.SelectedItem = itemToSelect;
        }


        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return value != null ?
                value is Category ? ((Category)value).Name : value.ToString()
                : "";
        }


        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewCategoryControl);
            }
        }


        public override Type ValueType
        {
            get
            {
                return typeof(Category);
            }
        }


        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.ComponentModel.TypeConverter valueTypeConverter)
        {
            //return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
            return formattedValue;
        }
    }
}
