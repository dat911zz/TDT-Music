using System;
using System.Collections.Generic;
using TDT.Core.DTO.Firestore;
using TDT.Core.Ultils;
using TDT.Firestore.ModelClone;

namespace TDT.Firestore
{
    public class ConvertService
    {
        private static ConvertService _instance;
        private ConvertService() { }
        public static ConvertService Instance
        {
            get
            {
                if(_instance == null )
                {
                    _instance = new ConvertService();
                }
                return _instance;
            }
        }

        //public TypePlaylistDTO convertToTypePlayListDTO(TypePlayList typePlayList)
        //{
        //    TypePlaylistDTO result = new TypePlaylistDTO();
        //    result.sectionType = typePlayList.sectionType;
        //    result.viewType = typePlayList.viewType;
        //    result.title = typePlayList.title;
        //    result.link = typePlayList.link;
        //    result.sectionId = typePlayList.sectionId;
        //    result.genre = typePlayList.genre;
        //    result.playlists = new List<string>();
        //    foreach(Playlist playlist in typePlayList.items)
        //    {
        //        result.playlists.Add(playlist.encodeId);
        //    }
        //    return result;
        //}

        //public PlaylistDTO convertToPlaylistDTO(Playlist playlist)
        //{
        //    PlaylistDTO result = new PlaylistDTO();
        //    result.encodeId = playlist.encodeId;
        //    result.title = playlist.title;
        //    result.thumbnail = playlist.thumbnail;
        //    result.isoffical = playlist.isoffical;
        //    result.link = playlist.link;
        //    result.isIndie = playlist.isIndie;
        //    result.releaseDate = playlist.releaseDate;
        //    result.sortDescription = playlist.sortDescription;
        //    result.releasedAt = playlist.releasedAt;
        //    result.genreIds = playlist.genreIds;
        //    result.PR = playlist.PR;
        //    result.artists = new Dictionary<string, string>();
        //    if(playlist.artists != null)
        //    {
        //        foreach (Artist artist in playlist.artists)
        //        {
        //            result.artists[artist.id] = artist.alias;
        //        }
        //    }
        //    result.artistsNames = playlist.artistsNames;
        //    result.playItemMode = playlist.playItemMode;
        //    result.subType = playlist.subType;
        //    result.uid = playlist.uid;
        //    result.thumbnailM = playlist.thumbnailM;
        //    result.isShuffle = playlist.isShuffle;
        //    result.isPrivate = playlist.isPrivate;
        //    result.userName = playlist.userName;
        //    result.isAlbum = playlist.isAlbum;
        //    result.textType = playlist.textType;
        //    result.isSingle = playlist.isSingle;
        //    result.distributor = playlist.distributor;
        //    result.aliasTitle = playlist.aliasTitle;
        //    result.sectionId = playlist.sectionId;
        //    result.contentLastUpdate = playlist.contentLastUpdate;
        //    result.songs = new Dictionary<string, string>();
        //    foreach (Song song in playlist.song.items)
        //    {
        //        result.songs[song.encodeId] = song.alias;
        //    }
        //    result.bannerAdaptiveId = playlist.bannerAdaptiveId;
        //    result.like = playlist.like;
        //    result.listen = playlist.listen;
        //    result.liked = playlist.liked;
        //    return result;
        //}

        //public SectionDTO convertToSectionDTO(Section section)
        //{
        //    SectionDTO result = new SectionDTO();
        //    result.sectionType = section.sectionType;
        //    result.viewType = section.viewType;
        //    result.title = section.title;
        //    result.link = section.link;
        //    result.sectionId = section.sectionId;
        //    result.items = new Dictionary<string, string>();
        //    if(section.items != null)
        //    {
        //        foreach (SectionItem item in section.items)
        //        {
        //            result.items[item.encodeId ?? item.id] = String.IsNullOrEmpty(item.alias) ? item.title : item.alias;
        //        }
        //    }
        //    result.itemType = section.itemType ?? "";
        //    return result;
        //}

        //public ArtistDTO convertToArtistDTO(Artist artist)
        //{
        //    ArtistDTO result = new ArtistDTO();
        //    result.id = artist.id;
        //    result.name = artist.name;
        //    result.link = artist.link;
        //    result.spotlight = artist.spotlight;
        //    result.alias = artist.alias;
        //    result.playlistId = artist.playlistId;
        //    result.cover = artist.cover;
        //    result.thumbnail = artist.thumbnail;
        //    result.biography = artist.biography;
        //    result.sortBiography = artist.sortBiography;
        //    result.thumbnailM = artist.thumbnailM;
        //    result.national = artist.national;
        //    result.birthday = artist.birthday;
        //    result.realname = artist.realname;
        //    result.totalFollow = artist.totalFollow;
        //    result.follow = artist.follow;
        //    result.sections = new Dictionary<string, SectionDTO>();
        //    if(artist.sections != null)
        //    {
        //        foreach (Section section in artist.sections)
        //        {
        //            result.sections[section.title] = convertToSectionDTO(section);
        //        }
        //    }
        //    result.sectionId = artist.sectionId;
        //    result.hasOA = artist.hasOA;
        //    return result;
        //}

        //public SongDTO convertToSongDTO(Song song)
        //{
        //    SongDTO result = new SongDTO();
        //    result.encodeId = song.encodeId;
        //    result.title = song.title;
        //    result.alias = song.alias;
        //    result.isOffical = song.isOffical;
        //    result.username = song.username;
        //    result.artistsNames = song.artistsNames;
        //    result.artists = new Dictionary<string, string>();
        //    if (song.artists != null)
        //    {
        //        foreach (Artist artist in song.artists)
        //        {
        //            result.artists[artist.id] = artist.alias;
        //        }
        //    }
        //    result.isWorldWide = song.isWorldWide;
        //    result.thumbnailM = song.thumbnailM;
        //    result.link = song.link;
        //    result.thumbnail = song.thumbnail;
        //    result.duration = song.duration;
        //    result.zingChoice = song.zingChoice;
        //    result.isPrivate = song.isPrivate;
        //    result.preRelease = song.preRelease;
        //    result.releaseDate = song.releaseDate;
        //    result.genreIds = song.genreIds;
        //    result.distributor = song.distributor;
        //    result.indicators = song.indicators;
        //    result.isIndie = song.isIndie;
        //    result.streamingStatus = song.streamingStatus;
        //    result.allowAudioAds = song.allowAudioAds;
        //    result.hasLyric = song.hasLyric;
        //    result.userid = song.userid;
        //    result.composers = new Dictionary<string, string>();
        //    if (song.composers != null)
        //    {
        //        foreach (Composer composer in song.composers)
        //        {
        //            result.composers[composer.id] = composer.alias;
        //        }
        //    }
        //    if (song.album != null)
        //    {
        //        result.album = song.album.encodeId;
        //    }
        //    result.isRBT = song.isRBT;
        //    result.like = song.like;
        //    result.listen = song.listen;
        //    result.liked = song.liked;
        //    result.comment = song.comment;
        //    return result;
        //}



        //public static Genre convertToGenreDTO(Genre genre)
        //{
        //    Genre result = new Genre();
        //    result.title = genre.title;
        //    result.name = genre.name;
        //    result.id = genre.id;
        //    result.alias = genre.alias;
        //    result.link = genre.link;
        //    return result;
        //}
        //public static SectionDTO convertToSectionDTO(Core.DTO.SectionDTO section)
        //{
        //    SectionDTO result = new SectionDTO();
        //    result.sectionType = section.sectionType;
        //    result.viewType = section.viewType;
        //    result.title = section.title;
        //    result.link = section.link;
        //    result.sectionId = section.sectionId;
        //    result.items = new List<string>();
        //    if (section.items != null)
        //    {
        //        result.items = section.items.Keys.ToList();
        //    }
        //    result.itemType = section.itemType ?? "";
        //    return result;
        //}
        //public static TypePlaylistDTO convertToTypePlayListDTO(Core.DTO.TypePlaylistDTO typePlayList)
        //{
        //    TypePlaylistDTO result = new TypePlaylistDTO();
        //    result.sectionType = typePlayList.sectionType;
        //    result.viewType = typePlayList.viewType;
        //    result.title = typePlayList.title;
        //    result.link = typePlayList.link;
        //    result.sectionId = typePlayList.sectionId;
        //    result.genre = convertToGenreDTO(typePlayList.genre);
        //    result.playlists = new List<string>();
        //    if (typePlayList.playlists != null)
        //    {
        //        result.playlists = typePlayList.playlists.Keys.ToList();
        //    }
        //    return result;
        //}
        //public static PlaylistDTO convertToPlaylistDTO(PlaylistDTO playlist)
        //{
        //    PlaylistDTO result = new PlaylistDTO();
        //    result.encodeId = playlist.encodeId;
        //    result.title = playlist.title;
        //    result.thumbnail = playlist.thumbnail;
        //    result.isoffical = playlist.isoffical;
        //    result.link = playlist.link;
        //    result.isIndie = playlist.isIndie;
        //    result.releaseDate = playlist.releaseDate;
        //    result.sortDescription = playlist.sortDescription;
        //    result.releasedAt = playlist.releasedAt;
        //    result.genreIds = playlist.genreIds;
        //    result.PR = playlist.PR;
        //    result.artists = new List<string>();
        //    if (playlist.artists != null)
        //    {
        //        result.artists = playlist.artists.Keys.ToList();
        //    }
        //    result.artistsNames = playlist.artistsNames;
        //    result.playItemMode = playlist.playItemMode;
        //    result.subType = playlist.subType;
        //    result.uid = playlist.uid;
        //    result.thumbnailM = playlist.thumbnailM;
        //    result.isShuffle = playlist.isShuffle;
        //    result.isPrivate = playlist.isPrivate;
        //    result.userName = playlist.userName;
        //    result.isAlbum = playlist.isAlbum;
        //    result.textType = playlist.textType;
        //    result.isSingle = playlist.isSingle;
        //    result.distributor = playlist.distributor;
        //    result.aliasTitle = playlist.aliasTitle;
        //    result.sectionId = playlist.sectionId;
        //    result.contentLastUpdate = playlist.contentLastUpdate;
        //    result.songs = new List<string>();
        //    if (playlist.songs != null)
        //    {
        //        result.songs = playlist.songs.Keys.ToList();
        //    }
        //    result.bannerAdaptiveId = playlist.bannerAdaptiveId;
        //    result.like = playlist.like;
        //    result.listen = playlist.listen;
        //    result.liked = playlist.liked;
        //    return result;
        //}
        //public static ArtistDTO convertToArtistDTO(ArtistDTO artist)
        //{
        //    ArtistDTO result = new ArtistDTO();
        //    result.id = artist.id;
        //    result.name = artist.name;
        //    result.link = artist.link;
        //    result.spotlight = artist.spotlight;
        //    result.alias = artist.alias;
        //    result.playlistId = artist.playlistId;
        //    result.cover = artist.cover;
        //    result.thumbnail = artist.thumbnail;
        //    result.biography = artist.biography;
        //    result.sortBiography = artist.sortBiography;
        //    result.thumbnailM = artist.thumbnailM;
        //    result.national = artist.national;
        //    result.birthday = artist.birthday;
        //    result.realname = artist.realname;
        //    result.totalFollow = artist.totalFollow;
        //    result.follow = artist.follow;
        //    result.sections = new Dictionary<string, SectionDTO>();
        //    if (artist.sections != null)
        //    {
        //        foreach (Core.DTO.SectionDTO section in artist.sections.Values)
        //        {
        //            result.sections[section.title] = convertToSectionDTO(section);
        //        }
        //    }
        //    result.sectionId = artist.sectionId;
        //    result.hasOA = artist.hasOA;
        //    return result;
        //}
        //public static SongDTO convertToSongDTO(Core.DTO.SongDTO song)
        //{
        //    SongDTO result = new SongDTO();
        //    result.encodeId = song.encodeId;
        //    result.title = song.title;
        //    result.alias = song.alias;
        //    result.isOffical = song.isOffical;
        //    result.username = song.username;
        //    result.artistsNames = song.artistsNames;
        //    result.artists = new List<string>();
        //    if (song.artists != null)
        //    {
        //        result.artists = song.artists.Keys.ToList();
        //    }
        //    result.isWorldWide = song.isWorldWide;
        //    result.thumbnailM = song.thumbnailM;
        //    result.link = song.link;
        //    result.thumbnail = song.thumbnail;
        //    result.duration = song.duration;
        //    result.zingChoice = song.zingChoice;
        //    result.isPrivate = song.isPrivate;
        //    result.preRelease = song.preRelease;
        //    result.releaseDate = song.releaseDate;
        //    result.genreIds = song.genreIds;
        //    result.distributor = song.distributor;
        //    result.indicators = song.indicators.Select(i => i.ToString()).ToList();
        //    result.isIndie = song.isIndie;
        //    result.streamingStatus = song.streamingStatus;
        //    result.allowAudioAds = song.allowAudioAds;
        //    result.hasLyric = song.hasLyric;
        //    result.userid = song.userid;
        //    result.composers = new List<string>();
        //    if (song.composers != null)
        //    {
        //        result.composers = song.composers.Keys.ToList();
        //    }
        //    result.album = song.album;
        //    result.isRBT = song.isRBT;
        //    result.like = song.like;
        //    result.listen = song.listen;
        //    result.liked = song.liked;
        //    result.comment = song.comment;
        //    return result;
        //}

        //public ModelUpdate.Song ConvertUpdateType(SongDTO song)
        //{
        //    ModelUpdate.Song result = new ModelUpdate.Song();
        //    result.encodeId = song.encodeId;
        //    result.title = song.title;
        //    result.alias = song.alias;
        //    result.isOffical = song.isOffical;
        //    result.username = song.username;
        //    result.artistsNames = song.artistsNames;
        //    result.artists = song.artists;
        //    result.isWorldWide = song.isWorldWide;
        //    result.thumbnailM = song.thumbnailM;
        //    result.link = song.link;
        //    result.thumbnail = song.thumbnail;
        //    result.duration = song.duration;
        //    result.zingChoice = song.zingChoice;
        //    result.isPrivate = song.isPrivate;
        //    result.preRelease = song.preRelease;
        //    result.releaseDate = long.Parse(song.releaseDate);
        //    result.genreIds = song.genreIds;
        //    result.distributor = song.distributor;
        //    result.indicators = song.indicators;
        //    result.isIndie = song.isIndie;
        //    result.streamingStatus = song.streamingStatus;
        //    result.allowAudioAds = song.allowAudioAds;
        //    result.hasLyric = song.hasLyric;
        //    result.userid = song.userid;
        //    result.composers = song.composers;
        //    result.album = song.album;
        //    result.isRBT = song.isRBT;
        //    result.like = song.like;
        //    result.listen = song.listen;
        //    result.liked = song.liked;
        //    result.comment = song.comment;
        //    return result;
        //}

        //public ModelUpdate.Playlist ConvertUpdateType(PlaylistDTO playlist)
        //{
        //    ModelUpdate.Playlist result = new ModelUpdate.Playlist();
        //    result.encodeId = playlist.encodeId;
        //    result.title = playlist.title;
        //    result.thumbnail = playlist.thumbnail;
        //    result.isoffical = playlist.isoffical;
        //    result.link = playlist.link;
        //    result.isIndie = playlist.isIndie;
        //    try
        //    {
        //        result.releaseDate = HelperUtility.GetTicks(DateTime.Parse(playlist.releaseDate));
        //    }
        //    catch
        //    {
        //        result.releaseDate = 0;
        //    }
        //    result.sortDescription = playlist.sortDescription;
        //    try
        //    {
        //        result.releasedAt = long.Parse(playlist.releasedAt);
        //    }
        //    catch
        //    {
        //        result.releasedAt = 0;
        //    }
        //    result.genreIds = playlist.genreIds;
        //    result.PR = playlist.PR;
        //    result.artists = playlist.artists;
        //    result.artistsNames = playlist.artistsNames;
        //    result.playItemMode = playlist.playItemMode;
        //    result.subType = playlist.subType;
        //    result.uid = playlist.uid;
        //    result.thumbnailM = playlist.thumbnailM;
        //    result.isShuffle = playlist.isShuffle;
        //    result.isPrivate = playlist.isPrivate;
        //    result.userName = playlist.userName;
        //    result.isAlbum = playlist.isAlbum;
        //    result.textType = playlist.textType;
        //    result.isSingle = playlist.isSingle;
        //    result.distributor = playlist.distributor;
        //    result.aliasTitle = playlist.aliasTitle;
        //    result.sectionId = playlist.sectionId;
        //    try
        //    {
        //        result.contentLastUpdate = long.Parse(playlist.contentLastUpdate);
        //    }
        //    catch
        //    {
        //        result.contentLastUpdate = 0;
        //    }
        //    result.songs = playlist.songs;
        //    result.bannerAdaptiveId = playlist.bannerAdaptiveId;
        //    result.like = playlist.like;
        //    result.listen = playlist.listen;
        //    result.liked = playlist.liked;
        //    return result;
        //}
    }
}
