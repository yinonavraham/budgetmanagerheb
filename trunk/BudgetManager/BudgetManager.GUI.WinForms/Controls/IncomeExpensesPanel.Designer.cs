namespace BudgetManager.GUI.WinForms.Controls
{
    partial class IncomeExpensesPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlMaster = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.fldYear = new System.Windows.Forms.ComboBox();
            this.chartIncomeExpenses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlMaster.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncomeExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMaster
            // 
            this.pnlMaster.ColumnCount = 1;
            this.pnlMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMaster.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.pnlMaster.Controls.Add(this.chartIncomeExpenses, 0, 1);
            this.pnlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMaster.Location = new System.Drawing.Point(0, 0);
            this.pnlMaster.Name = "pnlMaster";
            this.pnlMaster.RowCount = 2;
            this.pnlMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMaster.Size = new System.Drawing.Size(709, 466);
            this.pnlMaster.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.fldYear);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(709, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(678, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "שנה";
            // 
            // fldYear
            // 
            this.fldYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fldYear.FormattingEnabled = true;
            this.fldYear.Location = new System.Drawing.Point(606, 3);
            this.fldYear.Name = "fldYear";
            this.fldYear.Size = new System.Drawing.Size(66, 21);
            this.fldYear.TabIndex = 3;
            this.fldYear.SelectedIndexChanged += new System.EventHandler(this.fldYear_SelectedIndexChanged);
            // 
            // chartIncomeExpenses
            // 
            chartArea1.Name = "ChartArea1";
            this.chartIncomeExpenses.ChartAreas.Add(chartArea1);
            this.chartIncomeExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartIncomeExpenses.Legends.Add(legend1);
            this.chartIncomeExpenses.Location = new System.Drawing.Point(3, 31);
            this.chartIncomeExpenses.Name = "chartIncomeExpenses";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartIncomeExpenses.Series.Add(series1);
            this.chartIncomeExpenses.Size = new System.Drawing.Size(703, 432);
            this.chartIncomeExpenses.TabIndex = 1;
            this.chartIncomeExpenses.Text = "הכנסות מול הוצאות";
            this.chartIncomeExpenses.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chartIncomeExpenses_GetToolTipText);
            // 
            // IncomeExpensesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMaster);
            this.Name = "IncomeExpensesPanel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(709, 466);
            this.pnlMaster.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncomeExpenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMaster;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fldYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIncomeExpenses;
    }
}
