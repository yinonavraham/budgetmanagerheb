namespace BudgetManager.GUI.WinForms.Controls
{
    partial class DatesSearchPanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.fldFromDate = new System.Windows.Forms.DateTimePicker();
            this.fldToDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblFromDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblToDate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.fldFromDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.fldToDate, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 25);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromDate.Location = new System.Drawing.Point(363, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(54, 26);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "מתאריך";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToDate.Location = new System.Drawing.Point(146, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(59, 26);
            this.lblToDate.TabIndex = 1;
            this.lblToDate.Text = "עד תאריך";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fldFromDate
            // 
            this.fldFromDate.CustomFormat = "dd MMMM yyyy";
            this.fldFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fldFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fldFromDate.Location = new System.Drawing.Point(221, 3);
            this.fldFromDate.Name = "fldFromDate";
            this.fldFromDate.Size = new System.Drawing.Size(136, 20);
            this.fldFromDate.TabIndex = 2;
            // 
            // fldToDate
            // 
            this.fldToDate.CustomFormat = "dd MMMM yyyy";
            this.fldToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fldToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fldToDate.Location = new System.Drawing.Point(3, 3);
            this.fldToDate.Name = "fldToDate";
            this.fldToDate.Size = new System.Drawing.Size(137, 20);
            this.fldToDate.TabIndex = 3;
            // 
            // DatesSearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(600, 25);
            this.MinimumSize = new System.Drawing.Size(350, 25);
            this.Name = "DatesSearchPanel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(420, 25);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker fldFromDate;
        private System.Windows.Forms.DateTimePicker fldToDate;
    }
}
