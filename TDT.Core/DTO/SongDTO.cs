using System.Collections.Generic;

namespace TDT.Core.DTO
{
    public class SongDTO
    {
        private string _encodeId;
        private string _title;
        private string _alias;
        private bool _isOffical;
        private string _username;
        private string _artistsNames;
        private Dictionary<string, string> _artists;
        private bool _isWorldWide;
        private string _thumbnailM;
        private string _link;
        private string _thumbnail;
        private int _duration;
        private bool _zingChoice;
        private bool _isPrivate;
        private bool _preRelease;
        private string _releaseDate;
        private List<string> _genreIds;
        private string _distributor;
        private List<object> _indicators;
        private bool _isIndie;
        private int _streamingStatus;
        private bool _allowAudioAds;
        private bool _hasLyric;
        private int _userid;
        private Dictionary<string, string> _composers;
        private string _album;
        private bool _isRBT;
        private int _like;
        private int _listen;
        private bool _liked;
        private int _comment;

        public string encodeId { get => _encodeId; set => _encodeId = value; }
        public string title { get => _title; set => _title = value; }
        public string alias { get => _alias; set => _alias = value; }
        public bool isOffical { get => _isOffical; set => _isOffical = value; }
        public string username { get => _username; set => _username = value; }
        public string artistsNames { get => _artistsNames; set => _artistsNames = value; }
        public Dictionary<string, string> artists { get => _artists; set => _artists = value; }
        public bool isWorldWide { get => _isWorldWide; set => _isWorldWide = value; }
        public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }
        public string link { get => _link; set => _link = value; }
        public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        public int duration { get => _duration; set => _duration = value; }
        public bool zingChoice { get => _zingChoice; set => _zingChoice = value; }
        public bool isPrivate { get => _isPrivate; set => _isPrivate = value; }
        public bool preRelease { get => _preRelease; set => _preRelease = value; }
        public string releaseDate { get => _releaseDate; set => _releaseDate = value; }
        public List<string> genreIds { get => _genreIds; set => _genreIds = value; }
        public string distributor { get => _distributor; set => _distributor = value; }
        public List<object> indicators { get => _indicators; set => _indicators = value; }
        public bool isIndie { get => _isIndie; set => _isIndie = value; }
        public int streamingStatus { get => _streamingStatus; set => _streamingStatus = value; }
        public bool allowAudioAds { get => _allowAudioAds; set => _allowAudioAds = value; }
        public bool hasLyric { get => _hasLyric; set => _hasLyric = value; }
        public int userid { get => _userid; set => _userid = value; }
        public Dictionary<string, string> composers { get => _composers; set => _composers = value; }
        public string album { get => _album; set => _album = value; }
        public bool isRBT { get => _isRBT; set => _isRBT = value; }
        public int like { get => _like; set => _like = value; }
        public int listen { get => _listen; set => _listen = value; }
        public bool liked { get => _liked; set => _liked = value; }
        public int comment { get => _comment; set => _comment = value; }
    }
}
