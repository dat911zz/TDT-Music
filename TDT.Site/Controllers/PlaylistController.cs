using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TDT_Music.Models;
using TDT.Core.DTO;
using TDT.Core.ModelClone;
using Microsoft.Extensions.Logging;
using TDT.Core.Helper;
using System.Collections.Generic;
using TDT.Core.Ultils;
using System.Linq;

public class PlaylistController : Controller
{
    private readonly ILogger<PlaylistController> _logger;
    private List<PlaylistDTO> _playlists;
    public PlaylistController(ILogger<PlaylistController> logger)
    {
        _logger = logger;
        if (DataHelper.Instance.Playlists.Count <= 0)
        {
            HttpService httpService = new HttpService(APICallHelper.DOMAIN + "Playlist/load");
            string json = httpService.getJson();
            _playlists = ConvertService.Instance.convertToObjectFromJson<List<PlaylistDTO>>(json);
        }
        else
        {
            _playlists = DataHelper.Instance.Playlists.Values.ToList();
        }
        if (_playlists != null)
        {
            foreach (PlaylistDTO playlist in _playlists)
            {
                if (!DataHelper.Instance.Playlists.Keys.Contains(playlist.encodeId))
                {
                    DataHelper.Instance.Playlists.Add(playlist.encodeId, playlist);
                }
            }
        }
    }
    public async Task<IActionResult> Index()
    {
        return View(_playlists);
    }

}

