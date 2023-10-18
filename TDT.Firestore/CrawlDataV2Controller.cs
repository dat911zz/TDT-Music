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
        public static FirestoreService _service;
        public static CrawlDataV2Controller _instance;
        public string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\";
        public IDictionary<string, object> _playlists = new Dictionary<string, object>();
        public IDictionary<string, object> _songs = new Dictionary<string, object>();
        public IDictionary<string, object> _artists = new Dictionary<string, object>();
        public IDictionary<string, object> _genre = new Dictionary<string, object>();
        public IDictionary<string, object> _video = new Dictionary<string, object>();
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
        public CrawlDataV2Controller()
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
    }
}
