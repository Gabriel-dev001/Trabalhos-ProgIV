using System;
using System.Reflection;
using System.Windows;

namespace MenuPrincipal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AbrirExercicio1_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio1();
            modal.Show();
        }

        private void AbrirExercicio2_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio2();
            modal.Show();
        }

        private void AbrirExercicio3_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio3();
            modal.Show();
        }

        private void AbrirExercicio4_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio4();
            modal.Show();
        }

        private void AbrirExercicio5_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio5();
            modal.Show();
        }

        private void AbrirExercicio6_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio6();
            modal.Show();
        }
        private void AbrirExercicio7_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio7();
            modal.Show();
        }
        private void AbrirExercicio8_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio8();
            modal.Show();
        }
        private void AbrirExercicio9_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio9();
            modal.Show();
        }
        private void AbrirExercicio10_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Exercicio10();
            modal.Show();
        }
    }
}
