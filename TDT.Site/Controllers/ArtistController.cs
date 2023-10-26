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
using static System.Collections.Specialized.BitVector32;

namespace TDT.Site.Controllers
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
            PlaylistDTO playlist = APIHelper.Get<PlaylistDTO>(FirestoreService.CL_Playlist, artist.playlistId);
            ViewData["ArtistInfo"] = Generator.GenerateArtistInfo(artist);
            if(playlist != null)
            {
                ViewData["PlaylistRelease"] = Generator.GenerateAlbumSpecial(playlist);
            }
            string json = JsonConvert.SerializeObject(artist.sections.Where(s => s.items != null && s.items.Count > 0).ToList());
            ViewData["ArraySection"] = json;
            return View(artist);
        }

        public string GetHtmlSection(string artistId, string titleSection)
        {
            ArtistDTO artist = DataHelper.GetArtist(artistId);
            if (artist == null || artist.sections == null || artist.sections.Count <= 0)
                return string.Empty;
            SectionDTO section = artist.sections.Where(s => s.title.Equals(titleSection)).FirstOrDefault();
            if (section != null)
            {
                string res = "";
                if (section.sectionType == "song")
                {
                    res = Generator.GenerateArtistNoiBat(artist);
                }
                else if (section.sectionType == "artist")
                {
                    List<ArtistDTO> list = DataHelper.GetArtists(section);
                    if (list != null && list.Count > 0)
                    {
                        res = Generator.GenerateArtistsElement(list.Take(5).ToList());
                    }
                }
                else if (section.sectionType == "playlist")
                {
                    List<PlaylistDTO> list = DataHelper.GetPlaylists(section);
                    if (list != null && list.Count > 0)
                    {
                        res = Generator.GeneratePlaylistsElement(list.Take(5).ToList());
                    }
                }
                return res;
            }
            return string.Empty;
        }
    }
}
