using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Helper
{
    public class FirestoreService
    {
        private static readonly string CONFIG_PATH = "cross-platform-music-firebase-adminsdk-6e112-689a7c7543.json";
        private FirestoreDb db;
        private string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\" + CONFIG_PATH;


        private static FirestoreService _instance;
        public static FirestoreService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FirestoreService();
                }
                return _instance;
            }
        }
        private FirestoreService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("cross-platform-music");
            Console.WriteLine("**Init Firestore**");
        }

        public async Task SetAsync<T>(string path, string id, T model)
        {
            DocumentReference docRef = db.Collection(path).Document(id);
            await docRef.SetAsync(model, SetOptions.MergeAll);
            Console.WriteLine(docRef.Id);
        }
        public async Task DeleteAsync<T>(string path, string id, T model)
        {
            DocumentReference docRef = db.Collection(path).Document(id);
            await docRef.SetAsync(model, SetOptions.MergeAll);
            Console.WriteLine(docRef.Id);
        }
        public async Task AddAsync<T>(string path, T model)
        {
            DocumentReference docRef = await db.Collection(path).AddAsync(model);
            Console.WriteLine("Set doc with id: ", docRef.Id);
        }
    }
}
