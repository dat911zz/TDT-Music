using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Mã Hóa")]
        public string encodeId { get => _encodeId; set => _encodeId = value; }

        [Display(Name = "Tiêu đề")]
        public string title { get => _title; set => _title = value; }

        [Display(Name = "Bí danh")]
        public string alias { get => _alias; set => _alias = value; }

        [Display(Name = "Làm chính thức")]
        public bool isOffical { get => _isOffical; set => _isOffical = value; }

        [Display(Name = "Tên người dùng")]
        public string username { get => _username; set => _username = value; }
        [Display(Name = "Tên nghệ sĩ")]
        public string artistsNames { get => _artistsNames; set => _artistsNames = value; }
        
        [Display(Name = "Danh sách nghệ sĩ")]
        public Dictionary<string, string> artists { get => _artists; set => _artists = value; }
        
        [Display(Name = "Là toàn cầu")]
        public bool isWorldWide { get => _isWorldWide; set => _isWorldWide = value; }
        
        [Display(Name = "Ảnh thu nhỏ M")]
        public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }

        [Display(Name = "Liên kết")]
        public string link { get => _link; set => _link = value; }

        [Display(Name = "Ảnh thu nhỏ")]
        public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        
        [Display(Name = "Thời lượng")]
        public int duration { get => _duration; set => _duration = value; }

        [Display(Name = "Lựa chọn Zing")]
        public bool zingChoice { get => _zingChoice; set => _zingChoice = value; }

        [Display(Name = "Là bản riêng tư")]
        public bool isPrivate { get => _isPrivate; set => _isPrivate = value; }
        
        [Display(Name = "Trước ngày phát hành")]
        public bool preRelease { get => _preRelease; set => _preRelease = value; }
        
        [Display(Name = "Ngày phát hành")]
        public string releaseDate { get => _releaseDate; set => _releaseDate = value; }
        
        [Display(Name = "Danh sách mã thể loại")]
        public List<string> genreIds { get => _genreIds; set => _genreIds = value; }
        
        [Display(Name = "Nhà phân phối")]
        public string distributor { get => _distributor; set => _distributor = value; }

        [Display(Name = "Danh sách chỉ số")]
        public List<object> indicators { get => _indicators; set => _indicators = value; }
        [Display(Name = "Là bản độc lập")]
        public bool isIndie { get => _isIndie; set => _isIndie = value; }

        [Display(Name = "Trạng thái phát sóng")]
        public int streamingStatus { get => _streamingStatus; set => _streamingStatus = value; }

        [Display(Name = "Cho phép quảng cáo âm thanh")]
        public bool allowAudioAds { get => _allowAudioAds; set => _allowAudioAds = value; }
        
        [Display(Name = "Có lời bài hát")]
        public bool hasLyric { get => _hasLyric; set => _hasLyric = value; }

        [Display(Name = "ID người dùng")]
        public int userid { get => _userid; set => _userid = value; }
       
        [Display(Name = "Danh sách nhạc sĩ")]
        public Dictionary<string, string> composers { get => _composers; set => _composers = value; }

        [Display(Name = "Album")]
        public string album { get => _album; set => _album = value; }

        [Display(Name = "Là bản RBT")]
        public bool isRBT { get => _isRBT; set => _isRBT = value; }

        [Display(Name = "Lượt thích")]
        public int like { get => _like; set => _like = value; }

        [Display(Name = "Lượt nghe")]
        public int listen { get => _listen; set => _listen = value; }

        [Display(Name = "Đã thích")]
        public bool liked { get => _liked; set => _liked = value; }

        [Display(Name = "Số lượt bình luận")]
        public int comment { get => _comment; set => _comment = value; }
    }
}
