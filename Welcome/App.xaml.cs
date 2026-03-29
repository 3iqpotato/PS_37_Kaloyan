using System.Configuration;
using System.Data;
using System.Windows;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Създаваме UserRepository
            UserRepository userRepository = new UserRepository();

            // Потребител 1 - от преди
            User user1 = new User();
            user1.Names = "Иван Иванов";
            user1.Email = "i.ivanov@gmail.com";
            user1.Password = "123456";
            user1.Role = UserRolesEnum.ADMIN;
            user1.FailedLoginAttempts = 0;
            user1.FacultyNumber = "F12345";
            user1.Age = 20;
            userRepository.AddUser(user1);

            // Потребител 2
            User user2 = new User();
            user2.Names = "Student2";
            user2.Password = "123";
            user2.Email = "student2@gmail.com";
            user2.Role = UserRolesEnum.STUDENT;
            userRepository.AddUser(user2);

            // Потребител 3
            User user3 = new User();
            user3.Names = "Teacher";
            user3.Password = "1234";
            user3.Email = "teacher@gmail.com";
            user3.Role = UserRolesEnum.PROFESSOR;
            userRepository.AddUser(user3);

            // Потребител 4
            User user4 = new User();
            user4.Names = "Admin";
            user4.Password = "12345";
            user4.Email = "admin@gmail.com";
            user4.Role = UserRolesEnum.ADMIN;
            userRepository.AddUser(user4);

            // Създаваме LoginViewModel и LoginWindow
            LoginViewModel loginViewModel = new LoginViewModel(userRepository);
            LoginWindow loginWindow = new LoginWindow(loginViewModel);
            loginWindow.Show();
        }
    }
}

