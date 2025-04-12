using System;
using System.Windows;

namespace MenuPrincipal
{
    public partial class Exercicio9 : Window
    {
        private bool ligado = false;

        public Exercicio9()
        {
            InitializeComponent();
        }

        private void AlternarEstado_Click(object sender, RoutedEventArgs e)
        {
            ligado ^= true; // Alterna o valor de 'ligado'

            MessageBox.Show($"O estado atual é: {(ligado ? "Ligado" : "Desligado")}", "Interruptor");
        }

    }
}
