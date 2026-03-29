using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Welcome.Model;
using Welcome.View;

namespace Welcome.ViewModel
{
    public class LoginViewModel
    {
        private UserLoginAttempt? _loginAttempt;
        private UserRepository _userRepository;

        public string UserNameText { get; set; }
        public string PasswordText { get; set; }

        public string ErrorMessage
        {
            get
            {
                if (_loginAttempt == null)
                    return "";
                return _loginAttempt.ErrorMessage;
            }
        }

        public LoginViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            UserNameText = "";
            PasswordText = "";
        }

        public void LoginExecute()
        {
            // Инициализираме loginAttempt
            _loginAttempt = new UserLoginAttempt(
                UserNameText, PasswordText, _userRepository);

            // Стъпка 1: Валидираме полетата
            if (!_loginAttempt.Validate())
                return;

            // Стъпка 2: Проверяваме credentials
            if (!_loginAttempt.AssertCredentials())
                return;

            // Стъпка 3: Вземаме потребителя
            User user = _loginAttempt.ExecuteLoginUser();

            // Стъпка 4: Обновяваме статуса
            _loginAttempt.PushLoggedInStatus();

            // Стъпка 5: Показваме данните
            UserViewModel userViewModel = new UserViewModel(user);
            MainWindow mainWindow = new MainWindow(userViewModel);
            mainWindow.DisplayUser();
            mainWindow.Show();
        }
    }
}