namespace BudgetManager.Adapters.BankHapoalim
{
    partial class YearPickerPopup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fldYear = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fldYear)).BeginInit();
            this.SuspendLayout();
            // 
            // fldYear
            // 
            this.fldYear.Location = new System.Drawing.Point(12, 11);
            this.fldYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.fldYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.fldYear.Name = "fldYear";
            this.fldYear.Size = new System.Drawing.Size(120, 20);
            this.fldYear.TabIndex = 0;
            this.fldYear.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(35, 37);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "אישור";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // YearPickerPopup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(144, 70);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.fldYear);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(160, 106);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(160, 106);
            this.Name = "YearPickerPopup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "בחר שנה";
            ((System.ComponentModel.ISupportInitialize)(this.fldYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown fldYear;
        private System.Windows.Forms.Button btnOK;
    }
}