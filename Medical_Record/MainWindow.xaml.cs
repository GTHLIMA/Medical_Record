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
using System.Collections.ObjectModel;

namespace Medical_Record
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Paciente> Pacientes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Pacientes = new ObservableCollection<Paciente>
            {
                new Paciente { Nome = "Ana Costa", Email = "anacosta@hotmail.com", Idade = 41, Telefone = "(22) 9 5029-3022", Consultas = 0 },
                new Paciente { Nome = "Júlia Ecker", Email = "julia_e@gmail.com", Idade = 23, Telefone = "(19) 8 0025-4764", Consultas = 0 },
                new Paciente { Nome = "Maria Silva", Email = "mariasilva@gmail.com", Idade = 34, Telefone = "(54) 9 2839-2839", Consultas = 0 },
                new Paciente { Nome = "Sandro Lima", Email = "sandrolima@terra.com", Idade = 50, Telefone = "(21) 9 9005-4367", Consultas = 0 }
            };
            DataContext = this;
        }
    }

    public class Paciente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public int Consultas { get; set; }
    }
}
