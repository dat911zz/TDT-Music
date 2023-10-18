using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Linq;

namespace TDT.Core.DTO.Firestore
{
    [FirestoreData]
    public class TypePlaylistDTO
    {
        private string _sectionType;
        private string _viewType;
        private string _title;
        private string _link;
        private string _sectionId;
        private List<string> _playlists;
        private Genre _genre;
        public TypePlaylistDTO() { }

        [FirestoreProperty]
        public string sectionType { get => _sectionType; set => _sectionType = value; }
        [FirestoreProperty]
        public string viewType { get => _viewType; set => _viewType = value; }
        [FirestoreProperty]
        public string title { get => _title; set => _title = value; }
        [FirestoreProperty]
        public string link { get => _link; set => _link = value; }
        [FirestoreProperty]
        public string sectionId { get => _sectionId; set => _sectionId = value; }
        [FirestoreProperty]
        public List<string> playlists { get => _playlists; set => _playlists = value; }
        [FirestoreProperty]
        public Genre genre { get => _genre; set => _genre = value; }
    }
}
