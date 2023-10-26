using System.Collections.Generic;
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

        private static Dictionary<string, Player> players = new Dictionary<string, Player>();
        #endregion

        public static Dictionary<string, Player> GetPlayers()
        {
            return players;
        }
        public static void SetPlayer(List<string> songIds)
        {
            Dictionary<string, Player> temp = new Dictionary<string, Player>();
            foreach (string songId in songIds)
            {
                if (players.ContainsKey(songId))
                {
                    if(!temp.ContainsKey(songId))
                    {
                        temp.Add(songId, players[songId]);
                    }
                    continue;
                }
                var song = DataHelper.GetSong(songId);
                if (song != null)
                {
                    players.Add(song.encodeId, new Player
                    {
                        Id = song.encodeId,
                        Name = song.title,
                        Thumbnail = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail),
                        Src = DataHelper.GetMP3(song.encodeId),
                        Artists = Generator.GenerateArtistLink(song.artists)
                    });
                    temp.Add(songId, players[songId]);
                }
            }
            if(temp.Count > 0)
            {
                players = temp;
            }
        }
    }

    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Src { get; set; }
        public string Artists { get; set; }
    }
}
