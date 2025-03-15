using Medical_Record.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Medical_Record
{
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //Resumindo essa função verifica se a senha digitada armazenada no banco é válida e se for, abre a MainWindow
            string password = PasswordBox.Password;

            using (UserContext context = new UserContext())
            {
                bool validPassword = context.Users.Any(user => user.Password == password);

                if (validPassword)
                {
                    GrantAccess();
                }
                else
                {
                    MessageBox.Show("Senha inválida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void GrantAccess()
        {

            MainWindow main = new MainWindow();
            main.Show(); // Abre o MainWindow
            Close(); // Fecha a tela de login
        }
    }
}
