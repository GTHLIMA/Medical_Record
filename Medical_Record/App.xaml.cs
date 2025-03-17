using System.Configuration;
using System.Data;
using System.Windows;
using Medical_Record.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Medical_Record;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    // This ensures that the user table in the database is created if it does not exist
    protected override void OnStartup(StartupEventArgs e)
    {
        using (var userContext = new UserContext())
        {
            userContext.Database.EnsureCreated();
        }

        using (var patientContext = new PatientContext())
        {
            patientContext.Database.EnsureCreated();
        }
    }


}

