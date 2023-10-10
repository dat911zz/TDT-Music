using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDT.Core.Models
{
    public class LoginModel
    {
        private string _UserName;

        private string _Password;
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập!")]
        public string UserName { get => _UserName; set => _UserName = value; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string Password { get => _Password; set => _Password = value; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
