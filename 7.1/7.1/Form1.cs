using System;
using System.Windows.Forms;

namespace _7._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboFrom.SelectedIndex = 0;
            comboTo.SelectedIndex = 1;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Введите корректное число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string from = comboFrom.SelectedItem.ToString();
            string to = comboTo.SelectedItem.ToString();

            decimal rate = GetExchangeRate(from, to);
            decimal result = amount * rate;

            lblResult.Text = $"{amount} {from} = {result:F2} {to}";
        }

        private decimal GetExchangeRate(string from, string to)
        {
            if (from == to) return 1m;

            // Пример фиксированных курсов (можно обновлять вручную)
            decimal usdToRub = 90m;
            decimal eurToRub = 95m;

            if (from == "RUB" && to == "USD") return 1 / usdToRub;
            if (from == "RUB" && to == "EUR") return 1 / eurToRub;
            if (from == "USD" && to == "RUB") return usdToRub;
            if (from == "EUR" && to == "RUB") return eurToRub;
            if (from == "USD" && to == "EUR") return usdToRub / eurToRub;
            if (from == "EUR" && to == "USD") return eurToRub / usdToRub;

            return 1m;
        }
    }
}
