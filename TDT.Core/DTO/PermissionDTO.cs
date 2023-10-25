using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TDT.Core.DTO
{
    public class PermissionDTO
    {
        private int _Id;

        private string _Name;

        private string _Description;
        private DateTime? _CreateDate;
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Description { get => _Description; set => _Description = value; }
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? CreateDate { get => _CreateDate; set => _CreateDate = value; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
