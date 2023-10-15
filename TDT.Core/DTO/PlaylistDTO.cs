using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TDT.Core.DTO
{
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
        private Dictionary<string, string> _artists;
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
        private Dictionary<string, string> _songs;
        private object _bannerAdaptiveId;
        private int _like;
        private int _listen;
        private bool _liked;

        [Display(Name = "Mã Hóa")]
        public string encodeId { get => _encodeId; set => _encodeId = value; }
        [Display(Name = "Tiêu đề")]
        public string title { get => _title; set => _title = value; }
        [Display(Name = "Ảnh đại diện")]
        public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        [Display(Name = "Official")]
        public bool isoffical { get => _isoffical; set => _isoffical = value; }
        [Display(Name = "Link")]
        public string link { get => _link; set => _link = value; }
        [Display(Name = "Indie")]
        public bool isIndie { get => _isIndie; set => _isIndie = value; }
        [Display(Name = "Ngày phát hành")]
        public string releaseDate { get => _releaseDate; set => _releaseDate = value; }
        [Display(Name = "Mô tả")]
        public string sortDescription { get => _sortDescription; set => _sortDescription = value; }
        [Display(Name = "Ngày phát hành")]
        public string releasedAt { get => _releasedAt; set => _releasedAt = value; }
        [Display(Name = "Genre IDs")]
        public List<string> genreIds { get => _genreIds; set => _genreIds = value; }
        [Display(Name = "PR")]
        public bool PR { get => _PR; set => _PR = value; }
        [Display(Name = "Artists")]
        public Dictionary<string, string> artists { get => _artists; set => _artists = value; }
        [Display(Name = "Tên nghệ sĩ")]
        public string artistsNames { get => _artistsNames; set => _artistsNames = value; }
        [Display(Name = "Chế độ phát")]
        public int playItemMode { get => _playItemMode; set => _playItemMode = value; }
        [Display(Name = "Loại phụ")]
        public int subType { get => _subType; set => _subType = value; }
        [Display(Name = "UID")]
        public int uid { get => _uid; set => _uid = value; }
        [Display(Name = "Ảnh đại diện M")]
        public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }
        [Display(Name = "Shuffle")]
        public bool isShuffle { get => _isShuffle; set => _isShuffle = value; }
        [Display(Name = "Riêng tư")]
        public bool isPrivate { get => _isPrivate; set => _isPrivate = value; }
        [Display(Name = "Tên người dùng")]
        public string userName { get => _userName; set => _userName = value; }

        public bool isAlbum { get => _isAlbum; set => _isAlbum = value; }
        public string textType { get => _textType; set => _textType = value; }
        public bool isSingle { get => _isSingle; set => _isSingle = value; }
        public string distributor { get => _distributor; set => _distributor = value; }
        public string description { get => _description; set => _description = value; }
        public string aliasTitle { get => _aliasTitle; set => _aliasTitle = value; }
        public string sectionId { get => _sectionId; set => _sectionId = value; }
        public string contentLastUpdate { get => _contentLastUpdate; set => _contentLastUpdate = value; }
        public Dictionary<string, string> songs { get => _songs; set => _songs = value; }
        public object bannerAdaptiveId { get => _bannerAdaptiveId; set => _bannerAdaptiveId = value; }
        public int like { get => _like; set => _like = value; }
        public int listen { get => _listen; set => _listen = value; }
        public bool liked { get => _liked; set => _liked = value; }

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
    }
}
