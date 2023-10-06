using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.ModelClone;

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
        public static readonly string DOMAIN_API = "https://localhost:44300";
        private int _viewColor;
        public Dictionary<string, ArtistDTO> Artists = new Dictionary<string, ArtistDTO>();
        public Dictionary<string, string> ThumbSong = new Dictionary<string, string>();
        private Dictionary<string,SongDTO> _songs = new Dictionary<string, SongDTO>();


        public int VIEW_COLOR { get => _viewColor; set => _viewColor = value; }
        public Dictionary<string, SongDTO> Songs { 
            get => _songs;
            set
            {
                _songs = value.OrderByDescending(x => x.Value.releaseDate).ToDictionary(x => x.Key, x => x.Value);
            }
        }
        public List<List<SongDTO>> SongRelease {
            get
            {
                List<List<SongDTO>> res = new List<List<SongDTO>>();
                int take = 4;
                for(int i = 0; i < 3; i++)
                {
                    res.Add(this.Songs.Values.Skip(i * take).Take(take).ToList());
                }
                return res;
            }
        }
        public List<SongDTO> Song100Release
        {
            get
            {
                return this.Songs.Values.Take(100).ToList();
            }
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
