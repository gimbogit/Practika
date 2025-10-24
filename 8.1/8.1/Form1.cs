using System;
using System.IO;
using System.Windows.Forms;

namespace _8._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Открытие файла
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|RTF файлы (*.rtf)|*.rtf|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        // Сохранение файла
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|RTF файлы (*.rtf)|*.rtf|Все файлы (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                else
                    File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
            }
        }

        // Изменение шрифта
        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = richTextBox1.SelectionFont ?? richTextBox1.Font;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = fontDialog.Font;
                }
            }
        } 
    }
}
