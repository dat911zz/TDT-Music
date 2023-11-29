using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDT.Core.DTO
{
    public class RoleDTO
    {
        private int _Id;

        private string _Name;

        private string _Description;
        private DateTime? _CreateDate;
        [SwaggerSchema(ReadOnly = true)]
        [Display(Name = "ID")]
        public int Id { get => _Id; set => _Id = value; }
        [Display(Name = "Tên Vai Trò")]
        //[Required(ErrorMessage = "Vui lòng nhập tên vai trò!")]

        public string Name { get => _Name; set => _Name = value; }
        [Display(Name = "Miêu tả vai trò")]
        //[Required(ErrorMessage = "Vui lòng nhập giới thiệu vai trò!")]

        public string Description { get => _Description; set => _Description = value; }
        [SwaggerSchema(ReadOnly = true)]
        [Display(Name = "Ngày Tạo vai trò")]

        public DateTime? CreateDate { get => _CreateDate; set => _CreateDate = value; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
