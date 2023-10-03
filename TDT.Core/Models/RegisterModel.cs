using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Models
{
    public class RegisterModel
    {
        private string _UserName;

        private string _Address;

        private string _Email;

        private string _Password;

        private string _PhoneNumber;


        public string UserName { get => _UserName; set => _UserName = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string PhoneNumber { get => _PhoneNumber; set => _PhoneNumber = value; }
    }
}
