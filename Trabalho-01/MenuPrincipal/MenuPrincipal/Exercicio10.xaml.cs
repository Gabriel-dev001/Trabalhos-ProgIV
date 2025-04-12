using System;
using System.Windows;

namespace MenuPrincipal
{
    public partial class Exercicio10 : Window
    {
        private Random random = new Random();

        public Exercicio10()
        {
            InitializeComponent();
        }

        private void Sortear_Click(object sender, RoutedEventArgs e)
        {
            int numero = random.Next(1, 7); 
            string mensagem = numero == 6 ? "Você ganhou!" : "Tente novamente!";

            MessageBox.Show($"Número sorteado: {numero}\n{mensagem}", "Resultado");
        }

    }
}
