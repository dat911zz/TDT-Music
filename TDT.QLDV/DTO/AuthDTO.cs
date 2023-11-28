using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.QLDV.Models;

namespace TDT.QLDV.DTO
{
    public class AuthDTO : APIResponseModel
    {
        public string Token { get; set; }
    }
}
