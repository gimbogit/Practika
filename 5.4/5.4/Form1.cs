using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._4
{
    public partial class Form1 : Form
    {
        private Image originalImage;
        private Size originalSize;

        public Form1()
        {
            InitializeComponent();
            UpdateZoomLabel();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Освобождаем предыдущее изображение
                    if (originalImage != null)
                    {
                        originalImage.Dispose();
                    }

                    // Загружаем новое изображение
                    originalImage = Image.FromFile(openFileDialog1.FileName);
                    originalSize = originalImage.Size;

                    // Отображаем информацию об изображении
                    DisplayImageInfo(openFileDialog1.FileName);

                    // Устанавливаем масштаб 100%
                    trackBarZoom.Value = 100;
                    ApplyZoom();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            ApplyZoom();
            UpdateZoomLabel();
        }

        private void buttonFitToScreen_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            // Вычисляем масштаб для подгонки под размер панели
            int panelWidth = panel1.ClientSize.Width - 20; // Отступы
            int panelHeight = panel1.ClientSize.Height - 20;

            double widthRatio = (double)panelWidth / originalSize.Width;
            double heightRatio = (double)panelHeight / originalSize.Height;

            double fitRatio = Math.Min(widthRatio, heightRatio);
            int zoomPercentage = (int)(fitRatio * 100);

            // Ограничиваем максимальный масштаб
            zoomPercentage = Math.Min(zoomPercentage, trackBarZoom.Maximum);
            zoomPercentage = Math.Max(zoomPercentage, trackBarZoom.Minimum);

            trackBarZoom.Value = zoomPercentage;
            ApplyZoom();
            UpdateZoomLabel();
        }

        private void buttonOriginalSize_Click(object sender, EventArgs e)
        {
            trackBarZoom.Value = 100;
            ApplyZoom();
            UpdateZoomLabel();
        }

        private void ApplyZoom()
        {
            if (originalImage == null) return;

            double zoomFactor = trackBarZoom.Value / 100.0;

            // Вычисляем новый размер
            int newWidth = (int)(originalSize.Width * zoomFactor);
            int newHeight = (int)(originalSize.Height * zoomFactor);

            // Создаем новое изображение с измененным размером
            Bitmap zoomedImage = new Bitmap(originalImage, newWidth, newHeight);

            // Устанавливаем новое изображение
            pictureBox1.Image = zoomedImage;
        }

        private void UpdateZoomLabel()
        {
            labelZoom.Text = $"{trackBarZoom.Value}%";
        }

        private void DisplayImageInfo(string filePath)
        {
            if (originalImage == null) return;

            FileInfo fileInfo = new FileInfo(filePath);
            string fileName = Path.GetFileName(filePath);
            string dimensions = $"{originalSize.Width} × {originalSize.Height}";
            string fileSize = FormatFileSize(fileInfo.Length);
            string format = originalImage.PixelFormat.ToString();

            labelImageInfo.Text = $"{fileName} | {dimensions} | {fileSize} | {format}";
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double len = bytes;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Освобождаем ресурсы изображения
            if (originalImage != null)
            {
                originalImage.Dispose();
            }
            if (pictureBox1.Image != null && pictureBox1.Image != originalImage)
            {
                pictureBox1.Image.Dispose();
            }
            base.OnFormClosing(e);
        }

        
    }
}