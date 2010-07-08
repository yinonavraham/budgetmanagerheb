namespace BudgetManager.GUI.WinForms
{
    partial class Form1
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.fldColors = new System.Windows.Forms.ListBox();
            this.pnlColors = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Location = new System.Drawing.Point(12, 12);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(67, 63);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCenter.Location = new System.Drawing.Point(85, 12);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(67, 63);
            this.pnlCenter.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Location = new System.Drawing.Point(158, 12);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(67, 63);
            this.pnlRight.TabIndex = 1;
            // 
            // fldColors
            // 
            this.fldColors.FormattingEnabled = true;
            this.fldColors.Location = new System.Drawing.Point(12, 82);
            this.fldColors.Name = "fldColors";
            this.fldColors.Size = new System.Drawing.Size(120, 173);
            this.fldColors.TabIndex = 2;
            this.fldColors.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pnlColors
            // 
            this.pnlColors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColors.AutoScroll = true;
            this.pnlColors.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlColors.Location = new System.Drawing.Point(231, 12);
            this.pnlColors.Name = "pnlColors";
            this.pnlColors.Size = new System.Drawing.Size(345, 243);
            this.pnlColors.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(139, 82);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load Colors";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 264);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pnlColors);
            this.Controls.Add(this.fldColors);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ListBox fldColors;
        private System.Windows.Forms.FlowLayoutPanel pnlColors;
        private System.Windows.Forms.Button btnLoad;
    }
}