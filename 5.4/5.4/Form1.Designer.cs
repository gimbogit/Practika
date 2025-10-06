using System.Windows.Forms;

namespace _5._4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TrackBar trackBarZoom;
        private Label labelZoom;
        private Label labelImageInfo;
        private OpenFileDialog openFileDialog1;
        private Button buttonFitToScreen;
        private Button buttonOriginalSize;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.labelZoom = new System.Windows.Forms.Label();
            this.labelImageInfo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonFitToScreen = new System.Windows.Forms.Button();
            this.buttonOriginalSize = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();

            // menuStrip1
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // файлToolStripMenuItem
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";

            // открытьToolStripMenuItem
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);

            // выходToolStripMenuItem
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);

            // panel1
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 593);
            this.panel1.TabIndex = 1;

            // pictureBox1
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;

            // trackBarZoom
            this.trackBarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarZoom.LargeChange = 20;
            this.trackBarZoom.Location = new System.Drawing.Point(12, 575);
            this.trackBarZoom.Maximum = 500;
            this.trackBarZoom.Minimum = 10;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(200, 56);
            this.trackBarZoom.SmallChange = 10;
            this.trackBarZoom.TabIndex = 2;
            this.trackBarZoom.TickFrequency = 50;
            this.trackBarZoom.Value = 100;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);

            // labelZoom
            this.labelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(218, 575);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(52, 16);
            this.labelZoom.TabIndex = 3;
            this.labelZoom.Text = "100%";

            // labelImageInfo
            this.labelImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelImageInfo.AutoSize = true;
            this.labelImageInfo.Location = new System.Drawing.Point(800, 575);
            this.labelImageInfo.Name = "labelImageInfo";
            this.labelImageInfo.Size = new System.Drawing.Size(172, 16);
            this.labelImageInfo.TabIndex = 4;
            this.labelImageInfo.Text = "Изображение не загружено";

            // openFileDialog1
            this.openFileDialog1.Filter = "Изображения (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif|Все файлы (*.*)|*.*";
            this.openFileDialog1.Title = "Выберите изображение";

            // buttonFitToScreen
            this.buttonFitToScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFitToScreen.Location = new System.Drawing.Point(300, 570);
            this.buttonFitToScreen.Name = "buttonFitToScreen";
            this.buttonFitToScreen.Size = new System.Drawing.Size(120, 25);
            this.buttonFitToScreen.TabIndex = 5;
            this.buttonFitToScreen.Text = "По размеру";
            this.buttonFitToScreen.UseVisualStyleBackColor = true;
            this.buttonFitToScreen.Click += new System.EventHandler(this.buttonFitToScreen_Click);

            // buttonOriginalSize
            this.buttonOriginalSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOriginalSize.Location = new System.Drawing.Point(426, 570);
            this.buttonOriginalSize.Name = "buttonOriginalSize";
            this.buttonOriginalSize.Size = new System.Drawing.Size(120, 25);
            this.buttonOriginalSize.TabIndex = 6;
            this.buttonOriginalSize.Text = "Оригинал";
            this.buttonOriginalSize.UseVisualStyleBackColor = true;
            this.buttonOriginalSize.Click += new System.EventHandler(this.buttonOriginalSize_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.Controls.Add(this.buttonOriginalSize);
            this.Controls.Add(this.buttonFitToScreen);
            this.Controls.Add(this.labelImageInfo);
            this.Controls.Add(this.labelZoom);
            this.Controls.Add(this.trackBarZoom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Просмотр изображений";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}