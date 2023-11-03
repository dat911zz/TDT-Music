using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TDT.Core.Helper;
using TDT.Core.Ultils;
using TDT.Core.Helper.Firestore;
using System.Linq;
using TDT.Core.DTO.Firestore;

namespace TDT.Firestore
{
    public class CrawlDataV2Controller
    {
        private static FirestoreService _service;
        private static CrawlDataV2Controller _instance;
        private string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\";
        
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
            //await _service.DeleteAsync("TypePlayList");
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
        //public async Task TransfersRealtimeToFireStorge_TypePlaylistAsync()
        //{
        //    var value = FirebaseService.Instance.getDictionary("TypePlaylist");
        //    IList<Core.DTO.TypePlaylistDTO> types = value.Values.Select(t => ConvertService.Instance.convertToObjectFromJson<Core.DTO.TypePlaylistDTO>(t.ToString())).ToList();
        //    if (types != null)
        //    {
        //        foreach (Core.DTO.TypePlaylistDTO type in types)
        //        {
        //            if (type != null)
        //            {
        //                Core.DTO.Firestore.TypePlaylistDTO pType = Converter.convertToTypePlayListDTO(type);
        //                await FirestoreService.Instance.SetAsync<Core.DTO.Firestore.TypePlaylistDTO>("TypePlaylist", pType.title, pType);
        //            }
        //        }
        //    }
        //}
        //public async Task TransfersRealtimeToFireStorge_PlaylistAsync()
        //{
        //    var value = FirebaseService.Instance.getDictionary("Playlist");
        //    IList<Core.DTO.PlaylistDTO> playlists = value.Values.Select(t => ConvertService.Instance.convertToObjectFromJson<Core.DTO.PlaylistDTO>(t.ToString())).ToList();
        //    if (playlists != null)
        //    {
        //        foreach (Core.DTO.PlaylistDTO playlist in playlists)
        //        {
        //            if (playlist != null)
        //            {
        //                Core.DTO.Firestore.PlaylistDTO pPlaylist = Converter.convertToPlaylistDTO(playlist);
        //                await FirestoreService.Instance.SetAsync<Core.DTO.Firestore.PlaylistDTO>("Playlist", pPlaylist.encodeId, pPlaylist);
        //            }
        //        }
        //    }
        //}
        //public async Task TransfersRealtimeToFireStorge_ArtistAsync()
        //{
        //    var value = FirebaseService.Instance.getDictionary("Artist");
        //    IList<Core.DTO.ArtistDTO> artists = value.Values.Select(t => ConvertService.Instance.convertToObjectFromJson<Core.DTO.ArtistDTO>(t.ToString())).ToList();
        //    if (artists != null)
        //    {
        //        foreach (Core.DTO.ArtistDTO artist in artists)
        //        {
        //            if (artist != null)
        //            {
        //                Core.DTO.Firestore.ArtistDTO pArtist = Converter.convertToArtistDTO(artist);
        //                await FirestoreService.Instance.SetAsync<Core.DTO.Firestore.ArtistDTO>("Artist", pArtist.id, pArtist);
        //            }
        //        }
        //    }
        //}
        //public async Task TransfersRealtimeToFireStorge_SongAsync()
        //{
        //    HttpService httpService = new HttpService(APICallHelper.DOMAIN + "Song/load");
        //    string json = httpService.getJson();
        //    IList<Core.DTO.SongDTO> songs = ConvertService.Instance.convertToObjectFromJson<List<Core.DTO.SongDTO>>(json);
        //    if (songs != null)
        //    {
        //        foreach (Core.DTO.SongDTO song in songs)
        //        {
        //            if(song != null)
        //            {
        //                Core.DTO.Firestore.SongDTO pSong = Converter.convertToSongDTO(song);
        //                await FirestoreService.Instance.SetAsync<Core.DTO.Firestore.SongDTO>("Song", pSong.encodeId, pSong);
        //            }
        //        }
        //    }
        //}
        //public async Task TransfersRealtimeToFireStorge_GenreAsync()
        //{
        //    var value = FirebaseService.Instance.getDictionary("Genre");
        //    IList<Core.DTO.Genre> genres = value.Values.Select(t => ConvertService.Instance.convertToObjectFromJson<Core.DTO.Genre>(t.ToString())).ToList();
        //    if (genres != null)
        //    {
        //        foreach (Core.DTO.Genre genre in genres)
        //        {
        //            if (genre != null)
        //            {
        //                await FirestoreService.Instance.SetAsync<Core.DTO.Genre>("Genre", genre.id, genre);
        //            }
        //        }
        //    }
        //}
        //public async Task TransfersRealtimeToFireStorge_LyricAsync()
        //{
        //    var value = FirebaseService.Instance.getDictionary("Lyric");
        //    foreach (var item in value)
        //    {
        //        var sentences = ConvertService.Instance.convertToObjectFromJson<List<Core.DTO.Firestore.Sentence>>(item.Value.ToString());
        //        var lyric = new Core.DTO.Firestore.LyricDTO() { sentences = sentences, encodeId = item.Key };
        //        if (lyric != null)
        //        {
        //            await FirestoreService.Instance.SetAsync< Core.DTO.Firestore.LyricDTO >("Lyric", lyric.encodeId, lyric);
        //        }
        //    }
        //}

        //public async Task UpdateDataTypeSong()
        //{
        //    List<SongDTO> songs = FirestoreService.Instance.Gets<SongDTO>("Song");
        //    foreach (SongDTO song in songs)
        //    {
        //        ModelUpdate.Song songUpdate = ConvertService.Instance.ConvertUpdateType(song);
        //        await FirestoreService.Instance.SetAsync("Song", song.encodeId, songUpdate);
        //    }
        //}

        //public async Task UpdateDataTypePlaylist()
        //{
        //    List<PlaylistDTO> playlists = FirestoreService.Instance.Gets<PlaylistDTO>("Playlist");
        //    int i = 0;
        //    foreach (PlaylistDTO playlist in playlists)
        //    {
        //        Console.WriteLine(i++);
        //        ModelUpdate.Playlist playlistUpdate = ConvertService.Instance.ConvertUpdateType(playlist);
        //        await FirestoreService.Instance.SetAsync("Playlist", playlistUpdate.encodeId, playlistUpdate);
        //    }
        //}
    }
}
