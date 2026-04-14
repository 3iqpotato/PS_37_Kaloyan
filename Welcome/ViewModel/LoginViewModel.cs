using Welcome.Loggers;
using Welcome.Model;
using Welcome.Others;
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
            _loginAttempt = new UserLoginAttempt(
                UserNameText, PasswordText, _userRepository);

            // Стъпка 1: Валидираме полетата
            if (!_loginAttempt.Validate())
            {
                FileLoggerHelper.LogFailure(UserNameText, _loginAttempt.ErrorMessage);
                return;
            }

            // Стъпка 2: Проверяваме credentials
            if (!_loginAttempt.AssertCredentials())
            {
                FileLoggerHelper.LogFailure(UserNameText, _loginAttempt.ErrorMessage);
                return;
            }

            // Стъпка 3: Вземаме потребителя
            User user = _loginAttempt.ExecuteLoginUser();

            // Стъпка 4: Обновяваме статуса
            _loginAttempt.PushLoggedInStatus();

            // Логваме успешния вход
            FileLoggerHelper.LogSuccess(UserNameText);

            // Стъпка 5: Показваме данните
            UserViewModel userViewModel = new UserViewModel(user);
            MainWindow mainWindow = new MainWindow(userViewModel);

            if (user.Role == UserRolesEnum.ADMIN)
            {
                AdminViewModel adminViewModel = new AdminViewModel();
                AdminWindow adminWindow = new AdminWindow(adminViewModel);
                adminWindow.Show();
            }
            else
            {
                mainWindow.DisplayUser();
                mainWindow.Show();
            }
        }
    }
}