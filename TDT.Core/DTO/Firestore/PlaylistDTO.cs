using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.Helper;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils;

namespace TDT.Core.DTO.Firestore
{
    [FirestoreData]
    public class PlaylistDTO
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
        private List<string> _artists;
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
        private List<string> _songs;
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
        [FirestoreProperty] public List<string> artists { get => _artists; set => _artists = value; }
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
        [FirestoreProperty] public List<string> songs { get => _songs; set => _songs = value; }
        [FirestoreProperty] public object bannerAdaptiveId { get => _bannerAdaptiveId; set => _bannerAdaptiveId = value; }
        [FirestoreProperty] public int like { get => _like; set => _like = value; }
        [FirestoreProperty] public int listen { get => _listen; set => _listen = value; }
        [FirestoreProperty] public bool liked { get => _liked; set => _liked = value; }

        public bool compare(PlaylistDTO other)
        {
            if(this.title != other.title || this.releasedAt != other.releasedAt || this.artistsNames != other.artistsNames ||
                this.description != other.description || this.sortDescription != other.sortDescription || 
                this.aliasTitle != other.aliasTitle || this.songs.Count != other.songs.Count)
                return false;
            foreach(var song in this.songs)
            {
                if(!other.songs.Contains(song))
                    return false;
            }
            return true;
        }
        public DateTime ContentLastUpdate()
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0)).AddMilliseconds(long.Parse(this.contentLastUpdate.Length > 0 ? this.contentLastUpdate.PadRight(13, '0') : this.contentLastUpdate));
        }
        public string GetHtmlArtist()
        {
            return Generator.GenerateArtistLink(this.artists);
        }
        public string GetLike()
        {
            return HelperUtility.GetCompactNum(this.like);
        }
        public string SumDuration()
        {
            if(this.songs != null && this.songs.Count > 0)
            {
                long sum = 0;
                foreach (var item in this.songs)
                {
                    SongDTO song = DataHelper.GetSong(item);
                    if(song != null)
                    {
                        sum += song.duration;
                    }
                }
                return HelperUtility.GetTime(sum);
            }
            return "0 giờ 0 phút";
        }
        public string GetHtmlArtistElement()
        {
            return Generator.GenerateArtistsElement(this.artists);
        }
        public string GetHtmlPlaylistSuggest()
        {
            List<PlaylistDTO> playlists = DataHelper.GetPlaylistSuggest(this);
            return Generator.GeneratePlaylistsElement(playlists.Take(5).ToList());
        }
    }
}
