using System;

namespace TDT.Core.Models
{
    public partial class Login
    {

        private string _UserName;

        private string _Address;

        private string _PasswordHash;

        public Login()
        {
        }

        public string UserName { get => _UserName; set => _UserName = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string PasswordHash { get => _PasswordHash; set => _PasswordHash = value; }
    }
}