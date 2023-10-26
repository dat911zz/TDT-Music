using System.Collections.Generic;
using TDT.Core.Helper;

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
        private static int index = 0;
        private static int cur_Duration = 0;
        private static Dictionary<string, Player> players = new Dictionary<string, Player>();
        #endregion

        public static Dictionary<string, Player> GetPlayers()
        {
            return players;
        }
        public static void SetPlayer(List<string> songIds)
        {
            foreach (string songId in songIds)
            {
                if (players.ContainsKey(songId))
                    continue;
                var song = DataHelper.GetSong(songId);
                if (song != null)
                {
                    players.Add(song.encodeId, new Player
                    {
                        Id = song.encodeId,
                        Name = song.title,
                        Thumbnail = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail),
                        Src = DataHelper.GetMP3(song.encodeId)
                    });
                }
            }
        }
    }

    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Src { get; set; }
    }
}
