using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.QLND.Models;

namespace TDT.QLND.DTO
{
    public class ResponseDataDTO<T> : APIResponseModel
    {
        private IList<T> data;

        public IList<T> Data { get => data; set => data = value; }
    }
}
