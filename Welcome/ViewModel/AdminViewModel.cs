using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace Welcome.ViewModel
{
    public class AdminViewModel
    {
        public IEnumerable<string> AllUserName { get; set; }

        public AdminViewModel()
        {
            UserRepositoryDb repository = new UserRepositoryDb();
            AllUserName = repository.GetAllUserName();
        }
    }
}
