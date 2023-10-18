using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TDT.Core.DTO.Firestore;
using TDT.Core.ModelClone;

namespace TDT.Core.DTO.Firestore
{
    [FirestoreData]
    public class SearchDTO
    {
        [FirestoreProperty]
        public Top? top { get; set; }
        [FirestoreProperty]
        public List<Artist>? artists { get; set; }
        [FirestoreProperty]
        public List<Song>? songs { get; set; }
        [FirestoreProperty]
        public List<Video>? videos { get; set; }
        [FirestoreProperty]
        public List<Playlist>? playlists { get; set; }
        [FirestoreProperty]
        public Counter counter { get; set; }
        [FirestoreProperty]
        public string sectionId { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    [FirestoreData]
    public class Video
    {
        [FirestoreProperty]
        public string encodeId { get; set; }
        [FirestoreProperty]
        public string title { get; set; }
        [FirestoreProperty]
        public string alias { get; set; }
        [FirestoreProperty]
        public bool isOffical { get; set; }
        [FirestoreProperty]
        public string username { get; set; }
        [FirestoreProperty]
        public string artistsNames { get; set; }
        [FirestoreProperty]
        public List<Artist> artists { get; set; }
        [FirestoreProperty]
        public bool isWorldWide { get; set; }
        [FirestoreProperty]
        public string thumbnailM { get; set; }
        [FirestoreProperty]
        public string link { get; set; }
        [FirestoreProperty]
        public string thumbnail { get; set; }
        [FirestoreProperty]
        public int duration { get; set; }
        [FirestoreProperty]
        public int streamingStatus { get; set; }
        [FirestoreProperty]
        public Artist artist { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    [FirestoreData]
    public class Counter
    {
        [FirestoreProperty]
        public int song { get; set; }
        [FirestoreProperty]
        public int artist { get; set; }
        [FirestoreProperty]
        public int playlist { get; set; }
        [FirestoreProperty]
        public int video { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    [FirestoreData]
    public class Top
    {
        [FirestoreProperty]
        public string encodeId { get; set; }
        [FirestoreProperty]
        public string title { get; set; }
        [FirestoreProperty]
        public string alias { get; set; }
        [FirestoreProperty]
        public bool isOffical { get; set; }
        [FirestoreProperty]
        public string username { get; set; }
        [FirestoreProperty]
        public string artistsNames { get; set; }
        [FirestoreProperty]
        public List<Artist> artists { get; set; }
        [FirestoreProperty]
        public bool isWorldWide { get; set; }
        [FirestoreProperty]
        public string thumbnailM { get; set; }
        [FirestoreProperty]
        public string link { get; set; }
        [FirestoreProperty]
        public string thumbnail { get; set; }
        [FirestoreProperty]
        public int duration { get; set; }
        [FirestoreProperty]
        public bool zingChoice { get; set; }
        [FirestoreProperty]
        public bool isPrivate { get; set; }
        [FirestoreProperty]
        public bool preRelease { get; set; }
        [FirestoreProperty]
        public int releaseDate { get; set; }
        [FirestoreProperty]
        public List<string> genreIds { get; set; }
        [FirestoreProperty]
        public string distributor { get; set; }
        [FirestoreProperty]
        public List<object> indicators { get; set; }
        [FirestoreProperty]
        public bool isIndie { get; set; }
        [FirestoreProperty]
        public int streamingStatus { get; set; }
        [FirestoreProperty]
        public bool allowAudioAds { get; set; }
        [FirestoreProperty]
        public bool hasLyric { get; set; }
        [FirestoreProperty]
        public string objectType { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
