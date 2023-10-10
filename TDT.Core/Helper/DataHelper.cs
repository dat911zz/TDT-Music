using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.Extensions;
using TDT.Core.ModelClone;
using TDT.Core.ServiceImp;

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
        private List<List<SongDTO>> _songRelease = new List<List<SongDTO>>();
        List<PlaylistDTO> _playlistChills = new List<PlaylistDTO>();
        List<PlaylistDTO> _playlistYeuDoi = new List<PlaylistDTO>();
        List<PlaylistDTO> _playlistRemixDances = new List<PlaylistDTO>();
        List<PlaylistDTO> _playlistTamTrang = new List<PlaylistDTO>();


        public int VIEW_COLOR { get => _viewColor; set => _viewColor = value; }
        public Dictionary<string, SongDTO> Songs { 
            get => _songs;
            set
            {
                _songs = value.OrderByDescending(x => x.Value.ReleaseDate()).ToDictionary(x => x.Key, x => x.Value);
            }
        }
        public List<List<SongDTO>> SongRelease {
            get
            {
                if(this._songRelease.Count <= 0)
                {
                    List<SongDTO> arrSong = this.Songs.Values.ToList();
                    List<List<SongDTO>> res = new List<List<SongDTO>>();
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
                    this._songRelease = res;
                }
                return this._songRelease;
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
                if(_playlistChills.Count <= 0)
                {
                    string[] keys = new string[] { "chill" };
                    this._playlistChills = GetPlaylistWithGenreKeys(keys: keys);
                }                
                return this._playlistChills;
            }
        }

        public List<PlaylistDTO> PlaylistRemixDances { 
            get
            {
                if(this._playlistRemixDances.Count <= 0)
                {
                    string[] keys = new string[] { "dance", "remix", "edm" };
                    this._playlistRemixDances = GetPlaylistWithGenreKeys(keys: keys);
                }
                return _playlistRemixDances;
            }
        }

        public List<PlaylistDTO> PlaylistYeuDoi
        {
            get
            {
                if (this._playlistYeuDoi.Count <= 0)
                {
                    string[] keys = new string[] { "v-pop", "rap-viet", "rap-hip-hop" };
                    this._playlistYeuDoi = GetPlaylistWithGenreKeys(keys: keys);
                }
                return _playlistYeuDoi;
            }
        }

        public List<PlaylistDTO> PlaylistTamTrang {
            get
            {
                if (this._playlistTamTrang.Count <= 0)
                {
                    string[] keys = new string[] { "v-pop", "buồn", "đau", "khổ" };
                    this._playlistTamTrang = GetPlaylistWithGenreKeys(keys: keys);
                }
                return _playlistTamTrang;
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

        public async Task<List<string>> pushPlaylist(Playlist playlist)
        {
            List<string> list = new List<string>();
            if (playlist != null)
            {
                string thumbnail = playlist.thumbnail.Split("/").Last();
                string thumbnailM = playlist.thumbnailM.Split("/").Last();
                if (String.IsNullOrEmpty(thumbnail) || String.IsNullOrEmpty(thumbnailM))
                {
                    return list;
                }
                string path_thumbnail = "Images/Playlist/0/" + thumbnail;
                string path_thumbnailM = "Images/Playlist/1/" + thumbnailM;
                list.Add(await FirebaseService.Instance.pushFile(playlist.thumbnail, path_thumbnail));
                list.Add(await FirebaseService.Instance.pushFile(playlist.thumbnailM, path_thumbnailM));
                playlist.thumbnail = path_thumbnail;
                playlist.thumbnailM = path_thumbnailM;
                var pl_push = ConvertService.Instance.convertToPlaylistDTO(playlist);
                FirebaseService.Instance.push("Playlist/" + pl_push.encodeId, pl_push);
            }
            return list;
        }
        public async Task<List<string>> pushArtist(Artist artist)
        {
            List<string> list = new List<string>();
            if (artist != null)
            {
                string thumbnail = artist.thumbnail.Split("/").Last();
                string thumbnailM = artist.thumbnailM.Split("/").Last();
                string cover = artist.cover.Split("/").Last();
                if (String.IsNullOrEmpty(thumbnail) || String.IsNullOrEmpty(thumbnailM) || String.IsNullOrEmpty(cover))
                {
                    return list;
                }
                string path_thumbnail = "Images/Artist/0/" + thumbnail;
                string path_thumbnailM = "Images/Artist/1/" + thumbnailM;
                string path_cover = "Images/Artist/cover/" + cover;
                list.Add(await FirebaseService.Instance.pushFile(artist.thumbnail, path_thumbnail));
                list.Add(await FirebaseService.Instance.pushFile(artist.thumbnailM, path_thumbnailM));
                list.Add(await FirebaseService.Instance.pushFile(artist.cover, path_cover));
                artist.thumbnail = path_thumbnail;
                artist.thumbnailM = path_thumbnailM;
                artist.cover = path_cover;
                var artist_push = ConvertService.Instance.convertToArtistDTO(artist);
                FirebaseService.Instance.push("Artist/" + artist_push.id, artist_push);
            }
            return list;
        }
        public async Task<List<string>> pushSong(Song song)
        {
            List<string> list = new List<string>();
            if (song != null)
            {
                string thumbnail = song.thumbnail.Split("/").Last();
                string thumbnailM = song.thumbnailM.Split("/").Last();
                if (String.IsNullOrEmpty(thumbnail) || String.IsNullOrEmpty(thumbnailM))
                {
                    return list;
                }
                string path_thumbnail = "Images/Song/0/" + thumbnail;
                string path_thumbnailM = "Images/Song/1/" + thumbnailM;
                list.Add(await FirebaseService.Instance.pushFile(song.thumbnail, path_thumbnail));
                list.Add(await FirebaseService.Instance.pushFile(song.thumbnailM, path_thumbnailM));
                song.thumbnail = path_thumbnail;
                song.thumbnailM = path_thumbnailM;
                var song_push = ConvertService.Instance.convertToSongDTO(song);
                FirebaseService.Instance.push("Song/" + song_push.encodeId, song_push);
            }
            return list;
        }
    }
}
