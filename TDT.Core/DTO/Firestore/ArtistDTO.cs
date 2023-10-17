using System.Collections.Generic;
using System.Linq;

namespace TDT.Core.DTO.Firestore
{
    public class ArtistDTO
    {
        private string _id;
        private string _name;
        private string _link;
        private bool _spotlight;
        private string _alias;
        private string _playlistId;
        private string _cover;
        private string _thumbnail;
        private string _biography;
        private string _sortBiography;
        private string _thumbnailM;
        private string _national;
        private string _birthday;
        private string _realname;
        private int _totalFollow;
        private int _follow;
        private Dictionary<string, SectionDTO> _sections;
        private string _sectionId;
        private bool _hasOA;

        public string id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
        public string link { get => _link; set => _link = value; }
        public bool spotlight { get => _spotlight; set => _spotlight = value; }
        public string alias { get => _alias; set => _alias = value; }
        public string playlistId { get => _playlistId; set => _playlistId = value; }
        public string cover { get => _cover; set => _cover = value; }
        public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        public string biography { get => _biography; set => _biography = value; }
        public string sortBiography { get => _sortBiography; set => _sortBiography = value; }
        public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }
        public string national { get => _national; set => _national = value; }
        public string birthday { get => _birthday; set => _birthday = value; }
        public string realname { get => _realname; set => _realname = value; }
        public int totalFollow { get => _totalFollow; set => _totalFollow = value; }
        public int follow { get => _follow; set => _follow = value; }
        public Dictionary<string, SectionDTO> sections { get => _sections; set => _sections = value; }
        public string sectionId { get => _sectionId; set => _sectionId = value; }
        public bool hasOA { get => _hasOA; set => _hasOA = value; }

        public bool compare(ArtistDTO other)
        {
            if(this.name != other.name || this.alias != other.alias || this.realname != other.realname ||
                this.sections.Count != other.sections.Count)
                return false;
            if (this.sections == null)
                return other.sections == null || other.sections.Count == 0;
            foreach(var section in this.sections)
            {
                if(other.sections.Select(x => x.Key == section.Key && x.Value.compare(section.Value)).ToList().Count <= 0)
                    return false;
            }
            return true;
        }
    }
}
