using System;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils;

namespace TDT.Core.Helper
{
    public class DataHelper
    {

        private static DataHelper _instance;
        private DataHelper()
        {
            this._viewColor = 0;
        }
        public static DataHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataHelper();
                return _instance;
            }
        }

        public static string COLOR_DEFAULT_STEP = "#000fff";
        private int _viewColor;
        public List<TypePlaylistDTO> Top100 = new List<TypePlaylistDTO>();
        public Dictionary<string, Genre> Genres = new Dictionary<string, Genre>();
        public Dictionary<string, ArtistDTO> Artists = new Dictionary<string, ArtistDTO>();

        public Dictionary<string, string> ThumbSong = new Dictionary<string, string>();
        public Dictionary<string, string> ThumbPlaylist = new Dictionary<string, string>();
        public Dictionary<string, string> ThumbArtist = new Dictionary<string, string>();
        public Dictionary<string, string> MP3 = new Dictionary<string, string>();
        private Dictionary<string,SongDTO> _songs = new Dictionary<string, SongDTO>();
        private Dictionary<string,SongDTO> _songsNull = new Dictionary<string, SongDTO>();
        private Dictionary<string,PlaylistDTO> _playlists = new Dictionary<string, PlaylistDTO>();
        private Dictionary<string,PlaylistDTO> _playlistsNull = new Dictionary<string, PlaylistDTO>();
        private List<SongDTO> _songReleaseAll = new List<SongDTO>();
        private List<SongDTO> _songReleaseVN = new List<SongDTO>();


        public int VIEW_COLOR { get => _viewColor; set => _viewColor = value; }
        public Dictionary<string, SongDTO> Songs { get => _songs; set => _songs = value; }
        public List<SongDTO> GetSongReleaseAllOne()
        {
            return this._songReleaseAll;
        }
        public List<List<SongDTO>> GetSongAllRelease() {
            List<List<SongDTO>> res = new List<List<SongDTO>>();
            List<SongDTO> arrSong = this._songReleaseAll;
            int take = 4;
            int iStartArr = 0;
            for (int i = 0; i < 3; i++)
            {
                List<SongDTO> res_s = new List<SongDTO>();
                long releaseDate = 0;
                int count = 0;
                for (int j = iStartArr; j < arrSong.Count; j++)
                {
                    iStartArr++;
                    SongDTO itemCheck = arrSong[j];
                    if (!releaseDate.Equals(itemCheck.releaseDate) || (releaseDate.Equals(itemCheck.releaseDate)))
                    {
                        res_s.Add(itemCheck);
                        count++;
                    }
                    releaseDate = itemCheck.releaseDate;
                    if (count >= take)
                        break;
                }
                res.Add(res_s);
            }
            return res;
        }
        public void SetSongReleaseAll(List<SongDTO> songs)
        {
            if (songs != null)
            {
                this._songReleaseAll = songs;
            }
        }
        public List<SongDTO> GetSongReleaseVNOne()
        {
            return this._songReleaseVN;
        }
        public List<List<SongDTO>> GetSongVNRelease()
        {
            List<List<SongDTO>> res = new List<List<SongDTO>>();
            List<SongDTO> arrSong = this._songReleaseVN;
            int take = 4;
            int iStartArr = 0;
            for (int i = 0; i < 3; i++)
            {
                List<SongDTO> res_s = new List<SongDTO>();
                long releaseDate = 0;
                int count = 0;
                for (int j = iStartArr; j < arrSong.Count; j++)
                {
                    iStartArr++;
                    SongDTO itemCheck = arrSong[j];
                    if (!releaseDate.Equals(itemCheck.releaseDate) || (releaseDate.Equals(itemCheck.releaseDate)))
                    {
                        res_s.Add(itemCheck);
                        count++;
                    }
                    releaseDate = itemCheck.releaseDate;
                    if (count >= take)
                        break;
                }
                res.Add(res_s);
            }
            return res;
        }
        public void SetSongReleaseVN(List<SongDTO> songs)
        {
            if (songs != null)
            {
                this._songReleaseVN = songs;
            }
        }

        public Dictionary<string, PlaylistDTO> Playlists {
            get => _playlists;
            set
            {
                _playlists = value.OrderByDescending(x => x.Value.contentLastUpdate).ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public List<PlaylistDTO> PlaylistChills
        {
            get
            {
                string[] keys = new string[] { "chill" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }

        public List<PlaylistDTO> PlaylistRemixDances { 
            get
            {
                string[] keys = new string[] { "dance", "remix", "edm" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }

        public List<PlaylistDTO> PlaylistYeuDoi
        {
            get
            {
                string[] keys = new string[] { "v-pop", "rap-viet", "rap-hip-hop" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }

        public List<PlaylistDTO> PlaylistTamTrang {
            get
            {
                string[] keys = new string[] { "v-pop", "buồn", "đau", "khổ" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }
        public List<PlaylistDTO> PlaylistNoiBat
        {
            get
            {
                string[] keys = new string[] { "v-pop", "remix", "rap-viet" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }
        public List<PlaylistDTO> PlaylistHomNayBanTheNao
        {
            get
            {
                string[] keys = new string[] { "chill", "tinh-yeu" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }

        public List<PlaylistDTO> PlaylistNganNgaCauCa
        {
            get
            {
                string[] keys = new string[] { "chill", "vui" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }
        public List<PlaylistDTO> PlaylistAmThanhLofi
        {
            get
            {
                string[] keys = new string[] { "lofi", "de-ngu", "v-pop", "acoustic", "tinh-yeu" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }
        public List<PlaylistDTO> PlaylistMotChutKhongLoi
        {
            get
            {
                string[] keys = new string[] { "khong-loi", "yeu-binh", "chua-lanh" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }
        public List<PlaylistDTO> PlaylistYen
        {
            get
            {
                string[] keys = new string[] { "yen", "thien-nhien", "mua", "ti-tach", "lieu-lo", "v-pop", "acoustic" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }
        public List<PlaylistDTO> PlaylistChillCungDance
        {
            get
            {
                string[] keys = new string[] { "chill", "thu-gian", "EDM", "acoustic" };
                return GetPlaylistWithGenreKeys(keys: keys);
            }
        }
        public List<ArtistDTO> ArtistThinhHanh
        {
            get
            {
                if(this.Artists.Values.Count <= 0)
                {
                    new ShareController().LoadArtist();
                }
                return this.Artists.Values.Where(x => x.national.ToLower().Contains("việt nam")).OrderByDescending(x => x.totalFollow).Take(5).ToList();
            }
        }

        public Dictionary<string, SongDTO> SongsNull { get => _songsNull; set => _songsNull = value; }
        public Dictionary<string, PlaylistDTO> PlaylistsNull { get => _playlistsNull; set => _playlistsNull = value; }

        public void InsertToSongs(List<SongDTO> songs)
        {
            if (songs != null)
            {
                foreach (var item in songs)
                {
                    if (!this.Songs.Keys.Contains(item.encodeId))
                    {
                        try
                        {
                            this.Songs.Add(item.encodeId, item);
                        }
                        catch { }
                    }
                }
            }
        }
        public List<Genre> GetGenreWithKey(params string[] contains)
        {
            var _contains = contains.Select(x => x.ToLower()).ToList();
            List<Genre> res = new List<Genre>();
            foreach (var item in this.Genres.Values)
            {
                foreach (var c in _contains)
                {
                    if(item.alias.ToLower().Contains(c) || item.title.ToLower().Contains(c))
                    {
                        res.Add(item);
                        break;
                    }
                }
            }
            return res;
        }

        public List<PlaylistDTO> GetPlaylistWithGenreKeys(bool all = false, params string[] keys)
        {
            if(this.Genres.Count > 0)
            {
                List<string> genresIds = GetGenreWithKey(keys).Select(x => x.id).ToList();
                string idVietNam = GetGenreWithKey("việt nam").Select(x => x.id).First();
                List<PlaylistDTO> plGen = this._playlists.Values.Where(x => x.genreIds.Where(g => genresIds.Contains(g)).Count() > 0).ToList();
                List<string> ids = plGen.Select(x => x.encodeId).ToList();
                List<PlaylistDTO> pl = this._playlists.Values.Where(x => keys.Where(k => x.title.ToLower().Contains(k)).Count() > 0 && !ids.Contains(x.encodeId)).ToList();
                plGen.AddRange(pl);
                plGen.Shuffle();
                if (all)
                    return plGen;
                return plGen.Where(x => x.genreIds.Contains(idVietNam)).ToList();
            }
            return new List<PlaylistDTO>();
        }

        public static List<Genre> GetGenres(List<string> ids)
        {
            List<Genre> genres = new List<Genre>();
            if(ids != null)
            {
                foreach(string id in ids)
                {
                    Genre genre = GetGenre(id);
                    if(genre != null)
                        genres.Add(genre);
                }
            }
            return genres;
        }

        public static List<PlaylistDTO> GetPlaylistSuggest(PlaylistDTO playlist)
        {
            if(playlist != null && playlist.genreIds != null)
            {
                List<Genre> genres = GetGenres(playlist.genreIds);
                if (genres != null && genres.Count > 0)
                    return DataHelper.Instance.GetPlaylistWithGenreKeys(keys: genres.Select(g => g.alias).ToArray());
            }
            return null;
        }

        public static Genre GetGenre(string id)
        {
            if (DataHelper.Instance.Genres.Keys.Contains(id))
                return DataHelper.Instance.Genres[id];
            Genre genre = APIHelper.Get<Genre>(FirestoreService.CL_Genre, id);
            if (genre != null)
            {
                try
                {
                    DataHelper.Instance.Genres.Add(id, genre);
                }
                catch { }
            }
            return genre;
        }
        public static ArtistDTO GetArtist(string id)
        {
            if(DataHelper.Instance.Artists.Keys.Contains(id))
                return DataHelper.Instance.Artists[id];
            ArtistDTO artist = APIHelper.Get<ArtistDTO>(FirestoreService.CL_Artist, id);
            if(artist != null)
            {
                try
                {
                    DataHelper.Instance.Artists.Add(id, artist);
                }
                catch { }
            }
            return artist;
        }
        public static PlaylistDTO GetPlaylist(string id)
        {
            if (DataHelper.Instance.Playlists.Keys.Contains(id))
                return DataHelper.Instance.Playlists[id];
            if (DataHelper.Instance.PlaylistsNull.Keys.Contains(id))
                return null;
            PlaylistDTO playlist = APIHelper.Get<PlaylistDTO>(FirestoreService.CL_Playlist, id);
            if (playlist != null)
            {
                try
                {
                    DataHelper.Instance.Playlists.Add(id, playlist);
                }
                catch { }
            }
            else
            {
                try
                {
                    DataHelper.Instance.PlaylistsNull.Add(id, playlist);
                }
                catch { }
            }
            return playlist;
        }
        public static SongDTO GetSong(string id)
        {
            if (DataHelper.Instance.Songs.Keys.Contains(id))
                return DataHelper.Instance.Songs[id];
            if (DataHelper.Instance.SongsNull.Keys.Contains(id))
                return null;
            SongDTO song = APIHelper.Get<SongDTO>(FirestoreService.CL_Song, id);
            if (song != null)
            {
                try
                {
                    DataHelper.Instance.Songs.Add(id, song);
                }
                catch { }
            }
            else
            {
                try
                {
                    DataHelper.Instance.SongsNull.Add(id, song);
                }
                catch { }
            }
            return song;
        }
        public static List<PlaylistDTO> GetPlaylists(SectionDTO section)
        {
            List<PlaylistDTO> list = new List<PlaylistDTO>();
            if (section != null)
            {
                foreach (var keyPlaylist in section.items)
                {
                    var playlist = GetPlaylist(keyPlaylist);
                    if (playlist != null)
                    {
                        list.Add(playlist);
                    }
                }
            }
            return list;
        }
        public static List<ArtistDTO> GetArtists(SectionDTO section)
        {
            List<ArtistDTO> list = new List<ArtistDTO>();
            if (section != null)
            {
                foreach (var key in section.items)
                {
                    var artist = GetArtist(key);
                    if (artist != null)
                    {
                        list.Add(artist);
                    }
                }
            }
            return list;
        }
        public static List<SongDTO> GetSongs(SectionDTO section)
        {
            List<SongDTO> list = new List<SongDTO>();
            if (section != null)
            {
                foreach (var key in section.items)
                {
                    var song = GetSong(key);
                    if (song != null)
                    {
                        list.Add(song);
                    }
                }
            }
            return list;
        }
        public static string GetThumbnailPlaylist(PlaylistDTO playlist)
        {
            if (DataHelper.Instance.ThumbPlaylist.Keys.Contains(playlist.encodeId))
                return DataHelper.Instance.ThumbPlaylist[playlist.encodeId];
            string url = FirebaseService.Instance.getStorage(playlist.thumbnailM);
            try
            {
                DataHelper.Instance.ThumbPlaylist.Add(playlist.encodeId, url);
            }
            catch { }
            return url;
        }
        public static string GetThumbnailSong(string encodeId, string thumbnailPath)
        {
            if (DataHelper.Instance.ThumbSong.Keys.Contains(encodeId))
                return DataHelper.Instance.ThumbSong[encodeId];
            string url = FirebaseService.Instance.getStorage(thumbnailPath);
            try
            {
                DataHelper.Instance.ThumbSong.Add(encodeId, url);
            }
            catch { }
            return url;
        }
        public static string GetThumbnailArtist(string id, string thumbnailPath)
        {
            if (DataHelper.Instance.ThumbArtist.Keys.Contains(id))
                return DataHelper.Instance.ThumbArtist[id];
            string url = FirebaseService.Instance.getStorage(thumbnailPath);
            try
            {
                DataHelper.Instance.ThumbArtist.Add(id, url);
            }
            catch { }
            return url;
        }
        public static string GetMP3(string encodeId)
        {
            if (DataHelper.Instance.MP3.ContainsKey(encodeId))
                return DataHelper.Instance.MP3[encodeId];
            string url = FirebaseService.Instance.getStorage($"MP3/{encodeId}.mp3");
            try
            {
                DataHelper.Instance.MP3.Add(encodeId, url);
            }catch { }
            return url;
        }
    }
}
