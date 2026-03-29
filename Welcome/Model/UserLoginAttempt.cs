using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welcome.Model
{
    public class UserLoginAttempt
    {
        private string _usernameEntered;
        private string _passwordEntered;
        private int _attemptCount;
        private UserRepository _userRepository;

        public int AttemptCount
        {
            get { return _attemptCount; }
        }

        public string ErrorMessage { get; set; }

        public UserLoginAttempt(string usernameEntered, string passwordEntered, UserRepository userRepository)
        {
            _usernameEntered = usernameEntered;
            _passwordEntered = passwordEntered;
            _userRepository = userRepository;
            _attemptCount = 0;
            ErrorMessage = "";
        }

        // Проверява дали полетата са попълнени
        public bool Validate()
        {
            if (string.IsNullOrEmpty(_usernameEntered))
            {
                ErrorMessage = "Полето Потребителско име не може да е празно";
                return false;
            }
            if (string.IsNullOrEmpty(_passwordEntered))
            {
                ErrorMessage = "Полето Парола не може да е празно";
                return false;
            }
            return true;
        }

        // Проверява дали потребителят съществува
        public bool AssertCredentials()
        {
            _attemptCount++;
            bool isValid = _userRepository.ValidateUserLambda(
                _usernameEntered, _passwordEntered);

            if (!isValid)
            {
                ErrorMessage = "Грешно потребителско име или парола!";
                return false;
            }
            return true;
        }

        // Връща потребителя ако съществува
        public User ExecuteLoginUser()
        {
            var user = _userRepository.GetUserByNameAndPassword(
                _usernameEntered, _passwordEntered);

            if (user == null)
                throw new Exception("Потребителят не беше намерен!");

            return user;
        }

        // Обновява статуса на потребителя
        public void PushLoggedInStatus()
        {
            _userRepository.SetUserActive(
                _usernameEntered, DateTime.Now.AddDays(1));
        }
    }
}