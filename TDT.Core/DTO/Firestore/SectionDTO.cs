using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Linq;

namespace TDT.Core.DTO.Firestore
{
    [FirestoreData]
    public class SectionDTO
    {
        private string _sectionType;
        private string _viewType;
        private string _title;
        private string _link;
        private string _sectionId;
        private List<string> _items;
        private string _itemType;

        [FirestoreProperty] public string sectionType { get => _sectionType; set => _sectionType = value; }
        [FirestoreProperty] public string viewType { get => _viewType; set => _viewType = value; }
        [FirestoreProperty] public string title { get => _title; set => _title = value; }
        [FirestoreProperty] public string link { get => _link; set => _link = value; }
        [FirestoreProperty] public string sectionId { get => _sectionId; set => _sectionId = value; }
        [FirestoreProperty] public List<string> items { get => _items; set => _items = value; }
        [FirestoreProperty] public string itemType { get => _itemType; set => _itemType = value; }

        public bool compare(SectionDTO other)
        {
            if (this.items.Count == 0 && other.items == null)
                return true;
            if ((this.items.Count != 0 && other.items == null) || (this.items.Count != other.items.Count))
                return false;
            foreach (var item in this.items)
            {
                if (!other.items.Contains(item))
                    return false;
            }
            return true;
        }
    }
}
