using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.ServiceImp;

namespace TDT.Site.Services
{
    public class PlayerService
    {
        #region Singleton
        private static PlayerService _instance;
        private PlayerService() { }
        public static PlayerService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerService();
                }
                return _instance;
            }
        }
        #endregion

        #region Const
        public static int CurIndex = 0;
        public static int CurDuration = 0;
        public static bool IsShuffle = false;
        public static bool IsRepeat = false;
        public static bool IsRepeatOne = false;
        public static bool IsPlaying = false;
        public static string UrlStack = "";
        public static double CurTime = 0;

        private static Dictionary<string, Player> players = new Dictionary<string, Player>();
        private static List<Player> StackPlayer = new List<Player>();
        private static List<Player> HistoryPlayer = new List<Player>();
        #endregion
        public static Player NewPlayer(string songId, int index)
        {
            var song = DataHelper.GetSong(songId);
            if (song != null)
            {
                return new Player
                {
                    Id = song.encodeId,
                    Index = index,
                    Name = song.title,
                    Thumbnail = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail),
                    Src = DataHelper.GetMP3(song.encodeId),
                    Artists = Generator.GenerateArtistLink(song.artists),
                    UrlPlaylist = string.IsNullOrEmpty(song.album) ? "" : $"/Album?encodeId={song.album}"
                };
            }
            return null;
        }
        public static Dictionary<string, Player> GetPlayers()
        {
            return players;
        }
        public static void ShuffleStack()
        {
            if (IsShuffle)
            {
                StackPlayer.Shuffle();
            }
            else
            {
                StackPlayer = StackPlayer.OrderBy(s => s.Index).ToList();
            }
        }
        public static void SetPlayer(List<string> songIds)
        {
            Dictionary<string, Player> temp = new Dictionary<string, Player>();
            int i = 0;
            foreach (string songId in songIds)
            {
                Player player = null;
                if (players.ContainsKey(songId))
                {
                    if(!temp.ContainsKey(songId))
                    {
                        player = players[songId];
                        player.Index = i++;
                        temp.Add(songId, player);
                    }
                    continue;
                }
                player = NewPlayer(songId, i);
                if (player != null)
                {
                    i++;
                    players.Add(songId, player);
                    temp.Add(songId, players[songId]);
                }
            }
            if(temp.Count > 0)
            {
                players = temp;
                HistoryPlayer.Clear();
                StackPlayer = players.Values.ToList();
                ShuffleStack();
            }
        }
        public static bool StackIsEmpty()
        {
            return StackPlayer.Count == 0;
        }
        public static Player ChangeMusic(string type = "init")
        {
            try
            {
                if(StackIsEmpty())
                {
                    if(IsRepeat)
                    {
                        StackPlayer.AddRange(HistoryPlayer);
                        HistoryPlayer.Clear();
                        return ChangeMusic();
                    }
                    return null;
                }    
                if(!IsRepeatOne)
                {
                    if (type == "next")
                    {
                        HistoryPlayer.Add(StackPlayer.First());
                        StackPlayer.RemoveAt(0);
                        return ChangeMusic();
                    }
                    if (type == "prev")
                    {
                        StackPlayer.Insert(0, HistoryPlayer.Last());
                        HistoryPlayer.RemoveAt(HistoryPlayer.Count - 1);
                        return ChangeMusic();
                    }
                }
                return StackPlayer.First();
            }
            catch
            {
                return null;
            }
        }
        public static void ChoosePlayer(int index, string id)
        {
            int i = 0;
            bool containsStack = false;
            bool containsHistory = false;
            foreach (Player player in StackPlayer)
            {
                if (player.Id == id && player.Index == index)
                {
                    containsStack = true;
                    break;
                }
                i++;
            }
            if(!containsStack)
            {
                i = 0;
                foreach (Player player in HistoryPlayer)
                {
                    if (player.Id == id && player.Index == index)
                    {
                        containsHistory = true;
                        break;
                    }
                    i++;
                }
            }
            
            if (containsStack)
            {
                for(int iS = 0; iS < i; iS++)
                {
                    HistoryPlayer.Add(StackPlayer[iS]);
                }
                StackPlayer.RemoveRange(0, i);
            }
            else if(containsHistory)
            {
                for(int iH = HistoryPlayer.Count - 1; iH >= i; iH--)
                {
                    StackPlayer.Insert(0, HistoryPlayer[iH]);
                }
                HistoryPlayer.RemoveRange(i, HistoryPlayer.Count - i);
            }
            else
            {
                HistoryPlayer.Clear();
                StackPlayer.Clear();
                StackPlayer.Add(NewPlayer(id, index));
            }
        }
    }

    public class Player
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Src { get; set; }
        public string Artists { get; set; }
        public string UrlPlaylist { get; set; }
    }
}
