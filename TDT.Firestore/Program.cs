using System;
using System.Threading.Tasks;
using TDT.Firestore;

namespace TDTFirestore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrawlDataV2Controller ctr = CrawlDataV2Controller.Instance;
            //TestCloneDataV2 ctr1 = TestCloneDataV2.Instance;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hello World!");
            Task.WaitAll(
                //ctr.TransfersRealtimeToFireStorge_TypePlaylistAsync()
                //ctr.TransfersRealtimeToFireStorge_PlaylistAsync()
                //ctr.TransfersRealtimeToFireStorge_ArtistAsync()
                //ctr.TransfersRealtimeToFireStorge_SongAsync()
                //ctr.TransfersRealtimeToFireStorge_GenreAsync()
                //ctr.TransfersRealtimeToFireStorge_LyricAsync()
                //ctr.UpdateDataTypeSong()
                //ctr.UpdateDataTypePlaylist()
            );
        }
    }
}
