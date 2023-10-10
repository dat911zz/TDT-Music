using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDT.Core.DTO;
using TDT.Core.Ultils;

namespace TDT.CAdmin.Controllers
{
    public class MusicManagementController : Controller
    {
        List<SongDTO> _songs = new List<SongDTO>();

        public MusicManagementController()
        {
            _songs.Add(new SongDTO
            {
                encodeId = "123"
            });
            _songs.Add(new SongDTO
            {
                encodeId = "1213"
            });
            _songs.Add(new SongDTO
            {
                encodeId = "123123"
            }); _songs.Add(new SongDTO
            {
                encodeId = "112323"
            }); _songs.Add(new SongDTO
            {
                encodeId = "12131233"
            }); _songs.Add(new SongDTO
            {
                encodeId = "1131231223"
            }); _songs.Add(new SongDTO
            {
                encodeId = "12123123123"
            }); _songs.Add(new SongDTO
            {
                encodeId = "11312323312323"
            });
        }

        public IActionResult Index()
        {
            
            return View(_songs);
        }
    }
}
