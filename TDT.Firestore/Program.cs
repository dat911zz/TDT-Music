using System;
using TDT.Firestore;

namespace TDTFirestore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FirestoreController.Instance.TypePlaylist();
        }
    }
}
