using System.Collections.Generic;

namespace TDT.Firestore.ModelClone
{
    public class TypePlayList
    {
        private string _sectionType;
        private string _viewType;
        private string _title;
        private string _link;
        private string _sectionId;
        private List<Playlist> _items;
        private Genre _genre;
        public TypePlayList() { }

        public string sectionType { get => _sectionType; set => _sectionType = value; }
        public string viewType { get => _viewType; set => _viewType = value; }
        public string title { get => _title; set => _title = value; }
        public string link { get => _link; set => _link = value; }
        public string sectionId { get => _sectionId; set => _sectionId = value; }
        public List<Playlist> items { get => _items; set => _items = value; }
        public Genre genre { get => _genre; set => _genre = value; }
    }
}
