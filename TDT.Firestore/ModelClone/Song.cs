using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace TDT.Firestore.ModelClone
{
    [FirestoreData]
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

        [FirestoreProperty] public string encodeId { get => _encodeId; set => _encodeId = value; }
        [FirestoreProperty] public string title { get => _title; set => _title = value; }
        [FirestoreProperty] public string alias { get => _alias; set => _alias = value; }
        [FirestoreProperty] public bool isOffical { get => _isOffical; set => _isOffical = value; }
        [FirestoreProperty] public string username { get => _username; set => _username = value; }
        [FirestoreProperty] public string artistsNames { get => _artistsNames; set => _artistsNames = value; }
        [FirestoreProperty] public List<Artist> artists { get => _artists; set => _artists = value; }
        [FirestoreProperty] public bool isWorldWide { get => _isWorldWide; set => _isWorldWide = value; }
        [FirestoreProperty] public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }
        [FirestoreProperty] public string link { get => _link; set => _link = value; }
        [FirestoreProperty] public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        [FirestoreProperty] public int duration { get => _duration; set => _duration = value; }
        [FirestoreProperty] public bool zingChoice { get => _zingChoice; set => _zingChoice = value; }
        [FirestoreProperty] public bool isPrivate { get => _isPrivate; set => _isPrivate = value; }
        [FirestoreProperty] public bool preRelease { get => _preRelease; set => _preRelease = value; }
        [FirestoreProperty] public string releaseDate { get => _releaseDate; set => _releaseDate = value; }
        [FirestoreProperty] public List<string> genreIds { get => _genreIds; set => _genreIds = value; }
        [FirestoreProperty] public string distributor { get => _distributor; set => _distributor = value; }
        [FirestoreProperty] public List<object> indicators { get => _indicators; set => _indicators = value; }
        [FirestoreProperty] public bool isIndie { get => _isIndie; set => _isIndie = value; }
        [FirestoreProperty] public int streamingStatus { get => _streamingStatus; set => _streamingStatus = value; }
        [FirestoreProperty] public bool allowAudioAds { get => _allowAudioAds; set => _allowAudioAds = value; }
        [FirestoreProperty] public bool hasLyric { get => _hasLyric; set => _hasLyric = value; }
        [FirestoreProperty] public int userid { get => _userid; set => _userid = value; }
        [FirestoreProperty] public List<Genre> genres { get => _genres; set => _genres = value; }
        [FirestoreProperty] public List<Composer> composers { get => _composers; set => _composers = value; }
        [FirestoreProperty] public Playlist album { get => _album; set => _album = value; }
        [FirestoreProperty] public bool isRBT { get => _isRBT; set => _isRBT = value; }
        [FirestoreProperty] public int like { get => _like; set => _like = value; }
        [FirestoreProperty] public int listen { get => _listen; set => _listen = value; }
        [FirestoreProperty] public bool liked { get => _liked; set => _liked = value; }
        [FirestoreProperty] public int comment { get => _comment; set => _comment = value; }
    }
    [FirestoreData]
    public class SongIntermediary
    {
        // convert -> clone data

        [FirestoreProperty] public List<Song> items { get; set; }
        [FirestoreProperty] public int total { get; set; }
        [FirestoreProperty] public int totalDuration { get; set; }

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

        //public string Id { Get => id; set => id = value; }
        //public string Title { Get => title; set => title = value; }
        //public string Alias { Get => alias; set => alias = value; }
        //public string Thumbnail { Get => thumbnail; set => thumbnail = value; }
        //public string ThumbnailM { Get => thumbnailM; set => thumbnailM = value; }
        //public double Duration { Get => duration; set => duration = value; }
        //public int StreamingStatus { Get => streamingStatus; set => streamingStatus = value; }
        //public double ReleaseDate { Get => releaseDate; set => releaseDate = value; }
        //public double Like { Get => like; set => like = value; }
        //public bool IsPrivate { Get => isPrivate; set => isPrivate = value; }
        //public string LinkMP3 { Get => linkMP3; set => linkMP3 = value; }
    }
}
