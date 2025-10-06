using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateStats();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedTask();
        }

        private void buttonMarkCompleted_Click(object sender, EventArgs e)
        {
            MarkTaskCompleted();
        }

        private void textBoxTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddTask();
                e.Handled = true;
            }
        }

        private void AddTask()
        {
            string taskText = textBoxTask.Text.Trim();

            if (!string.IsNullOrEmpty(taskText))
            {
                listBoxTasks.Items.Add(taskText);
                textBoxTask.Clear();
                textBoxTask.Focus();
                UpdateStats();
            }
            else
            {
                MessageBox.Show("Введите текст задачи!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteSelectedTask()
        {
            if (listBoxTasks.SelectedIndex != -1)
            {
                int selectedIndex = listBoxTasks.SelectedIndex;
                listBoxTasks.Items.RemoveAt(selectedIndex);

                // Выбираем следующий элемент или предыдущий, если это был последний
                if (listBoxTasks.Items.Count > 0)
                {
                    if (selectedIndex < listBoxTasks.Items.Count)
                    {
                        listBoxTasks.SelectedIndex = selectedIndex;
                    }
                    else
                    {
                        listBoxTasks.SelectedIndex = listBoxTasks.Items.Count - 1;
                    }
                }

                UpdateStats();
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MarkTaskCompleted()
        {
            if (listBoxTasks.SelectedIndex != -1)
            {
                int selectedIndex = listBoxTasks.SelectedIndex;
                string taskText = listBoxTasks.Items[selectedIndex].ToString();

                // Если задача еще не отмечена как выполненная
                if (!taskText.StartsWith("✓ "))
                {
                    listBoxTasks.Items[selectedIndex] = "✓ " + taskText;

                    // Перемещаем выполненную задачу в конец списка
                    object completedTask = listBoxTasks.Items[selectedIndex];
                    listBoxTasks.Items.RemoveAt(selectedIndex);
                    listBoxTasks.Items.Add(completedTask);

                    // Снимаем выделение
                    listBoxTasks.ClearSelected();
                }
                else
                {
                    MessageBox.Show("Эта задача уже отмечена как выполненная!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                UpdateStats();
            }
            else
            {
                MessageBox.Show("Выберите задачу для отметки!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateStats()
        {
            int totalTasks = listBoxTasks.Items.Count;
            int completedTasks = 0;

            foreach (var item in listBoxTasks.Items)
            {
                if (item.ToString().StartsWith("✓ "))
                {
                    completedTasks++;
                }
            }

            labelStats.Text = $"Всего: {totalTasks} | Выполнено: {completedTasks}";
        }
    }
}