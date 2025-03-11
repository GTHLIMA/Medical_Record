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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnMenuItemClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
                switch (button.Content.ToString())
                {
                    case "Dashboard":
                        OpenWindow1(); // Hey bro, look at this <<< it's a new window! Awesome right?
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

        private void OpenWindow1()
        {
            Window1 window1 = new Window1(); //New window
            window1.Show(); //Show new awesome window
            //this.Close(); //Close previous window
        }

        private void ShowAgenda()
        {
            MainContent.Content = new TextBlock { Text = "Agenda", FontSize = 30 };
        }

        private void ShowPacientes()
        {
            MainContent.Content = new StackPanel
            {
                Children =
                {
                    new TextBlock { Text = "Pacientes", FontSize = 18, FontWeight = FontWeights.Bold },
                    new Button { Content = "Adicionar Paciente", Background = Brushes.Purple, Foreground = Brushes.White, HorizontalAlignment = HorizontalAlignment.Right, Padding = new Thickness(5), Margin = new Thickness(5) },
                    new ListView
                    {
                        ItemsSource = null,
                        View = new GridView
                        {
                            Columns =
                            {
                                new GridViewColumn { Header = "Nome", DisplayMemberBinding = new Binding("Nome"), Width = 200 },
                                new GridViewColumn { Header = "Email", DisplayMemberBinding = new Binding("Email"), Width = 200 },
                                new GridViewColumn { Header = "Idade", DisplayMemberBinding = new Binding("Idade"), Width = 100 },
                                new GridViewColumn { Header = "Telefone", DisplayMemberBinding = new Binding("Telefone"), Width = 150 },
                                new GridViewColumn { Header = "Consultas", DisplayMemberBinding = new Binding("Consultas"), Width = 100 }
                            }
                        }
                    }
                }
            };
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
    }
}