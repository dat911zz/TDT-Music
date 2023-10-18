using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.DTO.Firestore;
using TDT.Core.Helper;
using TDT.Core.Helper.Firestore;
using TDT.Core.ModelClone;

namespace TDT.Firestore
{
    public class CrawlDataV2Controller
    {
        private static FirestoreService _service;
        private static CrawlDataV2Controller _instance;
        private string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\";
        public IDictionary<string, string> _playlists = new Dictionary<string, string>();
        public IDictionary<string, string> _songs = new Dictionary<string, string>();
        public IDictionary<string, string> _artists = new Dictionary<string, string>();
        public IList<string> _vn_lower_aphabet = new List<string>();
        public static CrawlDataV2Controller Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CrawlDataV2Controller();
                }
                return _instance;
            }
        }
        private CrawlDataV2Controller()
        {
            _service = FirestoreService.Instance;
        }
        public async Task ClearCollection()
        {
            await _service.DeleteAsync("TypePlayList");
        }
        public async Task TypePlaylist()
        {
            var top100 = HttpClone.Intance.getTop100().Result;
            IList<TypePlayList> typePlayLists = JsonConvert.DeserializeObject<List<TypePlayList>>(top100);
            foreach (TypePlayList tp in typePlayLists)
            {
                TypePlaylistDTO value = Converter.convertToTypePlayListDTO(tp);

                await _service.SetAsync("TypePlayList", value.title, value);
            }
        }
        public async Task<IDictionary<string, object>> GetExistingSearchListAsync()
        {
            IDictionary<string, object> res = new Dictionary<string, object>();
            res = await _service.Gets("SearchResult");
            return res;
        }
        public async Task<IList<string>> GetExistingSearchKeysAsync()
        {
            IList<string> res = new List<string>();
            res = await _service.GetKeys("SearchResult");
            return res;
        }
        public async Task CrawlFromSearch()
        {
            ReadFileTXT();
            int count = 0;
            foreach (var c in _vn_lower_aphabet)
            {
                var search = HttpClone.Intance.search(c);
                SearchDTO searchResult = JsonConvert.DeserializeObject<SearchDTO>(search);
                await _service.SetAsync("SearchResult", c, searchResult);
                Console.WriteLine($"Pass: {count++} / 190");
            }
        }
        public void ReadFileTXT()
        {
            using (StreamReader reader = new StreamReader(path + "bcc_vn.txt"))
            {
                while (!reader.EndOfStream)
                {
                    _vn_lower_aphabet.Add(reader.ReadLine().Split(',')[1]);
                }
            }
        }
        //public async Task Playlist()
        //{
        //    var value = FirebaseService.Instance.getDictionary("TypePlaylist");
        //    var playlistDictionary = FirebaseService.Instance.getDictionary("Playlist");
        //    var genreDictionary = FirebaseService.Instance.getDictionary("Genre");

        //    var listIdPlaylist = playlistDictionary == null ? new List<string>() : playlistDictionary.Keys.ToList();
        //    var listIdGenre = genreDictionary == null ? new List<string>() : genreDictionary.Keys.ToList();

        //    foreach (KeyValuePair<string, object> kvp in value)
        //    {
        //        TypePlaylistDTO typePlayListDTO = ConvertService.Instance.convertToObjectFromJson<TypePlaylistDTO>(kvp.Value.ToString());
        //        Dictionary<string, string> arrPlaylist = typePlayListDTO.playlists;
        //        foreach (KeyValuePair<string, string> itemPlaylist in arrPlaylist)
        //        {
        //            if (!listIdPlaylist.Contains(itemPlaylist.Key))
        //            {
        //                Playlist playlist_value = ConvertService.Instance.convertToObjectFromJson<Playlist>(HttpClone.Intance.getPlaylist(itemPlaylist.Key).Result);
        //                foreach (Genre genre in playlist_value.genres)
        //                {
        //                    if (!listIdGenre.Contains(genre.id))
        //                    {
        //                        FirebaseService.Instance.push("Genre/" + genre.id, genre);
        //                        listIdGenre.Add(genre.id);
        //                    }
        //                }
        //                await DataHelper.Instance.pushPlaylist(playlist_value);
        //                listIdPlaylist.Add(itemPlaylist.Key);
        //            }
        //        }
        //    }
        //}
    }
}
