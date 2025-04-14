using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Medical_Record.Data;

namespace Medical_Record
{
    public partial class MainWindow : Window
    {
        private readonly PatientContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new PatientContext();
            _context.Database.EnsureCreated();
        }

        private void OnMenuItemClicked(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.Content.ToString())
                {
                    case "Dashboard":
                        ShowDashboard();
                        break;
                    case "Pacientes":
                        ShowPacientes();
                        break;
                    case "Sair":
                        Application.Current.Shutdown();
                        break;
                }
            }
        }

        private void ShowDashboard()
        {
            MainContent.Content = new TextBlock { Text = "Dashboard", FontSize = 30 };
        }

        private void ShowPacientes()
        {
            PacientesView.Visibility = Visibility.Visible;
            MainContent.Content = PacientesView;
            LoadPacientes();
        }

        private void LoadPacientes()
        {
            PacientesListView.ItemsSource = _context.Pacientes
                                                    .AsNoTracking()
                                                    .Select(p => new
                                                    {
                                                        p.Id_Paciente,
                                                        p.Nome,
                                                        p.Idade,
                                                        p.Email,
                                                        p.Telefone,
                                                        p.Sexo
                                                    })
                                                    .ToList();
        }

        private void AddPaciente(string nome, string email, int idade, string telefone, string sexo)
        {
            var paciente = new Paciente
            {
                Nome = nome,
                Email = email,
                Idade = idade,
                Telefone = telefone,
                Sexo = sexo
            };

            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            LoadPacientes();
        }

        private void OnAdicionarPacienteClicked(object sender, RoutedEventArgs e)
        {
            string nome = NomeTextBox.Text;
            string email = EmailTextBox.Text;
            int idade = int.TryParse(IdadeTextBox.Text, out int result) ? result : 0;
            string telefone = TelefoneTextBox.Text;
            string sexo = SexoTextBox.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone))
            {
                MessageBox.Show("Preencha os campos obrigatórios.");
                return;
            }

            AddPaciente(nome, email, idade, telefone, sexo);
        }

        private void OnDeletePacienteClicked(object sender, RoutedEventArgs e)
        {
            dynamic selected = PacientesListView.SelectedItem;

            if (selected != null)
            {
                int id = selected.Id_Paciente;
                string nome = selected.Nome;

                var result = MessageBox.Show($"Deseja realmente excluir o paciente {nome}?",
                                             "Confirmar Exclusão", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    DeletePaciente(id);
                    LoadPacientes();
                }
            }
            else
            {
                MessageBox.Show("Selecione um paciente para excluir.");
            }
        }

        private void DeletePaciente(int patientId)
        {
            var paciente = _context.Pacientes.Find(patientId);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                _context.SaveChanges();
            }
        }
    }
}
