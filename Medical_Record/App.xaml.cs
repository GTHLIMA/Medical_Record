using System.Configuration;
using System.Data;
using System.Windows;
using Medical_Record.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Medical_Record;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    //Seguinte, isso garante que a tabela do banco chamada user seja criada caso não exista
    protected override void OnStartup(StartupEventArgs e)
    {
        DatabaseFacade facade = new DatabaseFacade(new UserContext());
        facade.EnsureCreated();
        
    }
}

