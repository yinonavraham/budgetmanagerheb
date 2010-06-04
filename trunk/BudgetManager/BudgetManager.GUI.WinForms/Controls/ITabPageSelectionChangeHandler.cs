using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.GUI.WinForms.Controls
{
    interface ITabPageSelectionChangeHandler
    {
        void TabPageSelected();

        void TabPageDeselected();
    }
}
