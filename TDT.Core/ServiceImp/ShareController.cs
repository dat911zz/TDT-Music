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
                htmls.Add(Generator.GenerateSongRelease(listItem));
            }
            return string.Concat(htmls);
        }
        public JsonResult LoadSongReleaseAll()
        {
            List<SongDTO> songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}/LoadSongReleaseAll");
            return new JsonResult(GenHtmlSongRelease(songs));
        }
        public JsonResult LoadSongReleaseVN()
        {
            List<SongDTO> songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}/LoadSongReleaseVN");
            return new JsonResult(GenHtmlSongRelease(songs));
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
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistChills.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistYeuDoi()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistYeuDoi.Take(5).ToList()));
        }
        public JsonResult GetHtmlPlaylistRemixDance()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistRemixDances.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlPlaylistTamTrang()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistTamTrang.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlArtistThinhHanh()
        {
            return new JsonResult(Generator.GenerateArtist(DataHelper.Instance.ArtistThinhHanh));
        }
        
        public JsonResult GetHtmlTuyenTap(string id)
        {
            ArtistDTO artist = DataHelper.GetArtist(id);
            SectionDTO section = artist.sections.Where(s => s.title.Equals("Tuyển tập")).First();
            List<PlaylistDTO> list = DataHelper.GetPlaylists(section);
             return new JsonResult(Generator.GeneratePlaylist(list.Take(5).ToList()));
        }
        public JsonResult GetHtmlCoTheThich(string id)
        {
            ArtistDTO artist = DataHelper.GetArtist(id);
            SectionDTO section = artist.sections.Where(s => s.title.Equals("Bạn Có Thể Thích")).First();
            List<ArtistDTO> list = DataHelper.GetArtists(section);
            return new JsonResult(Generator.GenerateArtist(list.Take(5).ToList()));
        }

        public JsonResult GetHtmlArtistInfoFooter(string id)
        {
            ArtistDTO artist = DataHelper.GetArtist(id);
            return new JsonResult(artist == null ? "" : Generator.GenerateArtistInfo_footer(artist));
        }
        public JsonResult GetHtmlPlaylistNoiBat()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistNoiBat.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlPlaylistHomNayBanTheNao()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistHomNayBanTheNao.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlPlaylistNganNgaCauCa()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistNganNgaCauCa.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlPlaylistAmThanhLofi()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistAmThanhLofi.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlPlaylistMotChutKhongLoi()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistMotChutKhongLoi.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlPlaylistYen()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistYen.Take(5).ToList(), 1));
        }
        public JsonResult GetHtmlPlaylistChillCungDance()
        {
            return new JsonResult(Generator.GeneratePlaylist(DataHelper.Instance.PlaylistChillCungDance.Take(5).ToList(), 1));
        }
    }
}
