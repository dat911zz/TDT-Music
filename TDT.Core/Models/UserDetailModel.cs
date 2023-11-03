using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Models
{
    public partial class UserDetailModel
    {
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email!")]
        public string Email { get; set; }
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
        public string PhoneNumber { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
