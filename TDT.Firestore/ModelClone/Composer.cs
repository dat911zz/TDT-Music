namespace TDT.Firestore.ModelClone
{
    public class Composer
    {
        private string _id;
        private string _name;
        private string _link;
        private bool _spotlight;
        private string _alias;
        private string _cover;
        private string _thumbnail;
        private int _totalFollow;

        public string id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
        public string link { get => _link; set => _link = value; }
        public bool spotlight { get => _spotlight; set => _spotlight = value; }
        public string alias { get => _alias; set => _alias = value; }
        public string cover { get => _cover; set => _cover = value; }
        public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        public int totalFollow { get => _totalFollow; set => _totalFollow = value; }
    }
}
