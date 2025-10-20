namespace _7._1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox comboFrom;
        private System.Windows.Forms.ComboBox comboTo;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.comboFrom = new System.Windows.Forms.ComboBox();
            this.comboTo = new System.Windows.Forms.ComboBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите сумму:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(180, 37);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 22);
            this.txtAmount.TabIndex = 1;
            // 
            // comboFrom
            // 
            this.comboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFrom.FormattingEnabled = true;
            this.comboFrom.Items.AddRange(new object[] {
            "RUB",
            "USD",
            "EUR"});
            this.comboFrom.Location = new System.Drawing.Point(40, 80);
            this.comboFrom.Name = "comboFrom";
            this.comboFrom.Size = new System.Drawing.Size(120, 24);
            this.comboFrom.TabIndex = 2;
            // 
            // comboTo
            // 
            this.comboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTo.FormattingEnabled = true;
            this.comboTo.Items.AddRange(new object[] {
            "RUB",
            "USD",
            "EUR"});
            this.comboTo.Location = new System.Drawing.Point(210, 80);
            this.comboTo.Name = "comboTo";
            this.comboTo.Size = new System.Drawing.Size(120, 24);
            this.comboTo.TabIndex = 3;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(40, 130);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(290, 35);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Конвертировать";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(40, 190);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 20);
            this.lblResult.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 260);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.comboTo);
            this.Controls.Add(this.comboFrom);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Конвертер валют";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
