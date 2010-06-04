using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.GUI.WinForms.Controls
{
    public class DataGridViewDateControl : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView _dgv = null;
        private int _rowIndex = -1;
        private bool _valueChanged = false;


        public DataGridViewDateControl()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = @"dd/MM/yyyy";
        }


        #region IDataGridViewEditingControl Members


        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.Font = dataGridViewCellStyle.Font;
            this.BackColor = dataGridViewCellStyle.BackColor;
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
                return this.Value.ToString(this.CustomFormat);
            }
            set
            {
                if (value is String) this.Value = DateTime.Parse((String)value);
                else if (value is DateTime) this.Value = (DateTime)value;
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


        protected override void OnValueChanged(EventArgs e)
        {
            this._valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(e);
        }
    }
}
