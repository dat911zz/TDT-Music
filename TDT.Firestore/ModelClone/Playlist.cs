using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace TDT.Firestore.ModelClone
{
    [FirestoreData]
    public class Playlist
    {
        private string _encodeId;
        private string _title;
        private string _thumbnail;
        private bool _isoffical;
        private string _link;
        private bool _isIndie;
        private string _releaseDate;
        private string _sortDescription;
        private string _releasedAt;
        private List<string> _genreIds;
        private bool _PR;
        private List<Artist> _artists;
        private string _artistsNames;
        private int _playItemMode;
        private int _subType;
        private int _uid;
        private string _thumbnailM;
        private bool _isShuffle;
        private bool _isPrivate;
        private string _userName;
        private bool _isAlbum;
        private string _textType;
        private bool _isSingle;
        private string _distributor;
        private string _description;
        private string _aliasTitle;
        private string _sectionId;
        private string _contentLastUpdate;
        private Artist _artist;
        private List<Genre> _genres;
        private SongIntermediary _song;
        private object _bannerAdaptiveId;
        private int _like;
        private int _listen;
        private bool _liked;

        [FirestoreProperty] public string encodeId { get => _encodeId; set => _encodeId = value; }
        [FirestoreProperty] public string title { get => _title; set => _title = value; }
        [FirestoreProperty] public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        [FirestoreProperty] public bool isoffical { get => _isoffical; set => _isoffical = value; }
        [FirestoreProperty] public string link { get => _link; set => _link = value; }
        [FirestoreProperty] public bool isIndie { get => _isIndie; set => _isIndie = value; }
        [FirestoreProperty] public string releaseDate { get => _releaseDate; set => _releaseDate = value; }
        [FirestoreProperty] public string sortDescription { get => _sortDescription; set => _sortDescription = value; }
        [FirestoreProperty] public string releasedAt { get => _releasedAt; set => _releasedAt = value; }
        [FirestoreProperty] public List<string> genreIds { get => _genreIds; set => _genreIds = value; }
        [FirestoreProperty] public bool PR { get => _PR; set => _PR = value; }
        [FirestoreProperty] public List<Artist> artists { get => _artists; set => _artists = value; }
        [FirestoreProperty] public string artistsNames { get => _artistsNames; set => _artistsNames = value; }
        [FirestoreProperty] public int playItemMode { get => _playItemMode; set => _playItemMode = value; }
        [FirestoreProperty] public int subType { get => _subType; set => _subType = value; }
        [FirestoreProperty] public int uid { get => _uid; set => _uid = value; }
        [FirestoreProperty] public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }
        [FirestoreProperty] public bool isShuffle { get => _isShuffle; set => _isShuffle = value; }
        [FirestoreProperty] public bool isPrivate { get => _isPrivate; set => _isPrivate = value; }
        [FirestoreProperty] public string userName { get => _userName; set => _userName = value; }
        [FirestoreProperty] public bool isAlbum { get => _isAlbum; set => _isAlbum = value; }
        [FirestoreProperty] public string textType { get => _textType; set => _textType = value; }
        [FirestoreProperty] public bool isSingle { get => _isSingle; set => _isSingle = value; }
        [FirestoreProperty] public string distributor { get => _distributor; set => _distributor = value; }
        [FirestoreProperty] public string description { get => _description; set => _description = value; }
        [FirestoreProperty] public string aliasTitle { get => _aliasTitle; set => _aliasTitle = value; }
        [FirestoreProperty] public string sectionId { get => _sectionId; set => _sectionId = value; }
        [FirestoreProperty] public string contentLastUpdate { get => _contentLastUpdate; set => _contentLastUpdate = value; }
        [FirestoreProperty] public Artist artist { get => _artist; set => _artist = value; }
        [FirestoreProperty] public List<Genre> genres { get => _genres; set => _genres = value; }
        [FirestoreProperty] public SongIntermediary song { get => _song; set => _song = value; }
        [FirestoreProperty] public object bannerAdaptiveId { get => _bannerAdaptiveId; set => _bannerAdaptiveId = value; }
        [FirestoreProperty] public int like { get => _like; set => _like = value; }
        [FirestoreProperty] public int listen { get => _listen; set => _listen = value; }
        [FirestoreProperty] public bool liked { get => _liked; set => _liked = value; }
    }
}
