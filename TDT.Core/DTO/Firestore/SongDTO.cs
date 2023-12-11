using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TDT.Core.Helper;
using TDT.Core.Models;
using TDT.Core.ServiceImp;

namespace TDT.Core.DTO.Firestore
{
    [FirestoreData]
    public class SongDTO : APIResponseModel
    {
        private string _encodeId;
        private string _title;
        private string _alias;
        private bool _isOffical;
        private string _username;
        private string _artistsNames;
        private List<string> _artists;
        private bool _isWorldWide;
        private string _thumbnailM;
        private string _link;
        private string _thumbnail;
        private int _duration;
        private bool _zingChoice;
        private bool _isPrivate;
        private bool _preRelease;
        private long _releaseDate;
        private List<string> _genreIds;
        private string _distributor;
        private List<string> _indicators;
        private bool _isIndie;
        private int _streamingStatus;
        private bool _allowAudioAds;
        private bool _hasLyric;
        private string _userid;
        private List<string> _composers;
        private string _album;
        private bool _isRBT;
        private int _like;
        private int _listen;
        private bool _liked;
        private int _comment;

        [Display(Name = "Mã ID")]
        [FirestoreProperty] public string encodeId { get => _encodeId; set => _encodeId = value; }
        
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề!")]

        [Display(Name = "Tiêu đề")]
        [FirestoreProperty] public string title { get => _title; set => _title = value; }
        //[Required(ErrorMessage = "Nhập bí danh!")]

        [Display(Name = "Bí danh")]
        [FirestoreProperty] public string alias { get => _alias; set => _alias = value; }

        [Display(Name = "Làm chính thức")]
        [FirestoreProperty] public bool isOffical { get => _isOffical; set => _isOffical = value; }

        [Display(Name = "Tên người dùng")]
        //[Required(ErrorMessage = "Vui lòng nhập tên người dùng!")]
        [FirestoreProperty] public string username { get => _username; set => _username = value; }

        [Required(ErrorMessage = "Vui nhập tên nghệ sĩ!")]
        [Display(Name = "Tên nghệ sĩ")]
        [FirestoreProperty] public string artistsNames { get => _artistsNames; set => _artistsNames = value; }

        //[Required(ErrorMessage = "Vui lòng nhập danh sách nghệ sĩ!")]
        [Display(Name = "Danh sách nghệ sĩ")]
        [FirestoreProperty] public List<string> artists { get => _artists; set => _artists = value; }
        
        [Display(Name = "Bản toàn cầu")]
        [FirestoreProperty] public bool isWorldWide { get => _isWorldWide; set => _isWorldWide = value; }

        //[Required(ErrorMessage = "Vui lòng chọn file ảnh M!")]
        [Display(Name = "Ảnh thu nhỏ M")]
        [FirestoreProperty] public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }

        [Display(Name = "Liên kết")]
        [FirestoreProperty] public string link { get => _link; set => _link = value; }

        [Required(ErrorMessage = "Vui lòng chọn file ảnh!")]
        [Display(Name = "Ảnh thu nhỏ")]
        [FirestoreProperty] public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        
        [Display(Name = "Thời lượng")]
        [FirestoreProperty] public int duration { get => _duration; set => _duration = value; }

        [Display(Name = "Lựa chọn Zing")]
        [FirestoreProperty] public bool zingChoice { get => _zingChoice; set => _zingChoice = value; }

        [Display(Name = "Bản riêng tư")]
        [FirestoreProperty] public bool isPrivate { get => _isPrivate; set => _isPrivate = value; }
        
        [Display(Name = "Trước ngày phát hành")]
        [FirestoreProperty] public bool preRelease { get => _preRelease; set => _preRelease = value; }

        [Required(ErrorMessage = "Vui lòng Nghi Ngày phát hành!")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày phát hành")]
        [FirestoreProperty] public long releaseDate { get => _releaseDate; set => _releaseDate = value; }
        
        [Display(Name = "Danh sách mã thể loại")]
        [FirestoreProperty] public List<string> genreIds { get => _genreIds; set => _genreIds = value; }
        
        [Display(Name = "Nhà phân phối")]
        [FirestoreProperty] public string distributor { get => _distributor; set => _distributor = value; }

        [Display(Name = "Danh sách chỉ số")]
        [FirestoreProperty] public List<string> indicators { get => _indicators; set => _indicators = value; }
        [Display(Name = "Bản độc lập")]
        [FirestoreProperty] public bool isIndie { get => _isIndie; set => _isIndie = value; }

        [Display(Name = "Trạng thái phát sóng")]
        [FirestoreProperty] public int streamingStatus { get => _streamingStatus; set => _streamingStatus = value; }

        [Display(Name = "Cho phép quảng cáo âm thanh")]
        [FirestoreProperty] public bool allowAudioAds { get => _allowAudioAds; set => _allowAudioAds = value; }
        
        [Display(Name = "Có lời bài hát")]
        [FirestoreProperty] public bool hasLyric { get => _hasLyric; set => _hasLyric = value; }

        //[Required(ErrorMessage = "Vui lòng Nhập ID Người Dùng!")]
        [Display(Name = "ID người dùng")]
        [FirestoreProperty] public string userid { get => _userid; set => _userid = value; }
       
        [Display(Name = "Danh sách nhạc sĩ")]
        [FirestoreProperty] public List<string> composers { get => _composers; set => _composers = value; }

        [Display(Name = "Album")]
        [FirestoreProperty] public string album { get => _album; set => _album = value; }

        [Display(Name = "Là bản RBT")]
        [FirestoreProperty] public bool isRBT { get => _isRBT; set => _isRBT = value; }

        [Display(Name = "Lượt thích")]
        [FirestoreProperty] public int like { get => _like; set => _like = value; }

        [Display(Name = "Lượt nghe")]
        [FirestoreProperty] public int listen { get => _listen; set => _listen = value; }

        [Display(Name = "Đã thích")]
        [FirestoreProperty] public bool liked { get => _liked; set => _liked = value; }

        [Display(Name = "Số lượt bình luận")]
        [FirestoreProperty] public int comment { get => _comment; set => _comment = value; }
        public DateTime ReleaseDate()
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(this.releaseDate);
        }
        public string Duration()
        {
            TimeSpan t = TimeSpan.FromSeconds(this.duration);
            string res = t.Minutes.ToString("00") + ":" + t.Seconds.ToString("00");
            return t.Hours == 0 ? res : t.Hours.ToString("00") + ":" + res;
        }
        public string GetHtmlArtist()
        {
            return Generator.GenerateArtistLink(this.artists);
        }
        public string GetHtmlAlbum()
        {
            string res = @"
                <a href=""/Album/?encodeId={1}"">
                    <span>
                        <span>{0}</span>
                    </span>
                    <span style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span>
                </a>
            ";
            if (!string.IsNullOrEmpty(this.album))
            {
                PlaylistDTO album = DataHelper.GetPlaylist(this.album);
                if(album != null)
                {
                    return string.Format(res, album.title, album.encodeId);
                }
            }
            return string.Format(res, "", "");
        }
    }
}
