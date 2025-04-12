using System;
using System.Windows;

namespace MenuPrincipal
{
    public enum DiasDaSemana
    {
        Domingo,
        Segunda,
        Terca,
        Quarta,
        Quinta,
        Sexta,
        Sabado
    }

    public partial class Exercicio8 : Window
    {
        public Exercicio8()
        {
            InitializeComponent();
        }

        private void Verificar_Click(object sender, RoutedEventArgs e)
        {
            if (!dateSelecionada.SelectedDate.HasValue)
            {
                MessageBox.Show("Por favor, selecione uma data.", "Erro");
                return;
            }

            DateTime data = dateSelecionada.SelectedDate.Value;
            string diaSemana = data.ToString("dddd", new System.Globalization.CultureInfo("pt-BR"));

            MessageBox.Show($"O dia da semana é: {diaSemana}", "Resultado");
        }

    }
}
