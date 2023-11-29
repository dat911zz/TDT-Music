using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TDT.Core.Helper;
using TDT.Core.Models;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils;

namespace TDT.Core.DTO.Firestore
{
    [FirestoreData]
    public class PlaylistDTO : APIResponseModel
    {
        private string _encodeId;
        private string _title;
        private string _thumbnail = @"Images/Playlist/album_default.png";
        private bool _isoffical;
        private string _link;
        private bool _isIndie;
        private long _releaseDate = HelperUtility.GetTicks(DateTime.Now);
        private string _sortDescription;
        private long _releasedAt = HelperUtility.GetTicks(DateTime.Now);
        private List<string> _genreIds = new List<string>();
        private bool _PR;
        private List<string> _artists = new List<string>();
        private string _artistsNames;
        private int _playItemMode;
        private int _subType;
        private string _uid;
        private string _thumbnailM = @"Images/Playlist/album_default.png";
        private bool _isShuffle = false;
        private bool _isPrivate;
        private string _userName;
        private bool _isAlbum;
        private string _textType;
        private bool _isSingle;
        private string _distributor;
        private string _description;
        private string _aliasTitle;
        private string _sectionId;
        private long _contentLastUpdate = HelperUtility.GetTicks(DateTime.Now);
        private List<string> _songs = new List<string>();
        private object _bannerAdaptiveId;
        private int _like;
        private int _listen;
        private bool _liked;

        [Display(Name = "Mã ID")]
        [FirestoreProperty] public string encodeId { get => _encodeId; set => _encodeId = value; }
        [Display(Name = "Tiêu Đề")]
        [FirestoreProperty] public string title { get => _title; set => _title = value; }
        [Display(Name = "Ảnh")]
        [FirestoreProperty] public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        [Display(Name = "Bản Chính Thức")]
        [FirestoreProperty] public bool isoffical { get => _isoffical; set => _isoffical = value; }
        [Display(Name = "Link")]
        [FirestoreProperty] public string link { get => _link; set => _link = value; }
        [Display(Name = "Indie")]
        [FirestoreProperty] public bool isIndie { get => _isIndie; set => _isIndie = value; }
        [Display(Name = "Ngày Phát Hành")]
        [FirestoreProperty] public long releaseDate { get => _releaseDate; set => _releaseDate = value; }
        [Display(Name = "Mô tả ngắn")]
        [FirestoreProperty] public string sortDescription { get => _sortDescription; set => _sortDescription = value; }
        [Display(Name = "Phát Hành Tại ?")]
        [FirestoreProperty] public long releasedAt { get => _releasedAt; set => _releasedAt = value; }
        [Display(Name = "Danh Sách Thể Loại")]
        [FirestoreProperty] public List<string> genreIds { get => _genreIds; set => _genreIds = value; }
        [Display(Name = "PR")]
        [FirestoreProperty] public bool PR { get => _PR; set => _PR = value; }
        [Display(Name = "Nghệ sĩ")]
        [FirestoreProperty] public List<string> artists { get => _artists; set => _artists = value; }
        [Display(Name = "Tên nghệ sĩ")]
        [FirestoreProperty] public string artistsNames { get => _artistsNames; set => _artistsNames = value; }
        [Display(Name = "playItemMode")]
        [FirestoreProperty] public int playItemMode { get => _playItemMode; set => _playItemMode = value; }
        [Display(Name = "subType")]
        [FirestoreProperty] public int subType { get => _subType; set => _subType = value; }
        [Display(Name = "uid")]
        [FirestoreProperty] public string uid { get => _uid; set => _uid = value; }
        [Display(Name = "Ảnh ThumbanilM")]
        [FirestoreProperty] public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }
        [Display(Name = "Là Trộn bài")]
        [FirestoreProperty] public bool isShuffle { get => _isShuffle; set => _isShuffle = value; }
        [Display(Name = "Là Riêng Tư")]
        [FirestoreProperty] public bool isPrivate { get => _isPrivate; set => _isPrivate = value; }
        [FirestoreProperty] public string userName { get => _userName; set => _userName = value; }
        [Display(Name = "Là Album")]
        [FirestoreProperty] public bool isAlbum { get => _isAlbum; set => _isAlbum = value; }
        [Display(Name = "Là Dạng Test")]
        [FirestoreProperty] public string textType { get => _textType; set => _textType = value; }
        [Display(Name = "Là Bảng Riêng Lê")]
        [FirestoreProperty] public bool isSingle { get => _isSingle; set => _isSingle = value; }
        [Display(Name = "Nhà Sản Xuất")]
        [FirestoreProperty] public string distributor { get => _distributor; set => _distributor = value; }
        [Display(Name = "Sự miêu tả")]
        [FirestoreProperty] public string description { get => _description; set => _description = value; }
        [Display(Name = "Bí Danh Tiêu Đề")]
        [FirestoreProperty] public string aliasTitle { get => _aliasTitle; set => _aliasTitle = value; }
        [Display(Name = "SelectionID")]
        [FirestoreProperty] public string sectionId { get => _sectionId; set => _sectionId = value; }
        [Display(Name = "Nội dung cập nhật cuối")]
        [FirestoreProperty] public long contentLastUpdate { get => _contentLastUpdate; set => _contentLastUpdate = value; }
        [Display(Name = "List Song")]
        [FirestoreProperty] public List<string> songs { get => _songs; set => _songs = value; }
        [Display(Name = "BannerAdaptiveId")]
        [FirestoreProperty] public object bannerAdaptiveId { get => _bannerAdaptiveId; set => _bannerAdaptiveId = value; }
        [Display(Name = "Số like")]
        [FirestoreProperty] public int like { get => _like; set => _like = value; }
        [Display(Name = "Số lượt nghe")]
        [FirestoreProperty] public int listen { get => _listen; set => _listen = value; }
        [Display(Name = "Like")]
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
            return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(this.contentLastUpdate);
        }
        public DateTime ReleaseDate()
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(this.releaseDate);
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
            if(playlists == null)
                return "";
            return Generator.GeneratePlaylistsElement(playlists.Take(5).ToList());
        }
        public DateTime ReleaseAt()
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(this.releasedAt);
        }
    }
}
