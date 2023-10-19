using Google.Cloud.Firestore;

namespace TDT.Firestore.ModelClone
{
    [FirestoreData]
    public class Genre // thể loại album // playlist // song
    {
        private string _id;
        private string _name;
        private string _title;
        private string _alias;
        private string _link;

        [FirestoreProperty]
        public string id { get => _id; set => _id = value; }
        [FirestoreProperty]
        public string name { get => _name; set => _name = value; }
        [FirestoreProperty]
        public string title { get => _title; set => _title = value; }
        [FirestoreProperty]
        public string alias { get => _alias; set => _alias = value; }
        [FirestoreProperty]
        public string link { get => _link; set => _link = value; }

        public bool compare(Genre other)
        {
            return this.name == other.name && this.title == other.title && this.alias == other.alias;
        }
    }
}
