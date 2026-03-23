using System.Configuration;
using System.Data;
using System.Windows;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            User user = new User();
            user.Names = "Иван Иванов";
            user.Email = "i.ivanov@gmail.com";
            user.Password = "123456";
            user.Role = Welcome.Others.UserRolesEnum.ADMIN;
            user.FailedLoginAttempts = 0;
            user.FacultyNumber = "F12345";
            user.Age = 20;

            UserViewModel userViewModel = new UserViewModel(user);
            MainWindow mainWindow = new MainWindow(userViewModel);
            mainWindow.DisplayUser();
            mainWindow.Show();
        }
    }
}

