namespace _5._1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLine = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelTools = new System.Windows.Forms.Panel();
            this.panelColor = new System.Windows.Forms.Panel();
            this.btnColor = new System.Windows.Forms.Button();
            this.panelTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(10, 10);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(80, 30);
            this.btnLine.TabIndex = 0;
            this.btnLine.Text = "Линия";
            this.btnLine.UseVisualStyleBackColor = true;
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(100, 10);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(80, 30);
            this.btnCircle.TabIndex = 1;
            this.btnCircle.Text = "Круг";
            this.btnCircle.UseVisualStyleBackColor = true;
            // 
            // btnRectangle
            // 
            this.btnRectangle.Location = new System.Drawing.Point(190, 10);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(80, 30);
            this.btnRectangle.TabIndex = 2;
            this.btnRectangle.Text = "Квадрат";
            this.btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(370, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // panelTools
            // 
            this.panelTools.Controls.Add(this.btnColor);
            this.panelTools.Controls.Add(this.panelColor);
            this.panelTools.Controls.Add(this.btnLine);
            this.panelTools.Controls.Add(this.btnClear);
            this.panelTools.Controls.Add(this.btnCircle);
            this.panelTools.Controls.Add(this.btnRectangle);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTools.Location = new System.Drawing.Point(0, 0);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(800, 50);
            this.panelTools.TabIndex = 4;
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.Color.Black;
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor.Location = new System.Drawing.Point(290, 15);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(20, 20);
            this.panelColor.TabIndex = 4;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(280, 10);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(80, 30);
            this.btnColor.TabIndex = 5;
            this.btnColor.Text = "Цвет";
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelTools);
            this.Name = "Form1";
            this.Text = "Рисовалка";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Button btnColor;
    }
}