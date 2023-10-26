using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDT.Core.Models
{
    public class UserIdentiyModel : UserDetailModel
    {
        [DisplayName("Tên tài khoản")]
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản!")]
        public string UserName { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
