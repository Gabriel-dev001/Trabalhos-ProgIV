using System;
using System.Windows;

namespace MenuPrincipal
{
 
    public partial class Exercicio1 : Window
    {
        public Exercicio1()
        {
            InitializeComponent();
        }

        private void Somar_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtNumero1.Text, out int numero1) && int.TryParse(txtNumero2.Text, out int numero2))
            {
                int resultado = numero1 + numero2;
                MessageBox.Show($"A soma é: {resultado}", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Por favor, digite dois números inteiros válidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
