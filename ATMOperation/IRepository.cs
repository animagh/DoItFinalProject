using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOperation
{
    public interface IRepository
    {
        
        List<User> GetAllUser();
        User GetSingleUser(int id);
        void AddNewUser(User model);
        void Save(string input);
    }
}
