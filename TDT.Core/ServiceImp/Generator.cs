using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDT.Core.DTO.Firestore;
using TDT.Core.Helper;
using TDT.Core.Ultils;

namespace TDT.Core.ServiceImp
{
    public class Generator
    {
        private Generator() { }
        private static Generator _instance;
        public static Generator Instance { 
            get { 
                if( _instance == null )
                    _instance = new Generator();
                return _instance;
            } 
        }

        public string GenerateSongRelease(List<SongDTO> songs)
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"
                <div class=""column mar-b-0 is-fullhd-4 is-widescreen-4 is-desktop-4 is-touch-6 is-tablet-6"">
                    <div class=""list"">
            ");
            foreach(SongDTO song in songs)
            {
                
                string img;
                if(DataHelper.Instance.ThumbSong.Keys.Contains(song.encodeId))
                {
                    img = DataHelper.Instance.ThumbSong[song.encodeId];
                }
                else
                {
                    img = FirebaseService.Instance.getStorage(song.thumbnail);
                    DataHelper.Instance.ThumbSong.Add(song.encodeId, img);
                }
                int iArt = 0;
                string betweenDate = HelperUtility.getBetweenDate(song.ReleaseDate());
                string duration = song.Duration();
                str.AppendFormat(@"
                        <div class=""list-item hide-right media-item hide-right full-left"">
                            <div class=""media"">
                                <div class=""media-left"">
                                    <div class=""song-thumb"">
                                        <figure class=""image is-60x60"" title=""{0}"">
                                            <img src=""{1}"" alt="""" />
                                        </figure>
                                        <div class=""opacity""></div>
                                        <div class=""zm-actions-container"">
                                            <div class=""zm-box zm-actions"">
                                                <button
                                                    class=""zm-btn zm-tooltip-btn animation-like is-hidden active is-hover-circle button""
                                                    tabindex=""0"">
                                                    <i class=""icon ic-like""></i>
                                                    <i class=""icon ic-like-full""></i>
                                                </button>
                                                <button class=""zm-btn action-play button"" tabindex=""0"">
                                                    <i class=""icon action-play ic-play""></i>
                                                </button>
                                                <button class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0"">
                                                    <i class=""icon ic-more""></i>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""card-info"">
                                        <div class=""title-wrapper"">
                                            <span class=""item-title title"">
                                                <span>
                                                    <span>
                                                        <span>{2}</span>
                                                    </span>
                                                    <span style=""
                                                          position: fixed;
                                                          visibility: hidden;
                                                          top: 0px;
                                                          left: 0px;
                                                        "">…</span>
                                                </span>
                                            </span>
                                        </div>
                                        <h3 class=""is-one-line is-truncate subtitle"">", song.title, img, song.title);
                if(song.artists != null)
                {
                    foreach (var item in song.artists)
                    {
                        ArtistDTO artDTO = new ArtistDTO();
                        if (!DataHelper.Instance.Artists.Keys.Contains(item))
                        {
                            artDTO = FirestoreService.Instance.Gets<ArtistDTO>("Artist", item);
                            if (artDTO == null)
                                continue;
                            try
                            {
                                DataHelper.Instance.Artists.Add(artDTO.id, artDTO);
                            }
                            catch { }
                        }
                        else
                        {
                            artDTO = DataHelper.Instance.Artists[item];
                        }
                        if (string.IsNullOrEmpty(artDTO.name))
                            continue;
                        if (iArt++ > 0)
                        {
                            str.Append(", ");
                        }
                        str.AppendFormat(@"
                                            <a class=""is-ghost"" href=""{1}"">{0}</a>
                    ", artDTO.name, artDTO.link);
                    }
                }

                str.AppendFormat(@"
                                        </h3>
                                        <div class=""time-release"">
                                            <span>{0}</span>
                                        </div>
                                    </div>
                                </div>
                                <div class=""media-right"">
                                    <div class=""hover-items"">
                                        <div class=""level"">
                                            <div class=""level-item""></div>
                                            <div class=""level-item"">
                                                <button class=""zm-btn zm-tooltip-btn is-hover-circle button"" tabindex=""0"">
                                                    <i class=""icon ic-karaoke""></i>
                                                </button>
                                            </div>
                                            <div class=""level-item"">
                                                <button
                                                    class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                                    tabindex=""0"">
                                                    <i class=""icon ic-like""></i>
                                                    <i class=""icon ic-like-full""></i>
                                                </button>
                                            </div>
                                            <div class=""level-item"">
                                                <button class=""zm-btn zm-tooltip-btn is-hover-circle button"" tabindex=""0"">
                                                    <i class=""icon ic-more""></i>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""action-items"">
                                        <div class=""level"">
                                            <div class=""level-item"">
                                                <button
                                                    class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                                    tabindex=""0"">
                                                    <i class=""icon ic-like""></i>
                                                    <i class=""icon ic-like-full""></i>
                                                </button>
                                            </div>
                                            <div class=""level-item duration"">{1}</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                ", betweenDate, duration);
            }
            str.Append(@"
                    </div>
                </div>
            ");
            return str.ToString();
        }

        /// <summary>
        /// optionLast = 0 : title,
        /// optionLast = 1 : artists
        /// </summary>
        /// <param name="optionLast">0: title</param>
        /// <param name="optionLast">1: artists</param>
        /// <returns></returns>
        public string GeneratePlaylist(List<PlaylistDTO> playlists, int optionLast = 0)
        {
            StringBuilder str = new StringBuilder();
            foreach (var playlist in playlists)
            {
                string img;
                if (DataHelper.Instance.ThumbPlaylist.Keys.Contains(playlist.encodeId))
                {
                    img = DataHelper.Instance.ThumbPlaylist[playlist.encodeId];
                }
                else
                {
                    img = FirebaseService.Instance.getStorage(playlist.thumbnail);
                    try
                    {
                        DataHelper.Instance.ThumbPlaylist.Add(playlist.encodeId, img);
                    }
                    catch { }
                }
                string last = string.Empty;
                if(optionLast == 0)
                {
                    last = playlist.title;
                }
                else if(playlist.artists != null)
                {
                    int iArt = 0;
                    foreach (var item in playlist.artists)
                    {
                        ArtistDTO artDTO = new ArtistDTO();
                        if (!DataHelper.Instance.Artists.Keys.Contains(item))
                        {
                            artDTO = FirestoreService.Instance.Gets<ArtistDTO>("Artist", item);
                            if (artDTO == null)
                                continue;
                            try
                            {
                                DataHelper.Instance.Artists.Add(artDTO.id, artDTO);
                            }
                            catch { }
                        }
                        else
                        {
                            artDTO = DataHelper.Instance.Artists[item];
                        }
                        if (string.IsNullOrEmpty(artDTO.name))
                            continue;
                        if (iArt++ > 0)
                        {
                            last += ", ";
                        }
                        last += string.Format(@"
                                            <a class=""is-ghost"" href=""{1}"">{0}</a>
                    ", artDTO.name, artDTO.link);
                    }
                }
                str.AppendFormat(@"
                    <div class=""zm-carousel-item is-fullhd-20 is-widescreen-20 is-desktop-3 is-touch-3 is-tablet-3"">
                        <div class=""playlist-wrapper is-description"">
                            <div class=""zm-card"">
                                <div>
                                    <a class="""" title=""{0}""
                                        href=""{1}"">
                                        <div class=""zm-card-image"">
                                            <figure class=""image is-48x48"">
                                                <img src=""{2}"" alt="""" />
                                            </figure>
                                        </div>
                                    </a>
                                </div>
                                <div class=""zm-card-content"">
                                    <h3 class=""mt-10 subtitle"">
                                        <span>
                                            <span>
                                                <span>{3}</span>
                                            </span>
                                            <span style=""position: fixed; visibility: hidden; top: 0px; left: 0px; "">…</span>
                                        </span>
                                    </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                ", playlist.title, $"/Album?encodeId={playlist.encodeId}", img, last);
            }
            return str.ToString();
        }

        public string GenerateArtist(List<ArtistDTO> artists, int optionLast = 0)
        {
            StringBuilder str = new StringBuilder();
            foreach (var artist in artists)
            {
                string img;
                if (DataHelper.Instance.ThumbArtist.Keys.Contains(artist.id))
                {
                    img = DataHelper.Instance.ThumbArtist[artist.id];
                }
                else
                {
                    img = FirebaseService.Instance.getStorage(artist.thumbnail);
                    try
                    {
                        DataHelper.Instance.ThumbArtist.Add(artist.id, img);
                    }
                    catch { }
                }
                str.AppendFormat(@"
                    <div class=""zm-carousel-item is-fullhd-20 is-widescreen-20 is-desktop-3 is-touch-3 is-tablet-3"">
                        <div class=""playlist-wrapper is-description"">
                            <div class=""zm-card"">
                                <div>
                                    <a class="""" title=""Những Bài Hát Hay Nhất Của {0}""
                                       href=""{1}"">
                                        <div class=""zm-card-image"">
                                            <figure class=""image is-48x48"">
                                                <img src=""{2}"" alt="""" />
                                            </figure>
                                        </div>
                                    </a>
                                </div>
                                <div class=""zm-card-content"">
                                    <h3 class=""mt-10 subtitle"">
                                        <span>
                                            <span>
                                                <a class=""is-ghost"" href=""{3}"">{4}</a>
                                            </span>
                                            <span style=""position: fixed; visibility: hidden; top: 0px; left: 0px;""></span>
                                        </span>
                                    </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                ", artist.name, artist.playlistId, img, artist.link, artist.name);
            }
            return str.ToString();
        }

      
    }
}
