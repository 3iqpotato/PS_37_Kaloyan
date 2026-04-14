using System.Windows;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Създаваме UserRepositoryDb (работи с база данни)
            UserRepositoryDb repository = new UserRepositoryDb();

            // Създава базата данни и таблиците (ако не съществуват)
            repository.CreatedDatabase();

            // Създаваме LoginViewModel и LoginWindow
            LoginViewModel loginViewModel = new LoginViewModel(repository);
            LoginWindow loginWindow = new LoginWindow(loginViewModel);
            loginWindow.Show();
        }
    }
}