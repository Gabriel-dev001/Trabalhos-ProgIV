using System;
using System.Windows;

namespace MenuPrincipal
{
    public partial class Exercicio4 : Window
    {
        public Exercicio4()
        {
            InitializeComponent();
        }

        private void Verificar_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtIdade.Text, out int idade))
            {
                string mensagem = idade >= 18 ? "Maior de idade" : "Menor de idade";
                MessageBox.Show(mensagem, "Resultado");
            }
            else
            {
                MessageBox.Show("Por favor, insira uma idade válida (número inteiro).", "Erro");
            }
        }
    }
}
