using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Models
{
    public class UserIdentiyModel : UserDetailModel
    {
        private string _UserName;
        public string UserName { get => _UserName; set => _UserName = value; }
    }
}
