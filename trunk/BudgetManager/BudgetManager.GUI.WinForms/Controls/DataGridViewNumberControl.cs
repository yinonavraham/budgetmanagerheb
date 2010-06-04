using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.GUI.WinForms.Controls
{
    public class DataGridViewNumberControl : NumericUpDown, IDataGridViewEditingControl
    {
        private DataGridView _dgv = null;
        private int _rowIndex = -1;
        private bool _valueChanged = false;


        public DataGridViewNumberControl() { }


        #region IDataGridViewEditingControl Members


        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            //this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.Font = dataGridViewCellStyle.Font;
            this.BackColor = dataGridViewCellStyle.BackColor;
            switch (dataGridViewCellStyle.Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                case DataGridViewContentAlignment.MiddleCenter:
                case DataGridViewContentAlignment.TopCenter:
                    this.TextAlign = HorizontalAlignment.Center;
                    break;
                case DataGridViewContentAlignment.BottomLeft:
                case DataGridViewContentAlignment.MiddleLeft:
                case DataGridViewContentAlignment.TopLeft:
                    this.TextAlign = HorizontalAlignment.Left;
                    break;
                case DataGridViewContentAlignment.BottomRight:
                case DataGridViewContentAlignment.MiddleRight:
                case DataGridViewContentAlignment.TopRight:
                    this.TextAlign = HorizontalAlignment.Right;
                    break;
            }
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
                return this.Value.ToString();
            }
            set
            {
                if (value is String) this.Value = decimal.Parse((String)value);
                else if (value is decimal) this.Value = (decimal)value;
                else if (value is int) this.Value = Convert.ToDecimal((int)value);
                else if (value is long) this.Value = Convert.ToDecimal((long)value);
                else if (value is float) this.Value = Convert.ToDecimal((float)value);
                else if (value is double) this.Value = Convert.ToDecimal((double)value);
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
