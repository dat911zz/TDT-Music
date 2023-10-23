using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils;

namespace TDT_Music.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index(string id)
        {
            ArtistDTO artist = DataHelper.GetArtist(id);
            if(artist == null)
            {
                this.MessageContainer().AddFlashMessage("Artist không tồn tại", TDT.Core.Ultils.MVCMessage.ToastMessageType.Error);
                return Redirect("/");
            }
            artist.sections = artist.sections.OrderByDescending(s => s.sectionType).ToList();
            if(artist.sections != null && artist.sections.Count > 0)
            {
                foreach (var section in artist.sections)
                {
                    if (section != null)
                    {
                        if(section.sectionType == "song")
                        {
                            ViewData[section.title] = Generator.GenerateArtistNoiBat(artist);
                        }
                        else if(section.sectionType == "artist")
                        {
                            List<ArtistDTO> list = DataHelper.GetArtists(section);
                            if(list != null && list.Count > 0)
                            {
                                ViewData[section.title] = Generator.GenerateArtistsElement(list.Take(5).ToList());
                            }
                        }
                        else if(section.sectionType == "playlist")
                        {
                            List<PlaylistDTO> list = DataHelper.GetPlaylists(section);
                            if(list != null && list.Count > 0)
                            {
                                ViewData[section.title] = Generator.GeneratePlaylist(list.Take(5).ToList());
                            }
                        }
                    }
                }
            }

            PlaylistDTO playlist = APIHelper.Get<PlaylistDTO>(FirestoreService.CL_Playlist, artist.playlistId);
            ViewData["ArtistInfo"] = Generator.GenerateArtistInfo(artist);
            if(playlist != null)
            {
                ViewData["PlaylistRelease"] = Generator.GenerateAlbumSpecial(playlist);
            }
            return View(artist);
        }

        public string GetHtmlSingleEP(ArtistDTO artist)
        {
            SectionDTO section = artist.sections.Where(s => s.title.Equals("Single & EP")).First();
            List<PlaylistDTO> list = DataHelper.GetPlaylists(section);
            return Generator.GeneratePlaylist(list.Take(5).ToList());
        }
        public string GetHtmlAlbum(ArtistDTO artist)
        {
            SectionDTO section = artist.sections.Where(s => s.title.Equals("Album")).First();
            List<PlaylistDTO> list = DataHelper.GetPlaylists(section);
            return Generator.GeneratePlaylist(list.Take(5).ToList());
        }
    }
}
