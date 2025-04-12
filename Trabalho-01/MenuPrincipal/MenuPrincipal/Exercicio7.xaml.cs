using System;
using System.Windows;

namespace MenuPrincipal
{
    public partial class Exercicio7 : Window
    {
        public Exercicio7()
        {
            InitializeComponent();
         
            for (int i = 1; i <= 12; i++)
            {
                comboParcelas.Items.Add(i);
            }
            comboParcelas.SelectedIndex = 0;
        }

        private void Calcular_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtValorTotal.Text, out double valorTotal))
            {
                MessageBox.Show("Insira um valor numérico válido no campo Valor Total.", "Erro");
                return;
            }

            if (comboParcelas.SelectedItem is int parcelas && parcelas > 0)
            {
                double valorParcela = valorTotal / parcelas;
                MessageBox.Show($"Cada parcela será de R$ {valorParcela:F2}", "Resultado");
            }
            else
            {
                MessageBox.Show("Selecione um número válido de parcelas.", "Erro");
            }
        }

    }
}
