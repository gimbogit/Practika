using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._5
{
    public partial class Form1 : Form
    {
        private double currentValue = 0;
        private string currentOperation = "";
        private bool newOperation = true;
        private bool operationPressed = false;

        public Form1()
        {
            InitializeComponent();
            ClearCalculator();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Text;

            if (textBoxDisplay.Text == "0" || newOperation || operationPressed)
            {
                textBoxDisplay.Text = number;
                newOperation = false;
                operationPressed = false;
            }
            else
            {
                textBoxDisplay.Text += number;
            }
        }

        private void DecimalButton_Click(object sender, EventArgs e)
        {
            if (newOperation || operationPressed)
            {
                textBoxDisplay.Text = "0.";
                newOperation = false;
                operationPressed = false;
            }
            else if (!textBoxDisplay.Text.Contains("."))
            {
                textBoxDisplay.Text += ".";
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!operationPressed && !newOperation)
            {
                Calculate();
            }

            currentOperation = button.Text;
            currentValue = double.Parse(textBoxDisplay.Text);
            operationPressed = true;
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            Calculate();
            currentOperation = "";
            newOperation = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearCalculator();
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text.Length > 1)
            {
                textBoxDisplay.Text = textBoxDisplay.Text.Substring(0, textBoxDisplay.Text.Length - 1);
            }
            else
            {
                textBoxDisplay.Text = "0";
                newOperation = true;
            }
        }

        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text != "0")
            {
                if (textBoxDisplay.Text.StartsWith("-"))
                {
                    textBoxDisplay.Text = textBoxDisplay.Text.Substring(1);
                }
                else
                {
                    textBoxDisplay.Text = "-" + textBoxDisplay.Text;
                }
            }
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            double value = double.Parse(textBoxDisplay.Text);
            if (value >= 0)
            {
                textBoxDisplay.Text = Math.Sqrt(value).ToString();
                newOperation = true;
            }
            else
            {
                MessageBox.Show("Невозможно извлечь корень из отрицательного числа!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PercentButton_Click(object sender, EventArgs e)
        {
            double value = double.Parse(textBoxDisplay.Text);
            textBoxDisplay.Text = (value / 100).ToString();
            newOperation = true;
        }

        private void Calculate()
        {
            if (currentOperation == "" || operationPressed) return;

            double secondValue = double.Parse(textBoxDisplay.Text);
            double result = 0;

            try
            {
                switch (currentOperation)
                {
                    case "+":
                        result = currentValue + secondValue;
                        break;
                    case "-":
                        result = currentValue - secondValue;
                        break;
                    case "×":
                        result = currentValue * secondValue;
                        break;
                    case "/":
                        if (secondValue == 0)
                        {
                            MessageBox.Show("Деление на ноль невозможно!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        result = currentValue / secondValue;
                        break;
                }

                // Форматируем результат для удаления лишних нулей после запятой
                textBoxDisplay.Text = result.ToString().TrimEnd('0').TrimEnd('.');
                if (textBoxDisplay.Text == "") textBoxDisplay.Text = "0";

                currentValue = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка вычисления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCalculator()
        {
            textBoxDisplay.Text = "0";
            currentValue = 0;
            currentOperation = "";
            newOperation = true;
            operationPressed = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Дополнительная инициализация при загрузке формы
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}