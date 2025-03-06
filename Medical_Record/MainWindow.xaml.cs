using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medical_Record
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nome: {txtNome.Text}");
            sb.AppendLine($"Telefone: {txtTelefone.Text}");
            sb.AppendLine($"Data de Nascimento: {txtDataNascimento.Text}");
            sb.AppendLine($"Queixa: {txtMotivo.Text}");

            sb.AppendLine("Atitude:");
            if (chkCooperativo.IsChecked == true) sb.AppendLine("- Cooperativo");
            if (chkResistente.IsChecked == true) sb.AppendLine("- Resistente");
            if (chkIndiferente.IsChecked == true) sb.AppendLine("- Indiferente");

            MessageBox.Show(sb.ToString(), "Dados Salvos");
        }
    }
}
