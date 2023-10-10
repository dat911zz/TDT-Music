using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.Models;

namespace TDT.Core.DTO
{
    public class ResponseDataDTO<T> : APIResponseModel
    {
        private IList<T> data;

        public IList<T> Data { get => data; set => data = value; }
    }
}
