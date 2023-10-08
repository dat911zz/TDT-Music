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
            List<SongDTO> songs = new List<SongDTO>();
            if (DataHelper.Instance.Songs.Count <= 0)
            {
                HttpService httpService = new HttpService(DataHelper.DOMAIN_API + "/Song/load");
                string json = httpService.getJson();
                songs = ConvertService.Instance.convertToObjectFromJson<List<SongDTO>>(json);
            }
            else
            {
                songs = DataHelper.Instance.Songs.Values.ToList();
            }
            if (songs != null)
            {
                foreach (SongDTO song in songs)
                {
                    if (!DataHelper.Instance.Songs.Keys.Contains(song.encodeId))
                    {
                        DataHelper.Instance.Songs.Add(song.encodeId, song);
                    }
                }
            }
            List<string> htmls = new List<string>();
            List<List<SongDTO>> songRelease = DataHelper.Instance.SongRelease;
            foreach (List<SongDTO> listItem in songRelease)
            {
                htmls.Add(Generator.Instance.GenerateSongRelease(listItem));
            }
            return new JsonResult(string.Concat(htmls));
        }
        public JsonResult LoadGenre()
        {
            if(DataHelper.Instance.Genres.Count <= 0)
            {
                HttpService httpService = new HttpService(DataHelper.DOMAIN_API + "/Genre/load");
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
    }
}
