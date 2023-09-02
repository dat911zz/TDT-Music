using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDT.Core.ModelClone;
using TDT.Core.DTO;
using TDT.Core.Helper;
using TDT.CAdmin.Models;

namespace TDT.CAdmin.Controllers
{
    public class CrawlDataController : Controller
    {
        public static IHubContext<RealtimeHub> _hubContext;
        public CrawlDataController(IHubContext<RealtimeHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpdateTypePlaylist()
        {
            try
            {
                var top100 = HttpClone.Intance.getTop100().Result;
                List<TypePlayList> typePlayLists = JsonConvert.DeserializeObject<List<TypePlayList>>(top100);
                int i = 1;
                foreach (TypePlayList tp in typePlayLists)
                {
                    await SendMessageRealtime($"Đang thực hiện TypePlaylist: {tp.title} - {i++}", DataHelper.COLOR_DEFAULT_STEP);
                    TypePlaylistDTO value = ConvertService.Instance.convertToTypePlayListDTO(tp);
                    TypePlaylistDTO cur = FirebaseService.Instance.getSingleValue<TypePlaylistDTO>($"/TypePlaylist/{tp.title}").Result;
                    if (!cur.compare(value))
                    {
                        FirebaseService.Instance.push("TypePlaylist/" + value.title, value);
                        await SendMessageRealtime($"Cập nhật TypePlaylist: {cur.title}");
                    }
                }
            }
            catch(Exception e)
            {
                await SendMessageRealtime(e.Message, "red");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdatePlaylist()
        {
            var value = FirebaseService.Instance.getDictionary("TypePlaylist");
            var playlistDictionary = FirebaseService.Instance.getDictionary("Playlist");
            var genreDictionary = FirebaseService.Instance.getDictionary("Genre");

            var listIdPlaylist = playlistDictionary == null ? new List<string>() : playlistDictionary.Keys.ToList();
            var listIdGenre = genreDictionary == null ? new List<string>() : genreDictionary.Keys.ToList();
            int i = 1;
            await SendMessageRealtime($"Tổng số Playlist: {listIdPlaylist.Count}");
            foreach (KeyValuePair<string, object> kvp in value)
            {
                TypePlaylistDTO typePlayListDTO = ConvertService.Instance.convertToObjectFromJson<TypePlaylistDTO>(kvp.Value.ToString());
                Dictionary<string, string> arrPlaylist = typePlayListDTO.playlists;
                foreach (KeyValuePair<string, string> itemPlaylist in arrPlaylist)
                {
                    await SendMessageRealtime($"Đang thực hiện Playlist: {itemPlaylist.Key} - {i}");
                    List<string> res = new List<string>();
                    Playlist playlist_value = ConvertService.Instance.convertToObjectFromJson<Playlist>(HttpClone.Intance.getPlaylist(itemPlaylist.Key).Result);
                    if (!listIdPlaylist.Contains(itemPlaylist.Key))
                    {
                        actionPushGenre(playlist_value.genres, ref listIdGenre);
                        res = await DataHelper.Instance.pushPlaylist(playlist_value);
                        listIdPlaylist.Add(itemPlaylist.Key);
                    }
                    else
                    {
                        PlaylistDTO pCompare = ConvertService.Instance.convertToPlaylistDTO(playlist_value);
                        PlaylistDTO cur = await FirebaseService.Instance.getSingleValue<PlaylistDTO>($"/Playlist/{itemPlaylist.Key}");
                        if(!cur.compare(pCompare))
                        {
                            actionPushGenre(playlist_value.genres, ref listIdGenre);
                            res = await DataHelper.Instance.pushPlaylist(playlist_value);
                        }
                    }
                    foreach(string item_res in res)
                    {
                        await SendMessageRealtime(item_res, DataHelper.COLOR_DEFAULT_STEP);
                    }
                    await SendMessageRealtime($"Complete {i}");
                    ++i;
                }
            }
            return Redirect("Index");
        }

        public void actionPushGenre(List<Genre> genres, ref List<string> listIdGenre)
        {
            foreach (Genre genre in genres)
            {
                if (!listIdGenre.Contains(genre.id))
                {
                    FirebaseService.Instance.push("Genre/" + genre.id, genre);
                    listIdGenre.Add(genre.id);
                }
            }
        }

        public async Task SendMessageRealtime(string value, string color = null)
        {
            string res = convertToJson(value, color);
            await _hubContext.Clients.All.SendAsync("ReceiveRealtimeContent", res);
        }

        private string convertToJson(string value, string color)
        { 
            return JsonConvert.SerializeObject(new { result = value, color = color});
        }
    }
}
