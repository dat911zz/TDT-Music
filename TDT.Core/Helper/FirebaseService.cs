using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Auth;
using Firebase.Storage;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using TDT.Core.DTO;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace TDT.Core.Helper
{
    public class FirebaseService
    {
        private static string PATH_PARENT = Environment.CurrentDirectory.ToString();
        private static string API_KEY = "AIzaSyDwp_ckD5x1m6WI_rWN9e1y18XKTr7o_j8";
        private static string BUCKET = "cross-platform-music.appspot.com";
        private static string AuthMail = "thinh.chauvan2405@gmail.com";
        private static string AuthPassword = "admin@admin$123";

        private static string folderNameImage = "images";

        private static string SECRET = "tBlpQ6nNoUv45MjsMVX4rxiZop9TMbZPRlayAnSc";
        private static string PATH_DB = @"https://cross-platform-music-default-rtdb.firebaseio.com/";
        private static string CONFIG_PATH = @".\Config\cross-platform-music-firebase-adminsdk-6e112-234ac26bb6.json";
        private static FirebaseService _instance;
        public FirebaseClient firebase;
        public FirebaseStorage storage;

        private static FirebaseAuthProvider authProvider;
        private static FirebaseAuthLink authLink;

        private FirebaseService()
        {
            firebase = new FirebaseClient(PATH_DB,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(authLink.FirebaseToken)
                });
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
            login().Wait();
            storage = new FirebaseStorage(BUCKET,
                         new FirebaseStorageOptions
                         {
                             AuthTokenAsyncFactory = () => Task.FromResult(authLink.FirebaseToken),
                             ThrowOnCancel = true,
                         });
        }
        public static FirebaseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FirebaseService();
                }
                else
                {
                    if(authLink == null || authLink.IsExpired())
                    {
                        login().Wait();
                    }
                }
                return _instance;
            }
        }

        public async Task<T> getSingleValue<T>(string path)
        {
            return await firebase.Child(path).OnceSingleAsync<T>();
        }
        public Dictionary<string, object> getDictionary(string path, string index = null)
        {
            var json = "";
            if(index != null)
            {
                json = getValueJson(path, index).Result;
            }
            else json = getValueJson(path).Result;
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }
        public async Task<string> getValueJson(string path, string index = null)
        {
            if (index != null)
            {
                return await firebase.Child(path).OrderBy(index).LimitToFirst(1000000000).OnceAsJsonAsync();
            }
            return await firebase.Child(path).OnceAsJsonAsync();
        }
        public async void push(string nameNodeParent, object obj)
        {
            await firebase.Child(nameNodeParent).PutAsync(obj);
        }
        public async void delete(string nameNode)
        {
            await firebase.Child(nameNode).DeleteAsync();
        }

        public async Task<IReadOnlyCollection<FirebaseObject<PlaylistDTO>>> getPlaylistRelease()
        {
            return await firebase.Child("Playlist").OnceAsync<PlaylistDTO>();
        }

        private static async Task login()
        {
            try
            {
                authLink = await authProvider.SignInWithEmailAndPasswordAsync(AuthMail, AuthPassword);
            }
            catch (FirebaseAuthException ex)
            {

            }
        }

        public string getStorage(string path)
        {
            try
            {
                var result = storage.Child(path).GetDownloadUrlAsync();
                return result.Result;
            }
            catch
            {
                return "";
            }
        }
        public async Task<string> pushFile(string url, string nameParent)
        {
            try
            {
                Stream stream = HttpClone.Intance.CreateFileFromUrl(url);
                if (stream != null)
                {
                    var task = await storage.Child(nameParent).PutAsync(stream);
                    return task;
                }
                return "Creat stream error: " + nameParent;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IReadOnlyCollection<FirebaseObject<PlaylistDTO>>> get1()
        {
            //string str = "Top";
            //return await firebase.Child("Playlist").OrderBy("title").StartAt(str).EndAt(str + "\uf8ff").OnceAsync<PlaylistDTO>();
            return await firebase.Child("Playlist").OrderByKey().StartAt("(Single)").EndAt("(Single)" + "~").OnceAsync<PlaylistDTO>();
            //return await firebase.Child("Playlist").OrderBy("contentLastUpdate").OnceAsync<PlaylistDTO>();
        }
    }
}
