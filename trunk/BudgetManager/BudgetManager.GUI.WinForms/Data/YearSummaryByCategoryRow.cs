using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.GUI.WinForms.Data
{
    public class YearSummaryByCategoryRow
    {
        private const int N = 12;

        private static bool __ignoreNullsForCalc = true;


        public static bool IgnoreNullsForCalculation
        {
            get { return __ignoreNullsForCalc; }
            set { __ignoreNullsForCalc = value; }
        }


        public String Category { get; set; }
        private double?[] _month = new double?[N];


        public YearSummaryByCategoryRow() { }


        public YearSummaryByCategoryRow(String category, double?[] monthSum)
        {
            Category = category;
            for (int i = 0; i < monthSum.Length && i < N; i++)
            {
                this._month[i] = monthSum[i];
            }
        }


        public double? Month1 
        {
            get { return this._month[0]; }
            set { this._month[0] = value; }
        }


        public double? Month2
        {
            get { return this._month[1]; }
            set { this._month[1] = value; }
        }


        public double? Month3
        {
            get { return this._month[2]; }
            set { this._month[2] = value; }
        }


        public double? Month4
        {
            get { return this._month[3]; }
            set { this._month[3] = value; }
        }


        public double? Month5
        {
            get { return this._month[4]; }
            set { this._month[4] = value; }
        }


        public double? Month6
        {
            get { return this._month[5]; }
            set { this._month[5] = value; }
        }


        public double? Month7
        {
            get { return this._month[6]; }
            set { this._month[6] = value; }
        }


        public double? Month8
        {
            get { return this._month[7]; }
            set { this._month[7] = value; }
        }


        public double? Month9
        {
            get { return this._month[8]; }
            set { this._month[8] = value; }
        }


        public double? Month10
        {
            get { return this._month[9]; }
            set { this._month[9] = value; }
        }


        public double? Month11
        {
            get { return this._month[10]; }
            set { this._month[10] = value; }
        }


        public double? Month12
        {
            get { return this._month[11]; }
            set { this._month[11] = value; }
        }


        public int NumberOfMonths
        {
            get { return N; }
        }


        public double? this[int index]
        {
            get { return this._month[index]; }
            set { this._month[index] = value; }
        }
        
        
        public double Sum
        {
            get { return CalcSum(); }
        }


        public double Avg 
        {
            get { return CalcAvg(); }
        }


        private double CalcAvg()
        {
            int count = 0;
            double sum = 0;
            if (__ignoreNullsForCalc)
            {
                foreach (double? monthSum in this._month)
                {
                    sum += monthSum == null ? 0.0 : monthSum.Value;
                    count += monthSum == null ? 0 : 1;
                }
            }
            else
            {
                count = N;
            }
            return count == 0 ? 0 : (sum / count);
        }


        private double CalcSum()
        {
            double sum = 0;
            foreach (double? monthSum in this._month)
            {
                sum += monthSum == null ? 0.0 : monthSum.Value;
            }
            return sum;
        }
    }
}
