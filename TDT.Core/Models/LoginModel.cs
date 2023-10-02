using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Models
{
    public class LoginModel
    {
        private string _UserName;
        private string _Password;

        public string UserName { get => _UserName; set => _UserName = value; }
        public string Password { get => _Password; set => _Password = value; }
    }
}
