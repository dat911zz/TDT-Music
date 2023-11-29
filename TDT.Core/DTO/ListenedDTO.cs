using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.DTO
{
    public class ListenedDTO
    {
        private System.Guid _UserId;

        private string _SongId;

        private System.Nullable<System.DateTime> _AccessDate;

        public Guid UserId { get => _UserId; set => _UserId = value; }
        public string SongId { get => _SongId; set => _SongId = value; }
        public DateTime? AccessDate { get => _AccessDate; set => _AccessDate = value; }
    }
}
