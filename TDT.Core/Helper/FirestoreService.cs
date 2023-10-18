using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.DTO.Firestore;

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
                await listDoc.ForEachAsync(doc =>
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
            //snapshot.Reference.Database.Document
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
            try
            {
                DocumentReference docRef = db.Collection(path).Document(id);
                await docRef.SetAsync(model, SetOptions.MergeAll);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }          
            //Console.WriteLine(docRef.Id);
        }
        public async Task<string> CTestAsync(string path)
        {
            var docRef = db.Document(path);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            //snapshot.Reference.Database.Document
            if (snapshot.Exists)
            {
                var tests = snapshot.ConvertTo<List<SongDTO>>();
                var list = snapshot.ToDictionary().Select(c => new SongDTO(GetObject<SongDTO>((Dictionary<string, object>)c.Value)));
                return snapshot.Id;
            }
            else
            {
                Console.WriteLine("-Document {0} does not exist!", snapshot.Id);
                return null;
            }
        }
        public Object GetObject(Dictionary<string, object> dict, Type type)
        {
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                var prop = type.GetProperty(kv.Key);
                if (prop == null) continue;

                object value = kv.Value;
                if (value is Dictionary<string, object>)
                {
                    value = GetObject((Dictionary<string, object>)value, prop.PropertyType); // <= This line
                }

                prop.SetValue(obj, value, null);
            }
            return obj;
        }
        public T GetObject<T>(Dictionary<string, object> dict)
        {
            return (T)GetObject(dict, typeof(T));
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
