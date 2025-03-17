using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Medical_Record
{
    public partial class UserLogin : Window
    {
        static string[] Scopes = { DriveService.Scope.DriveAppdata }; // App folder access
        static string ApplicationName = "MedicalCare";

        public UserLogin()
        {
            InitializeComponent();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Authenticate Google Drive
                var driveService = await AuthenticateGoogleDriveAsync();

                // If authentication is successful, grant access and open the main window
                if (driveService != null)
                {
                    GrantAccess();
                }
                else
                {
                    MessageBox.Show("Authentication failed. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Authentication failed: {ex.Message}");
            }
        }
        public static async Task<DriveService?> AuthenticateGoogleDriveAsync()
        {
            UserCredential credential;

            try
            {
                // Load client secrets from a JSON file
                using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    // Authenticate the user without saving the token
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore("token.json", false)); // This creates a token.json file to store the token, change to false to disable
                }

                // Create the Drive API service
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                return service; // Return the DriveService instance if authentication is successful
            }
            catch (Exception)
            {
                return null; // Return null if authentication fails
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
