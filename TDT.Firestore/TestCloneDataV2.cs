//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TDT.Core.Helper.Firestore;
//using TDT.Core.Helper;
//using TDT.Core.ModelClone;
//using TDT.Core.DTO.Firestore;
//using System.IO;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//namespace TDT.Firestore
//{
//    public class TestCloneDataV2 : CrawlDataV2Controller
//    {
//        private static new TestCloneDataV2 _instance;
//        public static new TestCloneDataV2 Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new TestCloneDataV2();
//                }
//                return _instance;
//            }
//        }

//        public async Task TypePlaylist()
//        {
//            var top100 = HttpClone.Intance.getTop100().Result;
//            IList<TypePlayList> typePlayLists = JsonConvert.DeserializeObject<List<TypePlayList>>(top100);
//            foreach (TypePlayList tp in typePlayLists)
//            {
//                TypePlaylistDTO value = Converter.convertToTypePlayListDTO(tp);

//                await _service.SetAsync("TypePlayList", value.title, value);
//            }
//        }
//        public async Task CrawlFromSearch()
//        {
//            ReadFileTXT();
//            int count = 0;
//            foreach (var c in _vn_lower_aphabet)
//            {
//                var search = HttpClone.Intance.search(c);
//                SearchDTO searchResult = JsonConvert.DeserializeObject<SearchDTO>(search);
//                //await _service.SetAsync("SearchResult", c, searchResult);
//                new Task(async () =>
//                {
//                    if (searchResult.artists != null)
//                    {
//                        await FillArtistCodeAsync(searchResult.artists);
//                        Console.WriteLine("--artist +");
//                    }
//                }).Start();
//                new Task(async () =>
//                {
//                    if (searchResult.playlists != null)
//                    {
//                        await FillPlayListCodeAsync(searchResult.playlists);
//                        Console.WriteLine("--playlist +");
//                    }
//                }).Start();
//                new Task(async () =>
//                {
//                    if (searchResult.songs != null)
//                    {
//                        await FillSongCodeAsync(searchResult.songs);
//                        Console.WriteLine("--song +");
//                    }
//                }).Start();
//                new Task(() =>
//                {
//                    if (searchResult.videos != null)
//                    {

//                    }
//                }).Start();
                
                
                
//                Console.WriteLine($"Pass: {count++} / 190");
//            }
//        }
//        public void ReadFileTXT()
//        {
//            using (StreamReader reader = new StreamReader(path + "bcc_vn.txt"))
//            {
//                while (!reader.EndOfStream)
//                {
//                    _vn_lower_aphabet.Add(reader.ReadLine().Split(',')[1]);
//                }
//            }
//        }
//        public async Task InitTestCollection()
//        {
//            Console.WriteLine("**Init db test enviroment**");
//            //await _service.SetAsync("Test", "Codes", new Dictionary<string, object>
//            //{
//            //    { "Song", new List<string>() },
//            //    { "PlayList", new List<string>() },
//            //    { "Artist", new List<string>() },
//            //    { "Genre", new List<string>() },
//            //});
//            //var key1s = await _service.GetKeys("Test", "Song");
//            //var key2s = await _service.GetKeys("Test", "PlayList");
//            //var key3s = await _service.GetKeys("Test", "Artist");
//            var key = await _service.CTestAsync("Test/Song");

//            Console.WriteLine("**Done**");
//        }
//        public async Task ClearCollection(string collection)
//        {
//            await _service.DeleteAsync(collection);
//        }
//        public async Task FillSongCodeAsync(List<TDT.Core.ModelClone.Song> songs)
//        {
//            songs.ForEach(s =>
//            {
//                if (!_songs.ContainsKey(s.encodeId))
//                {
//                    _songs.Add(s.encodeId, Converter.convertToSongDTO(s));
//                }
//            });
//            await _service.SetAsync("Test", "Song", _songs);
//        }
//        public async Task FillPlayListCodeAsync(List<TDT.Core.ModelClone.Playlist> playlist)
//        {
//            playlist.ForEach(s =>
//            {
//                if (!_playlists.ContainsKey(s.encodeId))
//                {
//                    _playlists.Add(s.encodeId, Converter.convertToPlaylistDTO(s));
//                }
//            });
//            await _service.SetAsync("Test", "PlayList", _playlists);

//        }
//        public async Task FillArtistCodeAsync(List<TDT.Core.ModelClone.Artist> artists)
//        {
//            foreach (var s in artists)
//            {
//                if (!_artists.ContainsKey(s.id))
//                {
//                    _artists.Add(s.id, Converter.convertToArtistDTO(s));
//                }
//            }
//            await _service.SetAsync("Test", "Artist", _artists);

//        }
//        //public async Task FillVideoCodeAsync(List<TDT.Core.ModelClone> videos)
//        //{

//        //}
//        //public async Task FillGenreCodeAsync()
//        //{

//        //}
//    }
//}
