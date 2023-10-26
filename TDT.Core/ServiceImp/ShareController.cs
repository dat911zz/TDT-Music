using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.Ultils;

namespace TDT.Core.ServiceImp
{
    public class ShareController : ControllerBase
    {
        public void LoadSongReleaseAll()
        {
            List<SongDTO> songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}/LoadSongReleaseAll");
            DataHelper.Instance.InsertToSongs(songs);
            DataHelper.Instance.SetSongReleaseAll(songs);
        }
        public void LoadSongReleaseVN()
        {
            List<SongDTO> songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}/LoadSongReleaseVN");
            DataHelper.Instance.InsertToSongs(songs);
            DataHelper.Instance.SetSongReleaseVN(songs);
        }
        public string GenHtmlSongRelease(List<List<SongDTO>> songRelease)
        {
            List<string> htmls = new List<string>();
            foreach (List<SongDTO> listItem in songRelease)
            {
                htmls.Add(Generator.GenerateSongRelease(listItem));
            }
            return string.Concat(htmls);
        }
        public JsonResult GetHtmlSongReleaseAll()
        {
            List<List<SongDTO>> songRelease;
            if (DataHelper.Instance.GetSongReleaseAllOne().Count > 0)
            {
                songRelease = DataHelper.Instance.GetSongAllRelease();
            }
            else
            {
                LoadSongReleaseAll();
                songRelease = DataHelper.Instance.GetSongAllRelease();
            }
            return new JsonResult(GenHtmlSongRelease(songRelease));
        }
        public JsonResult GetHtmlSongReleaseVN()
        {
            List<List<SongDTO>> songRelease;
            if (DataHelper.Instance.GetSongReleaseVNOne().Count > 0)
            {
                songRelease = DataHelper.Instance.GetSongVNRelease();
            }
            else
            {
                LoadSongReleaseVN();
                songRelease = DataHelper.Instance.GetSongVNRelease();
            }
            return new JsonResult(GenHtmlSongRelease(songRelease));
        }
        public JsonResult LoadPageSongReleaseAll(int? page)
        {
            page = page ?? 1;
            if(DataHelper.Instance.GetSongReleaseAllOne().Count <= 0)
            {
                LoadSongReleaseAll();
            }
            List<SongDTO> songs = DataHelper.Instance.GetSongReleaseAllOne().Skip((int)((page - 1) * 5)).Take(5).ToList();
            return new JsonResult(Generator.GeneratePageSong(songs));
        }
        public JsonResult LoadPageSongReleaseVN(int? page)
        {
            page = page ?? 1;
            if (DataHelper.Instance.GetSongReleaseVNOne().Count <= 0)
            {
                LoadSongReleaseVN();
            }
            List<SongDTO> songs = DataHelper.Instance.GetSongReleaseVNOne().Skip((int)((page - 1) * 5)).Take(5).ToList();
            return new JsonResult(Generator.GeneratePageSong(songs));
        }
        public JsonResult LoadSongs()
        {
            List<SongDTO> songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}");
            if(songs != null)
            {
                foreach(SongDTO song in songs)
                {
                    try
                    {
                        if(!DataHelper.Instance.Songs.Keys.Contains(song.encodeId))
                        {
                            DataHelper.Instance.Songs.Add(song.encodeId, song);
                        }
                    }
                    catch { }
                }
                foreach (SongDTO song in songs)
                {
                    try
                    {
                        if (!DataHelper.Instance.MP3.ContainsKey(song.encodeId))
                        {
                            string url = DataHelper.GetMP3(song.encodeId);
                        }
                    }
                    catch { }
                }
            }
            return new JsonResult("true");
        }
        public JsonResult LoadGenre()
        {
            if(DataHelper.Instance.Genres.Count <= 0)
            {
                List<Genre> genres = APIHelper.Gets<Genre>($"{FirestoreService.CL_Genre}");
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
                playlists = APIHelper.Gets<PlaylistDTO>($"{FirestoreService.CL_Playlist}/load");
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
            List<ArtistDTO> artists = APIHelper.Gets<ArtistDTO>($"{FirestoreService.CL_Artist}/Load");
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
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistChills.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistYeuDoi()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistYeuDoi.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistRemixDance()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistRemixDances.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistTamTrang()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistTamTrang.Take(5).ToList()));
        }
        public JsonResult GetHtmlArtistThinhHanh()
        {
            return new JsonResult(Generator.GenerateArtist(DataHelper.Instance.ArtistThinhHanh));
        }
        
        public JsonResult GetHtmlPlaylistNoiBat()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistNoiBat.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistHomNayBanTheNao()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistHomNayBanTheNao.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistNganNgaCauCa()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistNganNgaCauCa.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistAmThanhLofi()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistAmThanhLofi.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistMotChutKhongLoi()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistMotChutKhongLoi.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistYen()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistYen.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistChillCungDance()
        {
            return new JsonResult(Generator.GeneratePlaylistsElement(DataHelper.Instance.PlaylistChillCungDance.Take(5).ToList()));
        }
        public string LoadImg(string encodeId, string thumbpath)
        {
            return DataHelper.GetThumbnailSong(encodeId, thumbpath);
        }
    }
}
