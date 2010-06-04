using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BudgetManager.GUI.WinForms.Data
{
    public class HeaderColorScheme
    {
        public Color Header1_ForeColor { get; set; }
        public Color Header1_BackColor { get; set; }

        public Color Header2_ForeColor { get; set; }
        public Color Header2_BackColor { get; set; }

        public Color Header3_ForeColor { get; set; }
        public Color Header3_BackColor { get; set; }


        public HeaderColorScheme() { }


        public HeaderColorScheme(
            Color h1ForeColor, Color h1BackColor,
            Color h2ForeColor, Color h2BackColor, 
            Color h3ForeColor, Color h3BackColor ) 
        {
            Header1_ForeColor = h1ForeColor;
            Header1_BackColor = h1BackColor;

            Header2_ForeColor = h2ForeColor;
            Header2_BackColor = h2BackColor;

            Header3_ForeColor = h3ForeColor;
            Header3_BackColor = h3BackColor;
        }
    }
}
