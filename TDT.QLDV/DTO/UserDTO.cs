using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.QLDV.DTO
{
    public class UserDTO
    {
        private System.Guid _Id;

        private string _UserName;

        private string _Address;

        private string _Email;

        private bool _EmailConfirmed;

        private string _PasswordHash;

        private string _PhoneNumber;

        private bool _PhoneNumberConfirmed;

        private System.DateTimeOffset? _LockoutEnd;

        private bool _LockoutEnabled;

        private int _AccessFailedCount;

        private System.DateTime? _CreateDate;
        public Guid Id { get => _Id; set => _Id = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Email { get => _Email; set => _Email = value; }
        public bool EmailConfirmed { get => _EmailConfirmed; set => _EmailConfirmed = value; }
        public string PasswordHash { get => _PasswordHash; set => _PasswordHash = value; }
        public string PhoneNumber { get => _PhoneNumber; set => _PhoneNumber = value; }
        public bool PhoneNumberConfirmed { get => _PhoneNumberConfirmed; set => _PhoneNumberConfirmed = value; }
        public DateTimeOffset? LockoutEnd { get => _LockoutEnd; set => _LockoutEnd = value; }
        public bool LockoutEnabled { get => _LockoutEnabled; set => _LockoutEnabled = value; }
        public int AccessFailedCount { get => _AccessFailedCount; set => _AccessFailedCount = value; }
        public DateTime? CreateDate { get => _CreateDate; set => _CreateDate = value; }
    }
}
