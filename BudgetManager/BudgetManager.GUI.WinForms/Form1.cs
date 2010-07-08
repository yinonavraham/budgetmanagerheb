using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace BudgetManager.GUI.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadColors();

            PropertyInfo[] properties = typeof(Color).GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                if (prop.PropertyType.Equals(typeof(Color)))
                {
                    this.fldColors.Items.Add(prop.Name);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String colorName = this.fldColors.SelectedItem as String;
            if (colorName == null) return;
            Color color = Color.FromName(colorName);
            this.pnlLeft.BackColor = Utilities.CommonMethods.GetDarkerColor(color);
            this.pnlCenter.BackColor = color;
            this.pnlRight.BackColor = Utilities.CommonMethods.GetLighterColor(color);
        }

        private void LoadColors()
        {
            this.pnlColors.Controls.Clear();
            StreamReader reader = File.OpenText(@"C:\Temp\Colors.txt");
            String line = null;
            while ((line = reader.ReadLine()) != null)
            {
                AddColorPanel(line.Trim());
            }
            reader.Close();
        }

        private void AddColorPanel(String colorName)
        {
            Color color = Color.FromName(colorName);
            Panel pnlColor = new FlowLayoutPanel();
            pnlColor.Size = new Size(250, 25);
            Label lblColor = new Label();
            lblColor.Text = colorName;
            lblColor.AutoSize = false;
            lblColor.Width = 70;
            pnlColor.Controls.Add(lblColor);
            Panel pnlLeft = new Panel();
            pnlLeft.Size = new Size(50, 25);
            pnlLeft.BackColor = Utilities.CommonMethods.GetDarkerColor(color);
            pnlColor.Controls.Add(pnlLeft);
            Panel pnlCenter = new Panel();
            pnlCenter.Size = new Size(50, 25);
            pnlCenter.BackColor = color;
            pnlColor.Controls.Add(pnlCenter);
            Panel pnlRight = new Panel();
            pnlRight.Size = new Size(50, 25);
            pnlRight.BackColor = Utilities.CommonMethods.GetLighterColor(color);
            pnlColor.Controls.Add(pnlRight);
            pnlColors.Controls.Add(pnlColor);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadColors();
        }
    }
}
