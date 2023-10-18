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
            TestCloneDataV2 ctr1 = TestCloneDataV2.Instance;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hello World!");
            Task.WaitAll(
                //ctr.TypePlaylist(),
                //ctr.GetExistingSearchKeysAsync()
                //ctr.CrawlFromSearch()
                //ctr.ClearCollection()
                //ctr1.ClearCollection("Test"),
                ctr1.InitTestCollection()
                //ctr1.CrawlFromSearch()
            );
        }
    }
}
