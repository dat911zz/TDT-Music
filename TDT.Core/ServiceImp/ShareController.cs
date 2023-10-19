﻿using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.DTO.Firestore;
using TDT.Core.Helper;
using TDT.Core.Ultils;

namespace TDT.Core.ServiceImp
{
    public class ShareController : ControllerBase
    {
        public string GenHtmlSongRelease(List<SongDTO> songs)
        {
            if (songs != null)
            {
                DataHelper.Instance.SetSongRelease(songs);
                foreach (SongDTO song in songs)
                {
                    if (!DataHelper.Instance.Songs.Keys.Contains(song.encodeId))
                    {
                        DataHelper.Instance.Songs.Add(song.encodeId, song);
                    }
                }
            }
            List<string> htmls = new List<string>();
            List<List<SongDTO>> songRelease = DataHelper.Instance.GetSongRelease();
            foreach (List<SongDTO> listItem in songRelease)
            {
                htmls.Add(Generator.Instance.GenerateSongRelease(listItem));
            }
            return string.Concat(htmls);
        }
        public JsonResult LoadSongRelease()
        {
            List<SongDTO> songs = new List<SongDTO>();
            Query query = FirestoreService.Instance.OrderByDescending("Song", "releaseDate").Limit(100);
            songs = FirestoreService.Instance.Gets<SongDTO>(query);
            return new JsonResult(GenHtmlSongRelease(songs));
        }
        public JsonResult LoadSongReleaseVN()
        {
            List<SongDTO> songs = new List<SongDTO>();
            Query query = FirestoreService.Instance.WhereArrayContains("Song", "genreIds", DataHelper.GENRE_VIETNAM).OrderByDescending("releaseDate").Limit(100);
            songs = FirestoreService.Instance.Gets<SongDTO>(query);
            return new JsonResult(GenHtmlSongRelease(songs));
        }
        public JsonResult LoadGenre()
        {
            if(DataHelper.Instance.Genres.Count <= 0)
            {
                HttpService httpService = new HttpService(APICallHelper.DOMAIN + "Genre/load");
                string json = httpService.getJson();
                List<Genre> genres = ConvertService.Instance.convertToObjectFromJson<List<Genre>>(json);
                if(genres != null)
                {
                    foreach (Genre genre in genres)
                    {
                        if(!DataHelper.Instance.Genres.Keys.Contains(genre.id))
                        {
                            DataHelper.Instance.Genres.Add(genre.id, genre);
                        }
                        else
                        {
                            DataHelper.Instance.Genres[genre.id] = genre;
                        }
                    }
                }
            }
            return new JsonResult("true");
        }
        public JsonResult LoadPlaylist()
        {
            List<PlaylistDTO> playlists = new List<PlaylistDTO>();
            if (DataHelper.Instance.Playlists.Count <= 0)
            {
                HttpService httpService = new HttpService(APICallHelper.DOMAIN + "Playlist/load");
                string json = httpService.getJson();
                playlists = ConvertService.Instance.convertToObjectFromJson<List<PlaylistDTO>>(json);
            }
            if(playlists != null)
            {
                foreach (PlaylistDTO playlist in playlists)
                {
                    if (!DataHelper.Instance.Playlists.Keys.Contains(playlist.encodeId))
                    {
                        DataHelper.Instance.Playlists.Add(playlist.encodeId, playlist);
                    }
                }
            }
            return new JsonResult("true");
        }
        public JsonResult LoadArtist()
        {
            List<ArtistDTO> artists = new List<ArtistDTO>();
            HttpService httpService = new HttpService(APICallHelper.DOMAIN + "Artist/load");
            string json = httpService.getJson();
            artists = ConvertService.Instance.convertToObjectFromJson<List<ArtistDTO>>(json);
            if (artists != null)
            {
                foreach (ArtistDTO artist in artists)
                {
                    if (!DataHelper.Instance.Artists.Keys.Contains(artist.id))
                    {
                        try
                        {
                            DataHelper.Instance.Artists.Add(artist.id, artist);
                        }catch { }
                    }
                }
            }
            return new JsonResult("true");
        }

        // Load MusicManagementController


        public JsonResult GetHtmlPlaylistChill()
        {
            return new JsonResult(Generator.Instance.GeneratePlaylist(DataHelper.Instance.PlaylistChills.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistYeuDoi()
        {
            return new JsonResult(Generator.Instance.GeneratePlaylist(DataHelper.Instance.PlaylistYeuDoi.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistRemixDance()
        {
            return new JsonResult(Generator.Instance.GeneratePlaylist(DataHelper.Instance.PlaylistRemixDances.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlPlaylistTamTrang()
        {
            return new JsonResult(Generator.Instance.GeneratePlaylist(DataHelper.Instance.PlaylistTamTrang.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlArtistThinhHanh()
        {
            return new JsonResult(Generator.Instance.GenerateArtist(DataHelper.Instance.ArtistThinhHanh));
        }
    }
}
