using System.Collections.Generic;

namespace TDT.Firestore.ModelClone
{
    public class Section
    {
        private string _sectionType;
        private string _viewType;
        private string _title;
        private string _link;
        private string _sectionId;
        private List<SectionItem> _items;
        private string _itemType;

        public string sectionType { get => _sectionType; set => _sectionType = value; }
        public string viewType { get => _viewType; set => _viewType = value; }
        public string title { get => _title; set => _title = value; }
        public string link { get => _link; set => _link = value; }
        public string sectionId { get => _sectionId; set => _sectionId = value; }
        public List<SectionItem> items { get => _items; set => _items = value; }
        public string itemType { get => _itemType; set => _itemType = value; }
    }

    public class SectionItem
    {
        private string _encodeId;
        private string _title;
        private string _alias;
        private bool _isOffical;
        private string _username;
        private string _artistsNames;
        private List<Artist> _artists;
        private bool _isWorldWide;
        private string _thumbnailM;
        private string _link;
        private string _thumbnail;
        private int _duration;
        private bool _zingChoice;
        private bool _isPrivate;
        private bool _preRelease;
        private object _releaseDate;
        private List<string> _genreIds;
        private Playlist _album;
        private string _distributor;
        private List<object> _indicators;
        private bool _isIndie;
        private int _streamingStatus;
        private bool _allowAudioAds;
        private bool _hasLyric;
        private List<int> _downloadPrivileges;
        private bool _isoffical;
        private string _sortDescription;
        private string _releasedAt;
        private bool _PR;
        private int _playItemMode;
        private int _subType;
        private int _uid;
        private bool _isShuffle;
        private string _userName;
        private bool _isAlbum;
        private string _textType;
        private bool _isSingle;
        private string _releaseDateText;
        private string _id;
        private string _name;
        private bool _spotlight;
        private bool _isOA;
        private bool _isOABrand;
        private string _playlistId;
        private int _totalFollow;

        public string encodeId { get => _encodeId; set => _encodeId = value; }
        public string title { get => _title; set => _title = value; }
        public string alias { get => _alias; set => _alias = value; }
        public bool isOffical { get => _isOffical; set => _isOffical = value; }
        public bool isoffical { get => _isoffical; set => _isoffical = value; }
        public string username { get => _username; set => _username = value; }
        public string userName { get => _userName; set => _userName = value; }
        public string artistsNames { get => _artistsNames; set => _artistsNames = value; }
        public List<Artist> artists { get => _artists; set => _artists = value; }
        public bool isWorldWide { get => _isWorldWide; set => _isWorldWide = value; }
        public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }
        public string link { get => _link; set => _link = value; }
        public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        public int duration { get => _duration; set => _duration = value; }
        public bool zingChoice { get => _zingChoice; set => _zingChoice = value; }
        public bool isPrivate { get => _isPrivate; set => _isPrivate = value; }
        public bool preRelease { get => _preRelease; set => _preRelease = value; }
        public object releaseDate { get => _releaseDate; set => _releaseDate = value; }
        public List<string> genreIds { get => _genreIds; set => _genreIds = value; }
        public Playlist album { get => _album; set => _album = value; }
        public string distributor { get => _distributor; set => _distributor = value; }
        public List<object> indicators { get => _indicators; set => _indicators = value; }
        public bool isIndie { get => _isIndie; set => _isIndie = value; }
        public int streamingStatus { get => _streamingStatus; set => _streamingStatus = value; }
        public bool allowAudioAds { get => _allowAudioAds; set => _allowAudioAds = value; }
        public bool hasLyric { get => _hasLyric; set => _hasLyric = value; }
        public List<int> downloadPrivileges { get => _downloadPrivileges; set => _downloadPrivileges = value; }
        public string sortDescription { get => _sortDescription; set => _sortDescription = value; }
        public string releasedAt { get => _releasedAt; set => _releasedAt = value; }
        public bool PR { get => _PR; set => _PR = value; }
        public int playItemMode { get => _playItemMode; set => _playItemMode = value; }
        public int subType { get => _subType; set => _subType = value; }
        public int uid { get => _uid; set => _uid = value; }
        public bool isShuffle { get => _isShuffle; set => _isShuffle = value; }
        public bool isAlbum { get => _isAlbum; set => _isAlbum = value; }
        public string textType { get => _textType; set => _textType = value; }
        public bool isSingle { get => _isSingle; set => _isSingle = value; }
        public string releaseDateText { get => _releaseDateText; set => _releaseDateText = value; }
        public string id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
        public bool spotlight { get => _spotlight; set => _spotlight = value; }
        public bool isOA { get => _isOA; set => _isOA = value; }
        public bool isOABrand { get => _isOABrand; set => _isOABrand = value; }
        public string playlistId { get => _playlistId; set => _playlistId = value; }
        public int totalFollow { get => _totalFollow; set => _totalFollow = value; }
    }
}
