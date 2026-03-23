using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Names
        {
            get { return _user.Names; }
            set { _user.Names = value; }
        }

        public string Email
        {
            get { return _user.Email[0] + "*****@*****.***"; }
        }

        public string FacultyNumber
        {
            get { return _user.FacultyNumber; }
            set { _user.FacultyNumber = value; }
        }

        public int Age
        {
            get { return _user.Age; }
            set { _user.Age = value; }
        }

        public string IsAdmin
        {
            get
            {
                if (_user.IsAdmin == true)
                    return "АДМИНИСТРАТОР";
                else
                    return "Обикновен потребител";
            }
        }

        public string IsBlocked
        {
            get
            {
                if (_user.IsBlocked == true)
                    return "⛔ БЛОКИРАН";
                else
                    return "✅ Активен";
            }
        }
    }
}
