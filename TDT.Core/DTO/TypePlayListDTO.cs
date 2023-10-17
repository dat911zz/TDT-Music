﻿using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Linq;

namespace TDT.Core.DTO
{
    [FirestoreData]
    public class TypePlaylistDTO
    {
        private string _sectionType;
        private string _viewType;
        private string _title;
        private string _link;
        private string _sectionId;
        private Dictionary<string, string> _playlists;
        private Genre _genre;
        public TypePlaylistDTO() { }

        [FirestoreProperty]
        public string sectionType { get => _sectionType; set => _sectionType = value; }
        [FirestoreProperty]
        public string viewType { get => _viewType; set => _viewType = value; }
        [FirestoreProperty]
        public string title { get => _title; set => _title = value; }
        [FirestoreProperty]
        public string link { get => _link; set => _link = value; }
        [FirestoreProperty]
        public string sectionId { get => _sectionId; set => _sectionId = value; }
        [FirestoreProperty]
        public Dictionary<string, string> playlists { get => _playlists; set => _playlists = value; }
        [FirestoreProperty]
        public Genre genre { get => _genre; set => _genre = value; }

        public bool compare(TypePlaylistDTO other)
        {
            if (this.sectionType != other.sectionType || this.viewType != other.viewType ||
                this.sectionId != other.sectionId || this.playlists.Count != other.playlists.Count)
                return false;
            foreach (var item in other.playlists)
            {
                if (!this.playlists.Keys.Contains(item.Key))
                    return false;
            }
            return genre.compare(other.genre);
        }
    }
}
