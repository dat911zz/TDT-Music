using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.IService;
using TDT.Core.Models;

namespace TDT.Core.ServiceImp
{
    public class UserManagement : IDataService<User>
    {
        public UserManagement() {
            
        }

        public void Add(User obj)
        {
            throw new NotImplementedException();
        }

        public bool Check(int id)
        {
            throw new NotImplementedException();
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetDetails()
        {
            return null;
        }

        public User GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
