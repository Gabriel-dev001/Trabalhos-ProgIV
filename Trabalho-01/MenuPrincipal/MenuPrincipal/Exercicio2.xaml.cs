using System;
using System.Windows;

namespace MenuPrincipal
{
    public partial class Exercicio2 : Window
    {
        public Exercicio2()
        {
            InitializeComponent();
        }

        private void Converter_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtCelsius.Text, out double celsius))
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                MessageBox.Show($"Temperatura em Fahrenheit: {fahrenheit:F2}", "Resultado");
            }
            else
            {
                MessageBox.Show("Por favor, insira um número válido para a temperatura.", "Erro de Entrada");
            }
        }
    }
}
