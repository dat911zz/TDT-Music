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
        public async Task<IDictionary<string, object>> Gets(string path, string id = "")
        {
            IDictionary<string, object> result = null;
            if (string.IsNullOrEmpty(id))
            {
                var listDoc = db.Collection(path).ListDocumentsAsync();
                await listDoc.ForEachAsync(async doc =>
                {
                    result = await GetDocumentReference(doc);
                });
            }
            else
            {
                result = await GetDocumentReference(db.Collection(path).Document(id));
            }        
            return result;
        }
        public async Task<IDictionary<string, object>> GetDocumentReference(DocumentReference docRef)
        {
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                Console.WriteLine("-Document data for {0} document:", snapshot.Id);
                Dictionary<string, object> city = snapshot.ToDictionary();
                foreach (KeyValuePair<string, object> pair in city)
                {
                    Console.WriteLine("---{0}: {1}", pair.Key, pair.Value);
                }
                return city;
            }
            else
            {
                Console.WriteLine("-Document {0} does not exist!", snapshot.Id);
                return null;
            }
        }
        public async Task<IList<string>> GetKeys(string path, string id = "")
        {
            IList<string> result = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                var listDoc = db.Collection(path).ListDocumentsAsync();
                await listDoc.ForEachAsync(async doc =>
                {
                    result.Add(doc.Id);
                });
            }
            else
            {
                result.Add(await GetDocumentReferenceKey(db.Collection(path).Document(id)));
            }
            return result;
        }
        public async Task<string> GetDocumentReferenceKey(DocumentReference docRef)
        {
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return snapshot.Id;
            }
            else
            {
                Console.WriteLine("-Document {0} does not exist!", snapshot.Id);
                return null;
            }
        }
        public async Task SetAsync<T>(string path, string id, T model)
        {
            DocumentReference docRef = db.Collection(path).Document(id);
            await docRef.SetAsync(model, SetOptions.MergeAll);
            //Console.WriteLine(docRef.Id);
        }
        public async Task DeleteAsync(string path)
        {
            var snapshot = db.Collection(path).GetSnapshotAsync();
            await DeleteCollection(db.Collection(path), 100000);
        }
        private async Task DeleteCollection(CollectionReference collectionReference, int batchSize)
        {
            QuerySnapshot snapshot = await collectionReference.Limit(batchSize).GetSnapshotAsync();
            IReadOnlyList<DocumentSnapshot> documents = snapshot.Documents;
            while (documents.Count > 0)
            {
                foreach (DocumentSnapshot document in documents)
                {
                    Console.WriteLine("Deleting document {0}", document.Id);
                    await document.Reference.DeleteAsync();
                }
                snapshot = await collectionReference.Limit(batchSize).GetSnapshotAsync();
                documents = snapshot.Documents;
            }
            Console.WriteLine("Finished deleting all documents from the collection.");
        }
        //public async Task AddAsync<T>(string path, T model)
        //{
        //    DocumentReference docRef = await db.Collection(path).AddAsync(model);
        //    Console.WriteLine("Set doc with id: ", docRef.Id);
        //}
    }
}
