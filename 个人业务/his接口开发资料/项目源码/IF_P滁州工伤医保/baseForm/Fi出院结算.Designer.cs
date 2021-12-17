namespace IF_P安徽医保.baseForm
{
    partial class Fi出院结算
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
            this.chk帐户使用标志 = new System.Windows.Forms.CheckBox();
            this.cb个人结算方式 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chk中途结算标志 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chk帐户使用标志
            // 
            this.chk帐户使用标志.AutoSize = true;
            this.chk帐户使用标志.Location = new System.Drawing.Point(305, 24);
            this.chk帐户使用标志.Name = "chk帐户使用标志";
            this.chk帐户使用标志.Size = new System.Drawing.Size(96, 16);
            this.chk帐户使用标志.TabIndex = 22;
            this.chk帐户使用标志.Text = "帐户使用标志";
            this.chk帐户使用标志.UseVisualStyleBackColor = true;
            // 
            // cb个人结算方式
            // 
            this.cb个人结算方式.FormattingEnabled = true;
            this.cb个人结算方式.Location = new System.Drawing.Point(111, 25);
            this.cb个人结算方式.Name = "cb个人结算方式";
            this.cb个人结算方式.Size = new System.Drawing.Size(169, 20);
            this.cb个人结算方式.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "个人结算方式:";
            // 
            // chk中途结算标志
            // 
            this.chk中途结算标志.AutoSize = true;
            this.chk中途结算标志.Location = new System.Drawing.Point(414, 24);
            this.chk中途结算标志.Name = "chk中途结算标志";
            this.chk中途结算标志.Size = new System.Drawing.Size(96, 16);
            this.chk中途结算标志.TabIndex = 23;
            this.chk中途结算标志.Text = "中途结算标志";
            this.chk中途结算标志.UseVisualStyleBackColor = true;
            // 
            // Fi出院结算
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 510);
            this.Controls.Add(this.chk中途结算标志);
            this.Controls.Add(this.chk帐户使用标志);
            this.Controls.Add(this.cb个人结算方式);
            this.Controls.Add(this.label3);
            this.Name = "Fi出院结算";
            this.Text = "Fi出院结算";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk帐户使用标志;
        private System.Windows.Forms.ComboBox cb个人结算方式;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk中途结算标志;
    }
}