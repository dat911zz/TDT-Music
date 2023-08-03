using System.Collections.Generic;

namespace TDT.Core.DTO
{
    public class SectionDTO
    {
        private string _sectionType;
        private string _viewType;
        private string _title;
        private string _link;
        private string _sectionId;
        private Dictionary<string, string> _items;
        private string _itemType;

        public string sectionType { get => _sectionType; set => _sectionType = value; }
        public string viewType { get => _viewType; set => _viewType = value; }
        public string title { get => _title; set => _title = value; }
        public string link { get => _link; set => _link = value; }
        public string sectionId { get => _sectionId; set => _sectionId = value; }
        public Dictionary<string, string> items { get => _items; set => _items = value; }
        public string itemType { get => _itemType; set => _itemType = value; }
    }
}
