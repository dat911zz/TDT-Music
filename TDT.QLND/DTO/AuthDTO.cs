using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.QLND.Models;

namespace TDT.QLND.DTO
{
    public class AuthDTO : APIResponseModel
    {
        public string Token { get; set; }
    }
}
