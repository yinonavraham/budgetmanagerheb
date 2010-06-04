using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BudgetManager.GUI.WinForms.Controls
{
    public class DataGridViewNumberCell : DataGridViewTextBoxCell
    {
        private bool _putNegativeNumberInBrackets = false;
        private Color _negativeNumberColor = Color.Red;
        private bool _isNegative = false;
        //private bool _useMinusSign = true;
        
        public DataGridViewNumberCell()
        {
            this.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        public Color NegativeNumberColor
        {
            get { return this._negativeNumberColor; }
            set { this._negativeNumberColor = value; }
        }


        public bool PutNegativeNumberInBrackets
        {
            get { return this._putNegativeNumberInBrackets; }
            set { this._putNegativeNumberInBrackets = value; }
        }


        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null) return 0;
            this._isNegative = false;
            if (value is int && (int)value < 0)
            {
                value = Math.Abs((int)value);
                this._isNegative = true;
            }
            else if (value is float && (float)value < 0)
            {
                value = Math.Abs((float)value);
                this._isNegative = true;
            }
            else if (value is double && (double)value < 0)
            {
                value = Math.Abs((double)value);
                this._isNegative = true;
            }
            else if (value is decimal && (decimal)value < 0) 
            {
                value = Math.Abs((decimal)value);
                this._isNegative = true;
            }
            else if (value is long && (long)value < 0)
            {
                value = Math.Abs((long)value);
                this._isNegative = true;
            }
            if (this._isNegative)
            {
                cellStyle.ForeColor = this._negativeNumberColor;
                //if (this._useMinusSign) return String.Format("-{0}", value);
                if (this._putNegativeNumberInBrackets) return String.Format("({0})", value);
            }
            return value.ToString();
            //return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }


        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewNumberControl);
            }
        }


        public override Type ValueType
        {
            get
            {
                return typeof(double);
            }
        }


        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewNumberControl ctrl = this.DataGridView.EditingControl as DataGridViewNumberControl;
            if (ctrl == null) return;
            ctrl.Minimum = decimal.MinValue;
            ctrl.Maximum = decimal.MaxValue;
            ctrl.RightToLeft = RightToLeft.No;
            ctrl.DecimalPlaces = 2;
            ctrl.UpDownAlign = LeftRightAlignment.Left;
            ctrl.Value = Convert.ToDecimal(initialFormattedValue);
            if (this._isNegative) ctrl.Value *= -1;
        }
    }
}
