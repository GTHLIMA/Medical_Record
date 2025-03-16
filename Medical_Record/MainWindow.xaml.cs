using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Medical_Record
{
    public partial class MainWindow : Window
    {
        private SQLiteConnection? sqliteConn;
        private string dbPath = "Data Source=patients.db";

        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            sqliteConn = new SQLiteConnection(dbPath);
            sqliteConn.Open();

            // Create table IF IT DOESNT EXIST
            string createTableQuery = @"CREATE TABLE IF NOT EXISTS Pacientes (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Nome TEXT NOT NULL,
                                            Email TEXT,
                                            Idade INTEGER,
                                            Telefone TEXT,
                                            Consultas TEXT
                                          )"
            ;
            SQLiteCommand createTableCmd = new SQLiteCommand(createTableQuery, sqliteConn);
            createTableCmd.ExecuteNonQuery();
        }

        private void OnMenuItemClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
                switch (button.Content.ToString())
                {
                    case "Dashboard":
                        ShowDashboard();
                        break;
                    case "Agenda":
                        ShowAgenda();
                        break;
                    case "Pacientes":
                        ShowPacientes();
                        break;
                    case "Finanças":
                        ShowFinancas();
                        break;
                    case "Educação":
                        ShowEducacao();
                        break;
                    case "Suporte":
                        ShowSuporte();
                        break;
                    case "Configurações":
                        ShowConfiguracoes();
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

        private void ShowAgenda()
        {
            MainContent.Content = new TextBlock { Text = "Agenda", FontSize = 30 };
        }

        private void ShowPacientes()
        {
            PacientesView.Visibility = Visibility.Visible;
            MainContent.Content = PacientesView;

            LoadPacientes();
        }

        private void ShowFinancas()
        {
            MainContent.Content = new TextBlock { Text = "Finanças", FontSize = 30 };
        }

        private void ShowEducacao()
        {
            MainContent.Content = new TextBlock { Text = "Educação", FontSize = 30 };
        }

        private void ShowSuporte()
        {
            MainContent.Content = new TextBlock { Text = "Suporte", FontSize = 30 };
        }

        private void ShowConfiguracoes()
        {
            MainContent.Content = new TextBlock { Text = "Configurações", FontSize = 30 };
        }

        private void LoadPacientes()
        {
            string query = "SELECT * FROM Pacientes";
            SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Patient> pacientes = new List<Patient>();
            while (reader.Read())
            {
                pacientes.Add(new Patient
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    Idade = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                    Telefone = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                    Consultas = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
                });
            }

            PacientesListView.ItemsSource = pacientes;
        }

        private void AddPaciente(string nome, string email, int idade, string telefone, string consultas)
        {
            string query = "INSERT INTO Pacientes (Nome, Email, Idade, Telefone, Consultas) VALUES (@Nome, @Email, @Idade, @Telefone, @Consultas)";
            SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Idade", idade);
            cmd.Parameters.AddWithValue("@Telefone", telefone);
            cmd.Parameters.AddWithValue("@Consultas", consultas);

            cmd.ExecuteNonQuery();

            LoadPacientes();
        }

        private void OnAdicionarPacienteClicked(object sender, RoutedEventArgs e)
        {
            string nome = NomeTextBox.Text;
            string email = EmailTextBox.Text;
            int idade = int.TryParse(IdadeTextBox.Text, out int result) ? result : 0;
            string telefone = TelefoneTextBox.Text;
            string consultas = ConsultasTextBox.Text;

            // Safety checks
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(telefone))
            {
                MessageBox.Show("Nome and Telefone are required fields.");
                return;
            }

            AddPaciente(nome, email, idade, telefone, consultas);
        }

        // Event handler for deleting a selected patient
        private void OnDeletePacienteClicked(object sender, RoutedEventArgs e)
        {
            // Get the selected patient from the ListView
            var selectedPatient = PacientesListView.SelectedItem as Patient;

            if (selectedPatient != null)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the patient {selectedPatient.Nome}?", //I'll change it to portuguese later
                                                          "Confirm Deletion", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    DeletePaciente(selectedPatient.Id);

                    // The more this is present throughout the code, the better
                    LoadPacientes();
                }
            }
            else
            {
                MessageBox.Show("Please select a patient to delete.");
            }
        }

        private void DeletePaciente(int patientId)
        {
            string query = "DELETE FROM Pacientes WHERE Id = @Id";
            SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn);
            cmd.Parameters.AddWithValue("@Id", patientId);

            cmd.ExecuteNonQuery();
        }

        public class Patient
        {
            public int Id { get; set; }
            public string? Nome { get; set; }
            public string? Email { get; set; }
            public int? Idade { get; set; }
            public string? Telefone { get; set; }
            public string? Consultas { get; set; }
        }
    }
}
