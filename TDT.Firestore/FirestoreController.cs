using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.Helper;
using TDT.Core.ModelClone;

namespace TDT.Firestore
{
    public class FirestoreController
    {
        private static FirestoreService _service;
        private static FirestoreController _instance;
        public static FirestoreController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FirestoreController();
                }
                return _instance;
            }
        }
        private FirestoreController()
        {
            _service = FirestoreService.Instance;
        }

        public void TypePlaylist()
        {
            var top100 = HttpClone.Intance.getTop100().Result;
            List<TypePlayList> typePlayLists = JsonConvert.DeserializeObject<List<TypePlayList>>(top100);
            foreach (TypePlayList tp in typePlayLists)
            {
                TypePlaylistDTO value = ConvertService.Instance.convertToTypePlayListDTO(tp);

                _service.SetAsync("TypePlayList", value.title, value).Wait();
            }
        }
    }
}
