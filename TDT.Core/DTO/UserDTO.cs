using System;
using System.ComponentModel.DataAnnotations;

namespace TDT.Core.DTO
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
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập!")]
        public string UserName { get => _UserName; set => _UserName = value; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ!")]
        public string Address { get => _Address; set => _Address = value; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập email!")]
        public string Email { get => _Email; set => _Email = value; }
        public bool EmailConfirmed { get => _EmailConfirmed; set => _EmailConfirmed = value; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string PasswordHash { get => _PasswordHash; set => _PasswordHash = value; }
        [Display(Name = "SĐT")]
        [Required(ErrorMessage = "Vui lòng nhập sđt!")]
        public string PhoneNumber { get => _PhoneNumber; set => _PhoneNumber = value; }
        public bool PhoneNumberConfirmed { get => _PhoneNumberConfirmed; set => _PhoneNumberConfirmed = value; }
        public DateTimeOffset? LockoutEnd { get => _LockoutEnd; set => _LockoutEnd = value; }
        public bool LockoutEnabled { get => _LockoutEnabled; set => _LockoutEnabled = value; }
        public int AccessFailedCount { get => _AccessFailedCount; set => _AccessFailedCount = value; }
        public DateTime? CreateDate { get => _CreateDate; set => _CreateDate = value; }
    }
}
