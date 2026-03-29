using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Welcome.Others;

namespace Welcome.Model
{
    public class UserRepository
    {
        private List<User> _users;
        private int _nextId;

        public UserRepository()
        {
            _nextId = 0;
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        // С foreach
        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Names == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        // С Lambda
        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password)
                         .FirstOrDefault() != null ? true : false;
        }

        // С LINQ
        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Names == name && user.Password == password
                      select user.Id;
            return ret != null ? true : false;
        }

        // Връща потребител по име и парола - с LINQ
        public User? GetUserByNameAndPassword(string name, string password)
        {
            return (from user in _users
                    where user.Names == name && user.Password == password
                    select user).FirstOrDefault();
        }

        // Задава дата на изтичане по име - с LINQ
        public void SetUserActive(string name, DateTime expires)
        {
            var user = (from u in _users
                        where u.Names == name
                        select u).FirstOrDefault();
            if (user != null)
                user.Expires = expires;
        }

        // Задава роля по ime - с LINQ
        public void AssignUserRole(string name, UserRolesEnum role)
        {
            var user = (from u in _users
                        where u.Names == name
                        select u).FirstOrDefault();
            if (user != null)
                user.Role = role;
        }
    }
}
