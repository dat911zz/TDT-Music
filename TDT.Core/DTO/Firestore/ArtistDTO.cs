using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Linq;

namespace TDT.Core.DTO.Firestore
{
    [FirestoreData]
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
        private List<SectionDTO> _sections;
        private string _sectionId;
        private bool _hasOA;

        [FirestoreProperty] public string id { get => _id; set => _id = value; }
        [FirestoreProperty] public string name { get => _name; set => _name = value; }
        [FirestoreProperty] public string link { get => _link; set => _link = value; }
        [FirestoreProperty] public bool spotlight { get => _spotlight; set => _spotlight = value; }
        [FirestoreProperty] public string alias { get => _alias; set => _alias = value; }
        [FirestoreProperty] public string playlistId { get => _playlistId; set => _playlistId = value; }
        [FirestoreProperty] public string cover { get => _cover; set => _cover = value; }
        [FirestoreProperty] public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        [FirestoreProperty] public string biography { get => _biography; set => _biography = value; }
        [FirestoreProperty] public string sortBiography { get => _sortBiography; set => _sortBiography = value; }
        [FirestoreProperty] public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }
        [FirestoreProperty] public string national { get => _national; set => _national = value; }
        [FirestoreProperty] public string birthday { get => _birthday; set => _birthday = value; }
        [FirestoreProperty] public string realname { get => _realname; set => _realname = value; }
        [FirestoreProperty] public int totalFollow { get => _totalFollow; set => _totalFollow = value; }
        [FirestoreProperty] public int follow { get => _follow; set => _follow = value; }
        [FirestoreProperty] public List<SectionDTO> sections {
            get => _sections;
            set => _sections = value;
        }
        [FirestoreProperty] public string sectionId { get => _sectionId; set => _sectionId = value; }
        [FirestoreProperty] public bool hasOA { get => _hasOA; set => _hasOA = value; }

        public bool compare(ArtistDTO other)
        {
            if(this.name != other.name || this.alias != other.alias || this.realname != other.realname ||
                this.sections.Count != other.sections.Count)
                return false;
            if (this.sections == null)
                return other.sections == null || other.sections.Count == 0;
            foreach(var section in this.sections)
            {
                if(other.sections.Select(x => x.title == section.title && x.compare(section)).ToList().Count <= 0)
                    return false;
            }
            return true;
        }
    }
}
