using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDT.Core.DTO.Firestore;
using TDT.Core.Helper;

namespace TDT.Firestore
{
    public class CrawlDataV1Controller
    {
        //public async Task TypePlaylist()
        //{
        //    var top100 = HttpClone.Intance.getTop100().Result;
        //    List<TypePlayList> typePlayLists = JsonConvert.DeserializeObject<List<TypePlayList>>(top100);
        //    foreach (TypePlayList tp in typePlayLists)
        //    {
        //        TypePlaylistDTO value = ConvertService.Instance.convertToTypePlayListDTO(tp);
        //        FirebaseService.Instance.push("TypePlaylist/" + value.title, value);
        //    }
        //}

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

        //public async Task<IActionResult> ArtistInPlaylist()
        //{
        //    var playlistDictionary = FirebaseService.Instance.getDictionary("Playlist");
        //    var artistDictionary = FirebaseService.Instance.getDictionary("Artist");

        //    var listIdArtist = artistDictionary == null ? new List<string>() : artistDictionary.Keys.ToList();
        //    var clone_artist = 0;
        //    foreach (KeyValuePair<string, object> kvp in playlistDictionary)
        //    {
        //        ++clone_artist;
        //        PlaylistDTO playListDTO = ConvertService.Instance.convertToObjectFromJson<PlaylistDTO>(kvp.Value.ToString());
        //        Dictionary<string, string> arrArtist = playListDTO.artists;
        //        if (arrArtist != null)
        //        {
        //            foreach (KeyValuePair<string, string> itemArtist in arrArtist)
        //            {
        //                if (!listIdArtist.Contains(itemArtist.Key))
        //                {
        //                    var artist_value = JsonConvert.DeserializeObject<Artist>(HttpClone.Intance.getArtist(itemArtist.Value).Result);
        //                    if (artist_value != null)
        //                    {
        //                        DataHelper.Instance.pushArtist(artist_value);
        //                        listIdArtist.Add(itemArtist.Key);
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Artist_value null! " + itemArtist.Value);
        //                    }
        //                }
        //            }
        //        }
        //        Console.WriteLine(clone_artist);
        //    }
        //    return Redirect("/");
        //}

        //public async Task<IActionResult> SongInPlaylist()
        //{
        //    var playlistDictionary = FirebaseService.Instance.getDictionary("Playlist");
        //    var songDictionary = FirebaseService.Instance.getDictionary("Song");

        //    var listIdSong = songDictionary == null ? new List<string>() : songDictionary.Keys.ToList();
        //    var clone_song = 0;
        //    foreach (KeyValuePair<string, object> kvp in playlistDictionary)
        //    {
        //        ++clone_song;
        //        PlaylistDTO playListDTO = ConvertService.Instance.convertToObjectFromJson<PlaylistDTO>(kvp.Value.ToString());
        //        Dictionary<string, string> arrSong = playListDTO.songs;
        //        foreach (KeyValuePair<string, string> itemSong in arrSong)
        //        {
        //            if (!listIdSong.Contains(itemSong.Key))
        //            {
        //                var song_value = JsonConvert.DeserializeObject<Song>(HttpClone.Intance.getSongInfo(itemSong.Key).Result);
        //                if (song_value != null)
        //                {
        //                    DataHelper.Instance.pushSong(song_value);
        //                    listIdSong.Add(itemSong.Key);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("song_value null! " + itemSong.Value);
        //                }
        //            }
        //        }
        //        Console.WriteLine(clone_song);
        //    }
        //    return Redirect("/");
        //}

        //public async Task<IActionResult> UpdateStreamStatus()
        //{
        //    var songDictionary = FirebaseService.Instance.getDictionary("Song");
        //    int update_song = 0;
        //    foreach (KeyValuePair<string, object> kvp in songDictionary)
        //    {
        //        SongDTO song = ConvertService.Instance.convertToObjectFromJson<SongDTO>(kvp.Value.ToString());
        //        ++update_song;
        //        if (song.streamingStatus == 1)
        //        {
        //            var result = FirebaseService.Instance.getStorage($"MP3/{song.encodeId}.mp3");
        //            if (String.IsNullOrEmpty(result))
        //            {
        //                song.streamingStatus = 0;
        //                Console.WriteLine(update_song);
        //                FirebaseService.Instance.push($"Song/{song.encodeId}", song);
        //            }
        //        }
        //        Console.WriteLine(update_song);
        //    }
        //    return Redirect("/");
        //}

        //public async Task<IActionResult> StreamInSong()
        //{
        //    var songDictionary = FirebaseService.Instance.getDictionary("Song");
        //    int update_song = 0;
        //    foreach (KeyValuePair<string, object> kvp in songDictionary)
        //    {
        //        SongDTO song = ConvertService.Instance.convertToObjectFromJson<SongDTO>(kvp.Value.ToString());
        //        ++update_song;
        //        if (song.streamingStatus == 0)
        //        {
        //            GetStream getStream = ConvertService.Instance.convertToObjectFromJson<GetStream>(HttpClone.Intance.getStreaming(song.encodeId));
        //            string nameSong = "MP3/" + song.encodeId + ".mp3";
        //            while (getStream.url != null)
        //            {
        //                getStream = ConvertService.Instance.convertToObjectFromJson<GetStream>(HttpClone.Intance.getJsonFromUrl(getStream.url));
        //                if (getStream.msg.Contains("VIP"))
        //                {
        //                    song.streamingStatus = -1;
        //                    break;
        //                }
        //            }
        //            if (getStream.data._128 == null)
        //            {
        //                song.streamingStatus = -1;
        //            }
        //            if (song.streamingStatus != -1)
        //            {
        //                await FirebaseService.Instance.pushFile(getStream.data._128, nameSong);
        //                song.streamingStatus = 1;
        //            }
        //            else
        //            {
        //                Console.WriteLine("\nVIP");
        //            }
        //            Console.WriteLine(update_song);
        //            FirebaseService.Instance.push("Song/" + song.encodeId, song);
        //        }
        //        else
        //        {
        //            Console.WriteLine($"{update_song}\t{song.encodeId}");
        //        }
        //    }
        //    return Redirect("/");
        //}

        //public async Task<IActionResult> ArtistInSong()
        //{
        //    var songDictionary = FirebaseService.Instance.getDictionary("Song");
        //    var artistDictionary = FirebaseService.Instance.getDictionary("Artist");

        //    var listIdArtist = artistDictionary == null ? new List<string>() : artistDictionary.Keys.ToList();
        //    int update_song = 0;
        //    foreach (KeyValuePair<string, object> kvp in songDictionary)
        //    {
        //        SongDTO song = ConvertService.Instance.convertToObjectFromJson<SongDTO>(kvp.Value.ToString());
        //        ++update_song;
        //        if (song.artists != null)
        //        {
        //            foreach (KeyValuePair<string, string> kvpArtist in song.artists)
        //            {
        //                if (!listIdArtist.Contains(kvpArtist.Key))
        //                {
        //                    var artist_value = JsonConvert.DeserializeObject<Artist>(HttpClone.Intance.getArtist(kvpArtist.Value).Result);
        //                    if (artist_value != null)
        //                    {
        //                        DataHelper.Instance.pushArtist(artist_value);
        //                        listIdArtist.Add(kvpArtist.Key);
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Artist_value null! " + kvpArtist.Value);
        //                    }
        //                }
        //            }
        //        }
        //        Console.WriteLine(update_song);
        //    }
        //    return Redirect("/");
        //}

        //public async Task<IActionResult> ComposerInSong()
        //{
        //    var songDictionary = FirebaseService.Instance.getDictionary("Song");
        //    var artistDictionary = FirebaseService.Instance.getDictionary("Artist");

        //    var listIdArtist = artistDictionary == null ? new List<string>() : artistDictionary.Keys.ToList();
        //    int update_song = 0;
        //    foreach (KeyValuePair<string, object> kvp in songDictionary)
        //    {
        //        SongDTO song = ConvertService.Instance.convertToObjectFromJson<SongDTO>(kvp.Value.ToString());
        //        ++update_song;
        //        if (song.composers != null)
        //        {
        //            foreach (KeyValuePair<string, string> kvpArtist in song.composers)
        //            {
        //                if (!listIdArtist.Contains(kvpArtist.Key))
        //                {
        //                    var artist_value = JsonConvert.DeserializeObject<Artist>(HttpClone.Intance.getArtist(kvpArtist.Value).Result);
        //                    if (artist_value != null)
        //                    {
        //                        DataHelper.Instance.pushArtist(artist_value);
        //                        listIdArtist.Add(kvpArtist.Key);
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Artist_value null! " + kvpArtist.Value);
        //                    }
        //                }
        //            }
        //        }
        //        Console.WriteLine(update_song);
        //    }
        //    return Redirect("/");
        //}

        //public async Task<IActionResult> LyricInSong()
        //{

        //    //var lyric_value = JsonConvert.DeserializeObject<Lyric>(HttpService.Intance.getLyric("Z6AABFU6"));
        //    //FirebaseService.Instance.push("Lyric/Z6AABFU6", lyric_value.sentences);

        //    //var lyricDictionary = FirebaseService.Instance.getDictionary("Lyric");
        //    //foreach (KeyValuePair<string, object> kvp in lyricDictionary)
        //    //{
        //    //    var sentences = ConvertService.Instance.convertToObjectFromJson<List<Sentence>>(kvp.Value.ToString());
        //    //    var lyric = new LyricDTO() { sentences = sentences };
        //    //    Console.WriteLine(kvp.Value);
        //    //}

        //    var songDictionary = FirebaseService.Instance.getDictionary("Song");
        //    var lyricDictionary = FirebaseService.Instance.getDictionary("Lyric");

        //    var listIdLyric = lyricDictionary == null ? new List<string>() : lyricDictionary.Keys.ToList();
        //    int update_song = 0;
        //    foreach (KeyValuePair<string, object> kvp in songDictionary)
        //    {
        //        SongDTO song = ConvertService.Instance.convertToObjectFromJson<SongDTO>(kvp.Value.ToString());
        //        ++update_song;
        //        if (song.hasLyric)
        //        {
        //            if (!listIdLyric.Contains(song.encodeId))
        //            {
        //                var lyric_value = JsonConvert.DeserializeObject<LyricDTO>(HttpClone.Intance.getLyric(song.encodeId));
        //                if (lyric_value != null)
        //                {
        //                    FirebaseService.Instance.push($"Lyric/{song.encodeId}", lyric_value.sentences);
        //                    listIdLyric.Add(song.encodeId);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("lyric_value null! " + song.encodeId);
        //                }
        //            }
        //        }
        //        Console.WriteLine(update_song);
        //    }
        //    return Redirect("/");
        //}

        //public async Task<IActionResult> GenreInSong()
        //{
        //    var songDictionary = FirebaseService.Instance.getDictionary("Song");
        //    var genreDictionary = FirebaseService.Instance.getDictionary("Genre");

        //    var listIdGenre = genreDictionary == null ? new List<string>() : genreDictionary.Keys.ToList();
        //    int update_song = 0;
        //    foreach (KeyValuePair<string, object> kvp in songDictionary)
        //    {
        //        ++update_song;
        //        var song_firebase = ConvertService.Instance.convertToObjectFromJson<SongDTO>(kvp.Value.ToString());
        //        bool change = false;
        //        foreach (string kGenre in song_firebase.genreIds)
        //        {
        //            if (!listIdGenre.Contains(kGenre))
        //            {
        //                change = true;
        //                break;
        //            }
        //        }
        //        if (change)
        //        {
        //            var song_value = JsonConvert.DeserializeObject<Song>(HttpClone.Intance.getSongInfo(kvp.Key).Result);
        //            if (song_value != null)
        //            {
        //                if (song_value.genres != null)
        //                {
        //                    foreach (Genre genre in song_value.genres)
        //                    {
        //                        if (!listIdGenre.Contains(genre.id))
        //                        {
        //                            FirebaseService.Instance.push("Genre/" + genre.id, genre);
        //                            listIdGenre.Add(genre.id);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        Console.WriteLine(update_song);
        //    }
        //    return Redirect("/");
        //}

        //public async Task<IActionResult> AlbumInSong()
        //{
        //    var songDictionary = FirebaseService.Instance.getDictionary("Song");
        //    var playlistDictionary = FirebaseService.Instance.getDictionary("Playlist");
        //    var genreDictionary = FirebaseService.Instance.getDictionary("Genre");

        //    var listIdPlaylist = playlistDictionary == null ? new List<string>() : playlistDictionary.Keys.ToList();
        //    var listIdGenre = genreDictionary == null ? new List<string>() : genreDictionary.Keys.ToList();
        //    int update_song = 0;
        //    foreach (KeyValuePair<string, object> kvp in songDictionary)
        //    {
        //        SongDTO song = ConvertService.Instance.convertToObjectFromJson<SongDTO>(kvp.Value.ToString());
        //        ++update_song;
        //        if (!String.IsNullOrEmpty(song.album))
        //        {
        //            if (!listIdPlaylist.Contains(song.album))
        //            {
        //                Playlist playlist_value = ConvertService.Instance.convertToObjectFromJson<Playlist>(HttpClone.Intance.getPlaylist(song.album).Result);
        //                if (playlist_value != null)
        //                {
        //                    foreach (Genre genre in playlist_value.genres)
        //                    {
        //                        if (!listIdGenre.Contains(genre.id))
        //                        {
        //                            FirebaseService.Instance.push("Genre/" + genre.id, genre);
        //                            listIdGenre.Add(genre.id);
        //                        }
        //                    }
        //                    DataHelper.Instance.pushPlaylist(playlist_value);
        //                    listIdPlaylist.Add(song.album);
        //                }
        //            }
        //        }
        //        Console.WriteLine(update_song);
        //    }
        //    return Redirect("/");
        //}


        ////------------------------------------------------------------------------

        //public async Task<IActionResult> UpdateTypePlaylist()
        //{
        //    try
        //    {
        //        var top100 = HttpClone.Intance.getTop100().Result;
        //        List<TypePlayList> typePlayLists = JsonConvert.DeserializeObject<List<TypePlayList>>(top100);
        //        int i = 1;
        //        foreach (TypePlayList tp in typePlayLists)
        //        {
        //            await SendMessageRealtime($"Đang thực hiện TypePlaylist: {tp.title} - {i++}", DataHelper.COLOR_DEFAULT_STEP);
        //            TypePlaylistDTO value = ConvertService.Instance.convertToTypePlayListDTO(tp);
        //            TypePlaylistDTO cur = FirebaseService.Instance.getSingleValue<TypePlaylistDTO>($"/TypePlaylist/{tp.title}").Result;
        //            if (!cur.compare(value))
        //            {
        //                FirebaseService.Instance.push("TypePlaylist/" + value.title, value);
        //                await SendMessageRealtime($"Cập nhật TypePlaylist: {cur.title}");
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        await SendMessageRealtime(e.Message, "red");
        //    }
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> UpdatePlaylist()
        //{
        //    var value = FirebaseService.Instance.getDictionary("TypePlaylist");
        //    var playlistDictionary = FirebaseService.Instance.getDictionary("Playlist");
        //    var genreDictionary = FirebaseService.Instance.getDictionary("Genre");

        //    var listIdPlaylist = playlistDictionary == null ? new List<string>() : playlistDictionary.Keys.ToList();
        //    var listIdGenre = genreDictionary == null ? new List<string>() : genreDictionary.Keys.ToList();
        //    int i = 1;
        //    await SendMessageRealtime($"Tổng số Playlist: {listIdPlaylist.Count}");
        //    foreach (KeyValuePair<string, object> kvp in value)
        //    {
        //        TypePlaylistDTO typePlayListDTO = ConvertService.Instance.convertToObjectFromJson<TypePlaylistDTO>(kvp.Value.ToString());
        //        Dictionary<string, string> arrPlaylist = typePlayListDTO.playlists;
        //        foreach (KeyValuePair<string, string> itemPlaylist in arrPlaylist)
        //        {
        //            await SendMessageRealtime($"Đang thực hiện Playlist: {itemPlaylist.Key} - {i}");
        //            List<string> res = new List<string>();
        //            Playlist playlist_value = ConvertService.Instance.convertToObjectFromJson<Playlist>(HttpClone.Intance.getPlaylist(itemPlaylist.Key).Result);
        //            if (!listIdPlaylist.Contains(itemPlaylist.Key))
        //            {
        //                actionPushGenre(playlist_value.genres, ref listIdGenre);
        //                res = await DataHelper.Instance.pushPlaylist(playlist_value);
        //                listIdPlaylist.Add(itemPlaylist.Key);
        //            }
        //            else
        //            {
        //                PlaylistDTO pCompare = ConvertService.Instance.convertToPlaylistDTO(playlist_value);
        //                PlaylistDTO cur = await FirebaseService.Instance.getSingleValue<PlaylistDTO>($"/Playlist/{itemPlaylist.Key}");
        //                if (!cur.compare(pCompare))
        //                {
        //                    actionPushGenre(playlist_value.genres, ref listIdGenre);
        //                    res = await DataHelper.Instance.pushPlaylist(playlist_value);
        //                }
        //            }
        //            foreach (string item_res in res)
        //            {
        //                await SendMessageRealtime(item_res, DataHelper.COLOR_DEFAULT_STEP);
        //            }
        //            await SendMessageRealtime($"Complete {i}");
        //            ++i;
        //        }
        //    }
        //    return Redirect("Index");
        //}

        //public async Task<IActionResult> UpdateArtistInPlaylist()
        //{
        //    try
        //    {
        //        var playlistDictionary = FirebaseService.Instance.getDictionary("Playlist");
        //        var artistDictionary = FirebaseService.Instance.getDictionary("Artist");

        //        var listIdArtist = artistDictionary == null ? new List<string>() : artistDictionary.Keys.ToList();
        //        var clone_artist = 1;
        //        var iPlaylist = 1;
        //        await SendMessageRealtime($"Tổng số Artist: {listIdArtist.Count}");
        //        foreach (KeyValuePair<string, object> kvp in playlistDictionary)
        //        {
        //            await SendMessageRealtime($"Đang thực hiện Playlist: {kvp.Key} - {iPlaylist}", "green");
        //            PlaylistDTO playListDTO = ConvertService.Instance.convertToObjectFromJson<PlaylistDTO>(kvp.Value.ToString());
        //            Dictionary<string, string> arrArtist = playListDTO.artists;
        //            if (arrArtist != null)
        //            {
        //                foreach (KeyValuePair<string, string> itemArtist in arrArtist)
        //                {
        //                    List<string> res = new List<string>();
        //                    await SendMessageRealtime($"Đang thực hiện Artist: {itemArtist.Key} - {clone_artist}");
        //                    var artist_value = JsonConvert.DeserializeObject<Artist>(HttpClone.Intance.getArtist(itemArtist.Value).Result);
        //                    if (!listIdArtist.Contains(itemArtist.Key))
        //                    {
        //                        if (artist_value != null)
        //                        {
        //                            res = await DataHelper.Instance.pushArtist(artist_value);
        //                            listIdArtist.Add(itemArtist.Key);
        //                        }
        //                        else
        //                        {
        //                            await SendMessageRealtime("Artist_value null! " + itemArtist.Value, "red");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ArtistDTO aCompare = ConvertService.Instance.convertToArtistDTO(artist_value);
        //                        ArtistDTO cur = await FirebaseService.Instance.getSingleValue<ArtistDTO>($"/Artist/{itemArtist.Key}");
        //                        if (!cur.compare(aCompare))
        //                        {
        //                            res = await DataHelper.Instance.pushArtist(artist_value);
        //                        }
        //                    }
        //                    foreach (string item_res in res)
        //                    {
        //                        await SendMessageRealtime(item_res, DataHelper.COLOR_DEFAULT_STEP);
        //                    }
        //                    await SendMessageRealtime($"Complete Artist {clone_artist}");
        //                    ++clone_artist;
        //                }
        //                await SendMessageRealtime($"Complete Playlist {iPlaylist}", "green");
        //                ++iPlaylist;
        //            }
        //            Console.WriteLine(clone_artist);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        await SendMessageRealtime(e.Message, "red");
        //    }
        //    return Redirect("/");
        //}

        //public void actionPushGenre(List<Genre> genres, ref List<string> listIdGenre)
        //{
        //    foreach (Genre genre in genres)
        //    {
        //        if (!listIdGenre.Contains(genre.id))
        //        {
        //            FirebaseService.Instance.push("Genre/" + genre.id, genre);
        //            listIdGenre.Add(genre.id);
        //        }
        //    }
        //}

        //public async Task SendMessageRealtime(string value, string color = null)
        //{
        //    string res = convertToJson(value, color);
        //    await _hubContext.Clients.All.SendAsync("ReceiveRealtimeContent", res);
        //}

        //private string convertToJson(string value, string color)
        //{
        //    return JsonConvert.SerializeObject(new { result = value, color = color });
        //}
    }
}
