using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TDT.Core.Enums;

namespace TDT.Core.Models
{
    public class APIResponseModel
    {
        public APIStatusCode Code { get; set; }
        public string Msg { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
