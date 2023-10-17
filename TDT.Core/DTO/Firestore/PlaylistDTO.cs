﻿using System.Collections.Generic;
using System.Linq;

namespace TDT.Core.DTO.Firestore
{
    public class PlaylistDTO
    {
        private string _encodeId;
        private string _title;
        private string _thumbnail;
        private bool _isoffical;
        private string _link;
        private bool _isIndie;
        private string _releaseDate;
        private string _sortDescription;
        private string _releasedAt;
        private List<string> _genreIds;
        private bool _PR;
        private List<string> _artists;
        private string _artistsNames;
        private int _playItemMode;
        private int _subType;
        private int _uid;
        private string _thumbnailM;
        private bool _isShuffle;
        private bool _isPrivate;
        private string _userName;
        private bool _isAlbum;
        private string _textType;
        private bool _isSingle;
        private string _distributor;
        private string _description;
        private string _aliasTitle;
        private string _sectionId;
        private string _contentLastUpdate;
        private List<string> _songs;
        private object _bannerAdaptiveId;
        private int _like;
        private int _listen;
        private bool _liked;

        public string encodeId { get => _encodeId; set => _encodeId = value; }
        public string title { get => _title; set => _title = value; }
        public string thumbnail { get => _thumbnail; set => _thumbnail = value; }
        public bool isoffical { get => _isoffical; set => _isoffical = value; }
        public string link { get => _link; set => _link = value; }
        public bool isIndie { get => _isIndie; set => _isIndie = value; }
        public string releaseDate { get => _releaseDate; set => _releaseDate = value; }
        public string sortDescription { get => _sortDescription; set => _sortDescription = value; }
        public string releasedAt { get => _releasedAt; set => _releasedAt = value; }
        public List<string> genreIds { get => _genreIds; set => _genreIds = value; }
        public bool PR { get => _PR; set => _PR = value; }
        public List<string> artists { get => _artists; set => _artists = value; }
        public string artistsNames { get => _artistsNames; set => _artistsNames = value; }
        public int playItemMode { get => _playItemMode; set => _playItemMode = value; }
        public int subType { get => _subType; set => _subType = value; }
        public int uid { get => _uid; set => _uid = value; }
        public string thumbnailM { get => _thumbnailM; set => _thumbnailM = value; }
        public bool isShuffle { get => _isShuffle; set => _isShuffle = value; }
        public bool isPrivate { get => _isPrivate; set => _isPrivate = value; }
        public string userName { get => _userName; set => _userName = value; }
        public bool isAlbum { get => _isAlbum; set => _isAlbum = value; }
        public string textType { get => _textType; set => _textType = value; }
        public bool isSingle { get => _isSingle; set => _isSingle = value; }
        public string distributor { get => _distributor; set => _distributor = value; }
        public string description { get => _description; set => _description = value; }
        public string aliasTitle { get => _aliasTitle; set => _aliasTitle = value; }
        public string sectionId { get => _sectionId; set => _sectionId = value; }
        public string contentLastUpdate { get => _contentLastUpdate; set => _contentLastUpdate = value; }
        public List<string> songs { get => _songs; set => _songs = value; }
        public object bannerAdaptiveId { get => _bannerAdaptiveId; set => _bannerAdaptiveId = value; }
        public int like { get => _like; set => _like = value; }
        public int listen { get => _listen; set => _listen = value; }
        public bool liked { get => _liked; set => _liked = value; }

        public bool compare(PlaylistDTO other)
        {
            if(this.title != other.title || this.releasedAt != other.releasedAt || this.artistsNames != other.artistsNames ||
                this.description != other.description || this.sortDescription != other.sortDescription || 
                this.aliasTitle != other.aliasTitle || this.songs.Count != other.songs.Count)
                return false;
            foreach(var song in this.songs)
            {
                if(!other.songs.Contains(song))
                    return false;
            }
            return true;
        }
    }
}
