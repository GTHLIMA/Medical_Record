using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Medical_Record.Models;

namespace Medical_Record
{
    public partial class MainWindow : Window
    {
        private readonly MedicalRecordContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new MedicalRecordContext();
            _context.Database.EnsureCreated();
            LoadPacientes(); // Load patients on startup
        }

        private void OnMenuItemClicked(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string content = button.Content.ToString();
                switch (content)
                {
                    case "Pacientes":
                        LoadPacientes(); // Refresh patient list
                        break;
                    case "Sair":
                        Application.Current.Shutdown(); // Close the application
                        break;
                }
            }
        }

        private void LoadPacientes()
        {
            PacientesListView.ItemsSource = _context.Pacientes
                                                    .AsNoTracking()
                                                    .ToList(); // Use Paciente directly
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
            try
            {
                string nome = NomeTextBox.Text;
                string email = EmailTextBox.Text;
                if (!int.TryParse(IdadeTextBox.Text, out int idade) || idade <= 0)
                {
                    MessageBox.Show("Por favor, insira uma idade válida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string telefone = TelefoneTextBox.Text;
                string sexo = SexoTextBox.Text;

                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone))
                {
                    MessageBox.Show("Nome e Telefone são obrigatórios.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                AddPaciente(nome, email, idade, telefone, sexo);

                // Clear form
                NomeTextBox.Text = "";
                EmailTextBox.Text = "";
                IdadeTextBox.Text = "";
                TelefoneTextBox.Text = "";
                SexoTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar paciente: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnDeletePacienteClicked(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Paciente selected)
            {
                int id = selected.Id_Paciente;
                string nome = selected.Nome;

                var result = MessageBox.Show($"Deseja realmente excluir o paciente {nome}?",
                                             "Confirmar Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DeletePaciente(id);
                    LoadPacientes();
                }
            }
            else
            {
                MessageBox.Show("Selecione um paciente para excluir.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
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