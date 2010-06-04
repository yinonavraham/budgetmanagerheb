using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetManager.Data;

namespace BudgetManager.GUI.WinForms.Controls
{
    public class DataGridViewCategoryControl : ComboBox, IDataGridViewEditingControl
    {
        public class CategoryItem
        {
            public CategoryItem(Category category)
            {
                this.Category = category;
            }

            public Category Category = null;

            public override string ToString()
            {
                if (Category == null) return "null";
                StringBuilder sb = new StringBuilder();
                int spaces = (this.Category.Level - 2) * 2;
                if (spaces > 0) sb.Append(' ', spaces + 2);
                sb.Append(' ', this.Category.Level - 1 > 0 ? 1 : 0);
                sb.Append('|', this.Category.Level - 1 > 0 ? 1 : 0);
                sb.Append('-', this.Category.Level - 1 > 0 ? 2 : 0);
                sb.Append(' ', this.Category.Level - 1 > 0 ? 1 : 0);
                sb.Append(this.Category.Name);
                return sb.ToString();
            }
        }


        private DataGridView _dgv = null;
        private int _rowIndex = -1;
        private bool _valueChanged = false;


        #region IDataGridViewEditingControl Members


        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
            this.Font = dataGridViewCellStyle.Font;
        }


        public DataGridView EditingControlDataGridView
        {
            get
            {
                return this._dgv;
            }
            set
            {
                this._dgv = value;
            }
        }


        public object EditingControlFormattedValue
        {
            get
            {
                return this.SelectedItem != null && this.SelectedItem is CategoryItem ? 
                    ((CategoryItem)this.SelectedItem).Category
                    : null;
            }
            set
            {
                //this.SelectedItem = value;
            }
        }


        public int EditingControlRowIndex
        {
            get
            {
                return this._rowIndex;
            }
            set
            {
                this._rowIndex = value;
            }
        }


        public bool EditingControlValueChanged
        {
            get
            {
                return this._valueChanged;
            }
            set
            {
                this._valueChanged = value;
            }
        }


        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return true;
        }


        public Cursor EditingPanelCursor
        {
            get { return this.Cursor; }
        }


        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }


        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }


        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }


        #endregion


        protected override void OnSelectedValueChanged(EventArgs e)
        {
            this._valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnSelectedValueChanged(e);
        }
    }
}
