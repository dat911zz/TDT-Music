﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Dictionary<string, Genre> Genres = new Dictionary<string, Genre>();
        public Dictionary<string, ArtistDTO> Artists = new Dictionary<string, ArtistDTO>();
        public Dictionary<string, string> ThumbSong = new Dictionary<string, string>();
        public Dictionary<string, string> ThumbPlaylist = new Dictionary<string, string>();
        public Dictionary<string, string> ThumbArtist = new Dictionary<string, string>();
        private Dictionary<string,SongDTO> _songs = new Dictionary<string, SongDTO>();
        private Dictionary<string,PlaylistDTO> _playlists = new Dictionary<string, PlaylistDTO>();
        private List<SongDTO> _songRelease = new List<SongDTO>();

        
        public int VIEW_COLOR { get => _viewColor; set => _viewColor = value; }
        public Dictionary<string, SongDTO> Songs { get => _songs; set => _songs = value; }
        public List<List<SongDTO>> GetSongRelease() {
            List<List<SongDTO>> res = new List<List<SongDTO>>();
            List<SongDTO> arrSong = this._songRelease;
            int take = 4;
            int iStartArr = 0;
            for (int i = 0; i < 3; i++)
            {
                List<SongDTO> res_s = new List<SongDTO>();
                string releaseDate = "";
                int count = 0;
                for (int j = iStartArr; j < arrSong.Count; j++)
                {
                    iStartArr++;
                    SongDTO itemCheck = arrSong[j];
                    if (!releaseDate.Equals(itemCheck.releaseDate) || (releaseDate.Equals(itemCheck.releaseDate) && !res_s.Select(x => x.thumbnail).Contains(itemCheck.thumbnail)))
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
        public void SetSongRelease(List<SongDTO> songs)
        {
            if(songs != null)
            {
                this._songRelease = songs;
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

        public List<Genre> GetGenre(params string[] contains)
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

        private List<PlaylistDTO> GetPlaylistWithGenreKeys(bool all = false, params string[] keys)
        {
            if(this.Genres.Count > 0)
            {
                List<string> genresIds = GetGenre(keys).Select(x => x.id).ToList();
                string idVietNam = GetGenre("việt nam").Select(x => x.id).First();
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
            PlaylistDTO playlist = APIHelper.Get<PlaylistDTO>(FirestoreService.CL_Playlist, id);
            if (playlist != null)
            {
                try
                {
                    DataHelper.Instance.Playlists.Add(id, playlist);
                }
                catch { }
            }
            return playlist;
        }
        public static SongDTO GetSong(string id)
        {
            if (DataHelper.Instance.Songs.Keys.Contains(id))
                return DataHelper.Instance.Songs[id];
            SongDTO song = APIHelper.Get<SongDTO>(FirestoreService.CL_Song, id);
            if (song != null)
            {
                try
                {
                    DataHelper.Instance.Songs.Add(id, song);
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
    }
}
