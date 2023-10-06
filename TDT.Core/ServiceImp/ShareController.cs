using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.Helper;

namespace TDT.Core.ServiceImp
{
    public class ShareController : ControllerBase
    {
        public JsonResult LoadSongRelease()
        {
            HttpService httpService = new HttpService(@DataHelper.DOMAIN_API + "/api/Song/load");
            string json = httpService.getJson();
            List<SongDTO> songs = ConvertService.Instance.convertToObjectFromJson<List<SongDTO>>(json);
            foreach (SongDTO song in songs)
            {
                if(!DataHelper.Instance.Songs.Keys.Contains(song.encodeId))
                {
                    DataHelper.Instance.Songs.Add(song.encodeId, song);
                }
            }
            List<string> htmls = new List<string>();
            List<List<SongDTO>> songRelease = DataHelper.Instance.SongRelease;
            foreach (List< SongDTO> listItem in songRelease)
            {
                htmls.Add(Generator.Instance.GenerateSongRelease(listItem));
            }
            return new JsonResult(string.Concat(htmls));
        }
    }
}
