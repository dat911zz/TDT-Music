using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDT.Core.DTO
{
    public class GroupDTO
    {
        private int _Id;

        private string _Name;

        private string _Description;
        private DateTime? _CreateDate;
        [SwaggerSchema(ReadOnly = true)]
        [Display(Name = "ID")]
        public int Id { get => _Id; set => _Id = value; }
        [Display(Name = "Tên nhóm người dùng")]
        public string Name { get => _Name; set => _Name = value; }
        [Display(Name = "Miêu Tả nhóm người dùng")]
        public string Description { get => _Description; set => _Description = value; }
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? CreateDate { get => _CreateDate; set => _CreateDate = value; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
