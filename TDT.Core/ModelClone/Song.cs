using System.Collections.Generic;
using TDT.Core.DTO;

namespace TDT.Core.ModelClone
{

    public class Song
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
        private string _releaseDate;
        private List<string> _genreIds;
        private string _distributor;
        private List<object> _indicators;
        private bool _isIndie;
        private int _streamingStatus;
        private bool _allowAudioAds;
        private bool _hasLyric;
        private int _userid;
        private List<Genre> _genres;
        private List<Composer> _composers;
        private Playlist _album;
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
        public List<Artist> artists { get => _artists; set => _artists = value; }
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
        public List<Genre> genres { get => _genres; set => _genres = value; }
        public List<Composer> composers { get => _composers; set => _composers = value; }
        public Playlist album { get => _album; set => _album = value; }
        public bool isRBT { get => _isRBT; set => _isRBT = value; }
        public int like { get => _like; set => _like = value; }
        public int listen { get => _listen; set => _listen = value; }
        public bool liked { get => _liked; set => _liked = value; }
        public int comment { get => _comment; set => _comment = value; }
    }

    public class SongIntermediary
    {
        // convert -> clone data

        public List<Song> items { get; set; }
        public int total { get; set; }
        public int totalDuration { get; set; }

        //-----------------------


        //private string id;
        //private string title;
        //private string alias;
        //private string thumbnail;
        //private string thumbnailM;
        //private double duration;
        //private int streamingStatus;
        //private double releaseDate;
        //private double like;
        //private bool isPrivate;
        //private string linkMP3;
        //public Song() { }

        //public string Id { get => id; set => id = value; }
        //public string Title { get => title; set => title = value; }
        //public string Alias { get => alias; set => alias = value; }
        //public string Thumbnail { get => thumbnail; set => thumbnail = value; }
        //public string ThumbnailM { get => thumbnailM; set => thumbnailM = value; }
        //public double Duration { get => duration; set => duration = value; }
        //public int StreamingStatus { get => streamingStatus; set => streamingStatus = value; }
        //public double ReleaseDate { get => releaseDate; set => releaseDate = value; }
        //public double Like { get => like; set => like = value; }
        //public bool IsPrivate { get => isPrivate; set => isPrivate = value; }
        //public string LinkMP3 { get => linkMP3; set => linkMP3 = value; }
    }
}
