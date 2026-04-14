using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;
using Welcome.Model;

public class UserRepositoryDb : UserRepository
{
    private DatabaseContext _dbContext;

    public UserRepositoryDb()
    {
        _dbContext = new DatabaseContext();
        _users = _dbContext.Users;
    }

    public void CreatedDatabase()
    {
        _dbContext.Database.EnsureCreated();
    }

    public IEnumerable<string> GetAllUserName()
    {
        return _users.Select(u => u.Names).ToList();
    }
}