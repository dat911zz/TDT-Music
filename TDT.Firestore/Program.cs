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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hello World!");
            Task.WaitAll(
                //ctr.TypePlaylist(),
                //ctr.GetExistingSearchKeysAsync()
                //ctr.CrawlFromSearch()
                

            //ctr.ClearCollection()
            );
        }
    }
}
