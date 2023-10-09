﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private int _viewColor;
        public Dictionary<string, Genre> Genres = new Dictionary<string, Genre>();
        public Dictionary<string, ArtistDTO> Artists = new Dictionary<string, ArtistDTO>();
        public Dictionary<string, string> ThumbSong = new Dictionary<string, string>();
        public Dictionary<string, string> ThumbPlaylist = new Dictionary<string, string>();
        private Dictionary<string,SongDTO> _songs = new Dictionary<string, SongDTO>();
        private Dictionary<string,PlaylistDTO> _playlists = new Dictionary<string, PlaylistDTO>();
        private List<List<SongDTO>> _songRelease = new List<List<SongDTO>>();


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
        public List<SongDTO> Song100Release
        {
            get
            {
                return this.Songs.Values.Take(100).ToList();
            }
        }

        public Dictionary<string, PlaylistDTO> Playlists {
            get => _playlists;
            set
            {
                _playlists = value.OrderByDescending(x => x.Value.contentLastUpdate).ToDictionary(x => x.Key, x => x.Value);
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
