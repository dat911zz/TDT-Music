using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.DTO
{
    public class FileUploadModel<T>
    {
        public IFormFile FileDetails { get; set; }
        public T srcObj { get; set; }
    }
}
