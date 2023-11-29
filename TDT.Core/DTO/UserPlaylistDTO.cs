using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.DTO
{
    public class UserPlaylistDTO
    {
        private System.Guid _UserId;

        private string _PlaylistId;

        private System.Nullable<System.DateTime> _CreateDate;

        public Guid UserId { get => _UserId; set => _UserId = value; }
        public string PlaylistId { get => _PlaylistId; set => _PlaylistId = value; }
        public DateTime? CreateDate { get => _CreateDate; set => _CreateDate = value; }
    }
}
