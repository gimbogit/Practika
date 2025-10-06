using System.Windows.Forms;

namespace _5._3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxTask;
        private Button buttonAdd;
        private ListBox listBoxTasks;
        private Button buttonDelete;
        private Button buttonMarkCompleted;
        private Label label1;
        private Label labelStats;

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
            this.textBoxTask = new TextBox();
            this.buttonAdd = new Button();
            this.listBoxTasks = new ListBox();
            this.buttonDelete = new Button();
            this.buttonMarkCompleted = new Button();
            this.label1 = new Label();
            this.labelStats = new Label();
            this.SuspendLayout();

            // textBoxTask
            this.textBoxTask.Location = new System.Drawing.Point(12, 40);
            this.textBoxTask.Name = "textBoxTask";
            this.textBoxTask.Size = new System.Drawing.Size(300, 22);
            this.textBoxTask.TabIndex = 0;
            this.textBoxTask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTask_KeyPress);

            // buttonAdd
            this.buttonAdd.Location = new System.Drawing.Point(318, 39);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 25);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            // listBoxTasks
            this.listBoxTasks.FormattingEnabled = true;
            this.listBoxTasks.ItemHeight = 16;
            this.listBoxTasks.Location = new System.Drawing.Point(12, 80);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(406, 292);
            this.listBoxTasks.TabIndex = 2;

            // buttonDelete
            this.buttonDelete.Location = new System.Drawing.Point(12, 385);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(120, 30);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            // buttonMarkCompleted
            this.buttonMarkCompleted.Location = new System.Drawing.Point(150, 385);
            this.buttonMarkCompleted.Name = "buttonMarkCompleted";
            this.buttonMarkCompleted.Size = new System.Drawing.Size(150, 30);
            this.buttonMarkCompleted.TabIndex = 4;
            this.buttonMarkCompleted.Text = "Отметить выполненной";
            this.buttonMarkCompleted.UseVisualStyleBackColor = true;
            this.buttonMarkCompleted.Click += new System.EventHandler(this.buttonMarkCompleted_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Новая задача:";

            // labelStats
            this.labelStats.AutoSize = true;
            this.labelStats.Location = new System.Drawing.Point(320, 392);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(98, 16);
            this.labelStats.TabIndex = 6;
            this.labelStats.Text = "Всего: 0";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 430);
            this.Controls.Add(this.labelStats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMarkCompleted);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listBoxTasks);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxTask);
            this.Name = "Form1";
            this.Text = "Учет задач";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}