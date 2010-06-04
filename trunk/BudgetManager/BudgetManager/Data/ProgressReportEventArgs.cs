using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.Data
{
    public delegate void ProgressReportEventHandler(Object sender, ProgressReportEventArgs args);


    public class ProgressReportEventArgs
    {
        private int _curIter = 0;
        private int _totIter = 0;

        public ProgressReportEventArgs(int currentIteration, int totalIterations)
        {
            this._curIter = currentIteration;
            this._totIter = totalIterations;
        }

        public int CurrentIteration
        {
            get { return this._curIter; }
        }

        public int TotalIterations
        {
            get { return this._totIter; }
        }

        public double Percentage
        {
            get { return (double)this._curIter / (double)this._totIter; }
        }
    }
}
