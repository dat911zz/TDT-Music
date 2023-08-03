using System.Collections.Generic;

namespace TDT.Core.DTO
{
    public class Genre // thể loại album // playlist // song
    {
        private string _id;
        private string _name;
        private string _title;
        private string _alias;
        private string _link;

        public string id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
        public string title { get => _title; set => _title = value; }
        public string alias { get => _alias; set => _alias = value; }
        public string link { get => _link; set => _link = value; }
    }
}
