using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetManager.GUI.WinForms.Controls
{
    public class DataGridViewDateCell : DataGridViewTextBoxCell
    {
        private readonly String DATE_FORMAT = @"dd/MM/yyyy";


        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return value != null ? 
                ( value is DateTime ? ((DateTime)value).ToString(DATE_FORMAT) : value.ToString() ) 
                : "";
        }


        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewDateControl);
            }
        }


        public override Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }


        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewDateControl ctrl = this.DataGridView.EditingControl as DataGridViewDateControl;
            if (ctrl == null) return;
            ctrl.Format = DateTimePickerFormat.Custom;
            ctrl.CustomFormat = DATE_FORMAT;
            ctrl.RightToLeftLayout = true;
            ctrl.MinDate = DateTime.MinValue;
            ctrl.MaxDate = DateTime.MaxValue;
            ctrl.Value = Convert.ToDateTime(initialFormattedValue);
        }
    }
}
