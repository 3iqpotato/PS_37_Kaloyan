using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private int _id;
        private string _names;
        private string _password;
        private string _email;
        private UserRolesEnum _role;
        private int _failedLoginAttempts;
        private string _facultyNumber;
        private int _age;
        private DateTime _expires;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Names
        {
            get { return _names; }
            set { _names = value; }
        }

        public string Password
        {
            get
            {
                string decrypted = "";
                foreach (char c in _password)
                    decrypted += (char)(c - 3);
                return decrypted;
            }
            set
            {
                string encrypted = "";
                foreach (char c in value)
                    encrypted += (char)(c + 3);
                _password = encrypted;
            }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public UserRolesEnum Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public int FailedLoginAttempts
        {
            get { return _failedLoginAttempts; }
            set { _failedLoginAttempts = value; }
        }

        public string FacultyNumber
        {
            get { return _facultyNumber; }
            set { _facultyNumber = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool IsAdmin
        {
            get { return Role == UserRolesEnum.ADMIN; }
        }

        public bool IsBlocked
        {
            get { return FailedLoginAttempts > 5; }
        }

        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
    }
}