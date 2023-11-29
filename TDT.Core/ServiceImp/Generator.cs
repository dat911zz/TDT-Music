using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDT.Core.DTO.Firestore;
using TDT.Core.Helper;
using TDT.Core.Ultils;

namespace TDT.Core.ServiceImp
{
    public static class Generator
    {
        public static string AddPlaylistModal = @"
            <div id=""react-cool-portal"">
                <div class=""zm-portal-modal"">
                    <div class=""modal is-active"">
                        <div role=""presentation"" class=""modal-background"">
                            <div class=""modal-content"">
                                <div class=""form-playlist-content""><button
                                        class=""zm-btn zm-tooltip-btn close-btn is-hover-circle button"" tabindex=""0""><i
                                            class=""icon ic-close""></i></button>
                                    <h3 class=""title"">Tạo playlist mới</h3>
                                    <div id=""form-add-playlist""><input class=""input"" placeholder=""Nhập tên playlist"" value="""">
                                        <div class=""option"">
                                            <div>
                                                <h3 class=""title"">Công khai</h3>
                                                <h3 class=""subtitle"">Mọi người có thể nhìn thấy playlist này</h3>
                                            </div>
                                            <div><i class=""icon ic-svg-switch is-hide""><svg id=""Layer_1"" x=""0px"" y=""0px"" width=""24px""
                                                        height=""15px"" viewBox=""0 0 24 15"" xml:space=""preserve"">
                                                        <style type=""text/css"">
                                                            .st1 {
                                                                fill-rule: evenodd;
                                                                clip-rule: evenodd;
                                                                fill: #FFFFFF;
                                                            }
                                                        </style>
                                                        <path id=""Rectangle-8"" class=""st0""
                                                            d=""M16.5,0h-9C3.4,0,0,3.4,0,7.5l0,0C0,11.6,3.4,15,7.5,15h9c4.1,0,7.5-3.4,7.5-7.5l0,0 C24,3.4,20.6,0,16.5,0z"">
                                                        </path>
                                                        <circle id=""Oval-2"" class=""st1"" cx=""16.5"" cy=""7.5"" r=""6.5""></circle>
                                                    </svg></i><i class=""icon ic-svg-switch zm-switch-off""><svg id=""Layer_1""
                                                        x=""0px"" y=""0px"" width=""24px"" height=""15px"" viewBox=""0 0 24 15""
                                                        xml:space=""preserve"">
                                                        <style type=""text/css"">
                                                            .st1 {
                                                                fill-rule: evenodd;
                                                                clip-rule: evenodd;
                                                                fill: #FFFFFF;
                                                            }
                                                        </style>
                                                        <path id=""Rectangle-8"" class=""st0""
                                                            d=""M7.5,0h9C20.6,0,24,3.4,24,7.5l0,0c0,4.1-3.4,7.5-7.5,7.5h-9C3.4,15,0,11.6,0,7.5l0,0 C0,3.4,3.4,0,7.5,0z"">
                                                        </path>
                                                        <circle id=""Oval-2"" class=""st1"" cx=""7.5"" cy=""7.5"" r=""6.5""></circle>
                                                    </svg></i></div>
                                        </div>
                                        <div class=""option"">
                                            <div>
                                                <h3 class=""title"">Phát ngẫu nhiên</h3>
                                                <h3 class=""subtitle"">Luôn phát ngẫu nhiên tất cả bài hát</h3>
                                            </div>
                                            <div><i class=""icon ic-svg-switch is-hide""><svg id=""Layer_1"" x=""0px"" y=""0px"" width=""24px""
                                                        height=""15px"" viewBox=""0 0 24 15"" xml:space=""preserve"">
                                                        <style type=""text/css"">
                                                            .st1 {
                                                                fill-rule: evenodd;
                                                                clip-rule: evenodd;
                                                                fill: #FFFFFF;
                                                            }
                                                        </style>
                                                        <path id=""Rectangle-8"" class=""st0""
                                                            d=""M16.5,0h-9C3.4,0,0,3.4,0,7.5l0,0C0,11.6,3.4,15,7.5,15h9c4.1,0,7.5-3.4,7.5-7.5l0,0 C24,3.4,20.6,0,16.5,0z"">
                                                        </path>
                                                        <circle id=""Oval-2"" class=""st1"" cx=""16.5"" cy=""7.5"" r=""6.5""></circle>
                                                    </svg></i><i class=""icon ic-svg-switch zm-switch-off""><svg id=""Layer_1""
                                                        x=""0px"" y=""0px"" width=""24px"" height=""15px"" viewBox=""0 0 24 15""
                                                        xml:space=""preserve"">
                                                        <style type=""text/css"">
                                                            .st1 {
                                                                fill-rule: evenodd;
                                                                clip-rule: evenodd;
                                                                fill: #FFFFFF;
                                                            }
                                                        </style>
                                                        <path id=""Rectangle-8"" class=""st0""
                                                            d=""M7.5,0h9C20.6,0,24,3.4,24,7.5l0,0c0,4.1-3.4,7.5-7.5,7.5h-9C3.4,15,0,11.6,0,7.5l0,0 C0,3.4,3.4,0,7.5,0z"">
                                                        </path>
                                                        <circle id=""Oval-2"" class=""st1"" cx=""7.5"" cy=""7.5"" r=""6.5""></circle>
                                                    </svg></i></div>
                                        </div><button class=""zm-btn mar-t-20 is-outlined active is-fullwidth is-upper button""
                                            tabindex=""-1"" disabled=""""><i class=""icon""></i><span>Tạo mới</span></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        ";
        public static string GenerateSongRelease(List<SongDTO> songs)
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"
                <div class=""column mar-b-0 is-fullhd-4 is-widescreen-4 is-desktop-4 is-touch-6 is-tablet-6"">
                    <div class=""list"">
            ");
            foreach (SongDTO song in songs)
            {

                string img = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail);
                string betweenDate = HelperUtility.getBetweenDate(song.ReleaseDate());
                string duration = song.Duration();
                string premium = string.Empty;
                if(song.streamingStatus == -1)
                {
                    premium = @"<i class=""icon"">
                                    <svg width=""56"" height=""14"" viewBox=""0 0 56 14"" fill=""none"">
                                        <rect width=""56"" height=""14"" rx=""4"" fill=""#E5AC1A""></rect>
                                        <g clip-path=""url(#clip0_3541_3928)"">
                                            <path
                                                d=""M9.89231 4.22549C9.54389 4.07843 9.12579 4 8.64796 4H6.3086C6.219 4 6.14932 4.02941 6.08959 4.08824C6.02986 4.14706 6 4.21569 6 4.30392V9.68627C6 9.77451 6.02986 9.85294 6.08959 9.90196C6.14932 9.96078 6.219 9.9902 6.3086 9.9902H7.43348C7.52308 9.9902 7.60271 9.96078 7.65249 9.91177C7.72217 9.85294 7.75204 9.77451 7.75204 9.68627V7.97059H8.64796C9.12579 7.97059 9.53394 7.90196 9.89231 7.76471C10.2507 7.62745 10.5394 7.40196 10.7385 7.11765C10.9475 6.82353 11.0471 6.45098 11.0471 6.0098C11.0471 5.56863 10.9475 5.18627 10.7385 4.88235C10.5394 4.58824 10.2507 4.36275 9.89231 4.21569V4.22549ZM9.29502 6C9.29502 6.21569 9.23529 6.37255 9.11584 6.48039C8.99638 6.58824 8.82715 6.63725 8.6181 6.63725H7.74208V5.35294H8.6181C8.86697 5.35294 9.04615 5.41176 9.1457 5.52941C9.2552 5.65686 9.30498 5.80392 9.30498 6H9.29502Z""
                                                fill=""#FEFFFF""></path>
                                            <path
                                                d=""M16.5818 7.63725C16.8606 7.4902 17.0995 7.29412 17.2787 7.03922C17.4877 6.7549 17.5873 6.40196 17.5873 5.9902C17.5873 5.36275 17.3583 4.86275 16.9203 4.51961C16.4922 4.17647 15.895 4 15.1583 4H12.8787C12.7891 4 12.7194 4.02941 12.6597 4.08824C12.5999 4.14706 12.5701 4.21569 12.5701 4.30392V9.68627C12.5701 9.77451 12.5999 9.85294 12.6597 9.90196C12.7194 9.96078 12.7891 9.9902 12.8787 9.9902H13.9538C14.0434 9.9902 14.123 9.96078 14.1728 9.90196C14.2325 9.84314 14.2624 9.77451 14.2624 9.68627V7.94118H14.9592L15.885 9.70588C15.9149 9.7549 15.9547 9.81373 16.0144 9.88235C16.0841 9.95098 16.1836 9.9902 16.323 9.9902H17.428C17.5076 9.9902 17.5674 9.96078 17.6271 9.91177C17.6868 9.85294 17.7167 9.78431 17.7167 9.71569C17.7167 9.67647 17.7067 9.62745 17.6769 9.57843L16.5719 7.62745L16.5818 7.63725ZM15.8352 5.97059C15.8352 6.16667 15.7755 6.31373 15.666 6.42157C15.5565 6.52941 15.3873 6.58824 15.1483 6.58824H14.2823V5.35294H15.1483C15.3873 5.35294 15.5664 5.41176 15.666 5.51961C15.7755 5.63725 15.8352 5.78431 15.8352 5.97059Z""
                                                fill=""#FEFFFF""></path>
                                            <path
                                                d=""M23.5801 8.60784H20.9421V7.64706H23.3312C23.4208 7.64706 23.5005 7.61765 23.5602 7.55882C23.6199 7.5 23.6398 7.42157 23.6398 7.34314V6.61765C23.6398 6.52941 23.61 6.46078 23.5602 6.40196C23.5005 6.33333 23.4208 6.30392 23.3312 6.30392H20.9421V5.38235H23.5104C23.6 5.38235 23.6697 5.35294 23.7294 5.29412C23.7892 5.23529 23.819 5.16667 23.819 5.07843V4.30392C23.819 4.21569 23.7892 4.14706 23.7294 4.08824C23.6697 4.02941 23.6 4 23.5104 4H19.6082C19.5186 4 19.4489 4.02941 19.3892 4.08824C19.3294 4.14706 19.2996 4.21569 19.2996 4.30392V9.68627C19.2996 9.77451 19.3294 9.85294 19.3892 9.90196C19.4489 9.96078 19.5186 9.9902 19.6082 9.9902H23.5801C23.6697 9.9902 23.7394 9.96078 23.7991 9.90196C23.8588 9.84314 23.8887 9.77451 23.8887 9.68627V8.91177C23.8887 8.82353 23.8588 8.7549 23.7991 8.69608C23.7394 8.63725 23.6697 8.60784 23.5801 8.60784Z""
                                                fill=""#FEFFFF""></path>
                                            <path
                                                d=""M31.2054 4H30.3095C30.19 4 30.0904 4.03922 30.0208 4.10784C29.9809 4.15686 29.9411 4.19608 29.9212 4.23529L28.5375 6.69608L27.1638 4.2451C27.1638 4.2451 27.104 4.15686 27.0542 4.10784C26.9945 4.03922 26.895 4 26.7755 4H25.8696C25.79 4 25.7203 4.02941 25.6506 4.08824C25.5909 4.14706 25.561 4.21569 25.561 4.30392V9.68627C25.561 9.77451 25.5909 9.85294 25.6506 9.91177C25.7104 9.97059 25.79 9.9902 25.8696 9.9902H26.8751C26.9647 9.9902 27.0443 9.96078 27.0941 9.90196C27.1538 9.84314 27.1837 9.77451 27.1837 9.68627V6.97059L27.9402 8.36274C27.9701 8.42157 28.0199 8.48039 28.0696 8.51961C28.1294 8.57843 28.219 8.59804 28.3185 8.59804H28.7565C28.8561 8.59804 28.9457 8.56863 29.0054 8.51961C29.0651 8.47059 29.1049 8.41176 29.1248 8.36274L29.8814 6.97059V9.68627C29.8814 9.77451 29.9113 9.85294 29.971 9.91177C30.0307 9.97059 30.1104 9.9902 30.1999 9.9902H31.1954C31.285 9.9902 31.3647 9.96078 31.4144 9.91177C31.4841 9.85294 31.514 9.77451 31.514 9.68627V4.30392C31.514 4.21569 31.4841 4.13725 31.4144 4.08824C31.3547 4.02941 31.285 4 31.1954 4H31.2054Z""
                                                fill=""#FEFFFF""></path>
                                            <path
                                                d=""M34.8488 4H33.7239C33.6343 4 33.5546 4.02941 33.5049 4.08824C33.4451 4.14706 33.4153 4.21569 33.4153 4.30392V9.68627C33.4153 9.77451 33.4451 9.85294 33.5049 9.90196C33.5646 9.96078 33.6343 9.9902 33.7239 9.9902H34.8488C34.9384 9.9902 35.018 9.96078 35.0678 9.90196C35.1275 9.84314 35.1574 9.77451 35.1574 9.68627V4.30392C35.1574 4.21569 35.1275 4.14706 35.0678 4.08824C35.008 4.02941 34.9384 4 34.8488 4Z""
                                                fill=""#FEFFFF""></path>
                                            <path
                                                d=""M41.8969 4H40.8118C40.7322 4 40.6625 4.02941 40.5928 4.08824C40.5331 4.14706 40.5032 4.21569 40.5032 4.30392V7.62745C40.5032 7.95098 40.4236 8.19608 40.2643 8.36274C40.105 8.51961 39.896 8.59804 39.6073 8.59804C39.3186 8.59804 39.0896 8.51961 38.9403 8.36274C38.781 8.20588 38.7114 7.95098 38.7114 7.62745V4.30392C38.7114 4.21569 38.6815 4.14706 38.6218 4.08824C38.562 4.02941 38.4923 4 38.4028 4H37.3276C37.238 4 37.1584 4.02941 37.1086 4.08824C37.0489 4.14706 37.019 4.21569 37.019 4.30392V7.63725C37.019 8.16667 37.1285 8.61765 37.3376 8.97059C37.5566 9.31373 37.8652 9.57843 38.2534 9.7549C38.6417 9.92157 39.0996 10 39.6172 10C40.1349 10 40.5928 9.92157 40.981 9.7549C41.3693 9.58824 41.6779 9.32353 41.8969 8.97059C42.1159 8.61765 42.2154 8.16667 42.2154 7.63725V4.30392C42.2154 4.21569 42.1856 4.13725 42.1159 4.08824C42.0561 4.02941 41.9865 4 41.9068 4H41.8969Z""
                                                fill=""#FEFFFF""></path>
                                            <path
                                                d=""M49.9005 4.08824C49.8407 4.02941 49.771 4 49.6815 4H48.7855C48.6561 4 48.5665 4.03922 48.5068 4.10784C48.457 4.15686 48.4272 4.19608 48.4072 4.23529L47.0235 6.69608L45.6398 4.2451C45.6398 4.2451 45.5801 4.15686 45.5303 4.10784C45.4706 4.03922 45.371 4 45.2516 4H44.3457C44.2661 4 44.1864 4.02941 44.1267 4.08824C44.067 4.14706 44.0371 4.21569 44.0371 4.30392V9.68627C44.0371 9.77451 44.067 9.85294 44.1267 9.91177C44.1864 9.97059 44.2661 9.9902 44.3457 9.9902H45.3511C45.4407 9.9902 45.5204 9.96078 45.5701 9.90196C45.6299 9.84314 45.6597 9.77451 45.6597 9.68627V6.97059L46.4163 8.36274C46.4462 8.42157 46.4959 8.48039 46.5457 8.51961C46.6054 8.57843 46.695 8.59804 46.7946 8.59804H47.2326C47.3321 8.59804 47.4217 8.56863 47.4815 8.51961C47.5412 8.47059 47.581 8.41176 47.6009 8.36274L48.3575 6.97059V9.68627C48.3575 9.77451 48.3873 9.85294 48.4471 9.91177C48.5068 9.97059 48.5864 9.9902 48.676 9.9902H49.6715C49.7611 9.9902 49.8407 9.96078 49.8905 9.91177C49.9602 9.85294 49.99 9.77451 49.99 9.68627V4.30392C49.99 4.21569 49.9602 4.13725 49.8905 4.08824H49.9005Z""
                                                fill=""#FEFFFF""></path>
                                        </g>
                                        <defs>
                                            <clipPath id=""clip0_3541_3928"">
                                                <rect width=""44"" height=""6"" fill=""white"" transform=""translate(6 4)""></rect>
                                            </clipPath>
                                        </defs>
                                    </svg>
                                </i>";
                }
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
                                                        <span>{0}</span>
                                                    </span>
                                                    <span style=""
                                                          position: fixed;
                                                          visibility: hidden;
                                                          top: 0px;
                                                          left: 0px;
                                                        "">…</span>
                                                </span>
                                            </span>
                                            {2}
                                        </div>
                                        <h3 class=""is-one-line is-truncate subtitle"">", song.title, img, premium);
                if (song.artists != null)
                {
                    str.Append(GenerateArtistLink(song.artists));
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

        public static string GeneratePageSong(List<SongDTO> songs)
        {
            string res = string.Empty;
            foreach (var song in songs)
            {
                string premium = string.Empty;
                if(song.streamingStatus == -1)
                {
                    premium = @"
                        <i class=""icon"">
                                <svg width=""56"" height=""14"" viewBox=""0 0 56 14"" fill=""none"">
                                    <rect width=""56"" height=""14"" rx=""4"" fill=""#E5AC1A""></rect>
                                    <g clip-path=""url(#clip0_3541_3928)"">
                                        <path
                                            d=""M9.89231 4.22549C9.54389 4.07843 9.12579 4 8.64796 4H6.3086C6.219 4 6.14932 4.02941 6.08959 4.08824C6.02986 4.14706 6 4.21569 6 4.30392V9.68627C6 9.77451 6.02986 9.85294 6.08959 9.90196C6.14932 9.96078 6.219 9.9902 6.3086 9.9902H7.43348C7.52308 9.9902 7.60271 9.96078 7.65249 9.91177C7.72217 9.85294 7.75204 9.77451 7.75204 9.68627V7.97059H8.64796C9.12579 7.97059 9.53394 7.90196 9.89231 7.76471C10.2507 7.62745 10.5394 7.40196 10.7385 7.11765C10.9475 6.82353 11.0471 6.45098 11.0471 6.0098C11.0471 5.56863 10.9475 5.18627 10.7385 4.88235C10.5394 4.58824 10.2507 4.36275 9.89231 4.21569V4.22549ZM9.29502 6C9.29502 6.21569 9.23529 6.37255 9.11584 6.48039C8.99638 6.58824 8.82715 6.63725 8.6181 6.63725H7.74208V5.35294H8.6181C8.86697 5.35294 9.04615 5.41176 9.1457 5.52941C9.2552 5.65686 9.30498 5.80392 9.30498 6H9.29502Z""
                                            fill=""#FEFFFF""></path>
                                        <path
                                            d=""M16.5818 7.63725C16.8606 7.4902 17.0995 7.29412 17.2787 7.03922C17.4877 6.7549 17.5873 6.40196 17.5873 5.9902C17.5873 5.36275 17.3583 4.86275 16.9203 4.51961C16.4922 4.17647 15.895 4 15.1583 4H12.8787C12.7891 4 12.7194 4.02941 12.6597 4.08824C12.5999 4.14706 12.5701 4.21569 12.5701 4.30392V9.68627C12.5701 9.77451 12.5999 9.85294 12.6597 9.90196C12.7194 9.96078 12.7891 9.9902 12.8787 9.9902H13.9538C14.0434 9.9902 14.123 9.96078 14.1728 9.90196C14.2325 9.84314 14.2624 9.77451 14.2624 9.68627V7.94118H14.9592L15.885 9.70588C15.9149 9.7549 15.9547 9.81373 16.0144 9.88235C16.0841 9.95098 16.1836 9.9902 16.323 9.9902H17.428C17.5076 9.9902 17.5674 9.96078 17.6271 9.91177C17.6868 9.85294 17.7167 9.78431 17.7167 9.71569C17.7167 9.67647 17.7067 9.62745 17.6769 9.57843L16.5719 7.62745L16.5818 7.63725ZM15.8352 5.97059C15.8352 6.16667 15.7755 6.31373 15.666 6.42157C15.5565 6.52941 15.3873 6.58824 15.1483 6.58824H14.2823V5.35294H15.1483C15.3873 5.35294 15.5664 5.41176 15.666 5.51961C15.7755 5.63725 15.8352 5.78431 15.8352 5.97059Z""
                                            fill=""#FEFFFF""></path>
                                        <path
                                            d=""M23.5801 8.60784H20.9421V7.64706H23.3312C23.4208 7.64706 23.5005 7.61765 23.5602 7.55882C23.6199 7.5 23.6398 7.42157 23.6398 7.34314V6.61765C23.6398 6.52941 23.61 6.46078 23.5602 6.40196C23.5005 6.33333 23.4208 6.30392 23.3312 6.30392H20.9421V5.38235H23.5104C23.6 5.38235 23.6697 5.35294 23.7294 5.29412C23.7892 5.23529 23.819 5.16667 23.819 5.07843V4.30392C23.819 4.21569 23.7892 4.14706 23.7294 4.08824C23.6697 4.02941 23.6 4 23.5104 4H19.6082C19.5186 4 19.4489 4.02941 19.3892 4.08824C19.3294 4.14706 19.2996 4.21569 19.2996 4.30392V9.68627C19.2996 9.77451 19.3294 9.85294 19.3892 9.90196C19.4489 9.96078 19.5186 9.9902 19.6082 9.9902H23.5801C23.6697 9.9902 23.7394 9.96078 23.7991 9.90196C23.8588 9.84314 23.8887 9.77451 23.8887 9.68627V8.91177C23.8887 8.82353 23.8588 8.7549 23.7991 8.69608C23.7394 8.63725 23.6697 8.60784 23.5801 8.60784Z""
                                            fill=""#FEFFFF""></path>
                                        <path
                                            d=""M31.2054 4H30.3095C30.19 4 30.0904 4.03922 30.0208 4.10784C29.9809 4.15686 29.9411 4.19608 29.9212 4.23529L28.5375 6.69608L27.1638 4.2451C27.1638 4.2451 27.104 4.15686 27.0542 4.10784C26.9945 4.03922 26.895 4 26.7755 4H25.8696C25.79 4 25.7203 4.02941 25.6506 4.08824C25.5909 4.14706 25.561 4.21569 25.561 4.30392V9.68627C25.561 9.77451 25.5909 9.85294 25.6506 9.91177C25.7104 9.97059 25.79 9.9902 25.8696 9.9902H26.8751C26.9647 9.9902 27.0443 9.96078 27.0941 9.90196C27.1538 9.84314 27.1837 9.77451 27.1837 9.68627V6.97059L27.9402 8.36274C27.9701 8.42157 28.0199 8.48039 28.0696 8.51961C28.1294 8.57843 28.219 8.59804 28.3185 8.59804H28.7565C28.8561 8.59804 28.9457 8.56863 29.0054 8.51961C29.0651 8.47059 29.1049 8.41176 29.1248 8.36274L29.8814 6.97059V9.68627C29.8814 9.77451 29.9113 9.85294 29.971 9.91177C30.0307 9.97059 30.1104 9.9902 30.1999 9.9902H31.1954C31.285 9.9902 31.3647 9.96078 31.4144 9.91177C31.4841 9.85294 31.514 9.77451 31.514 9.68627V4.30392C31.514 4.21569 31.4841 4.13725 31.4144 4.08824C31.3547 4.02941 31.285 4 31.1954 4H31.2054Z""
                                            fill=""#FEFFFF""></path>
                                        <path
                                            d=""M34.8488 4H33.7239C33.6343 4 33.5546 4.02941 33.5049 4.08824C33.4451 4.14706 33.4153 4.21569 33.4153 4.30392V9.68627C33.4153 9.77451 33.4451 9.85294 33.5049 9.90196C33.5646 9.96078 33.6343 9.9902 33.7239 9.9902H34.8488C34.9384 9.9902 35.018 9.96078 35.0678 9.90196C35.1275 9.84314 35.1574 9.77451 35.1574 9.68627V4.30392C35.1574 4.21569 35.1275 4.14706 35.0678 4.08824C35.008 4.02941 34.9384 4 34.8488 4Z""
                                            fill=""#FEFFFF""></path>
                                        <path
                                            d=""M41.8969 4H40.8118C40.7322 4 40.6625 4.02941 40.5928 4.08824C40.5331 4.14706 40.5032 4.21569 40.5032 4.30392V7.62745C40.5032 7.95098 40.4236 8.19608 40.2643 8.36274C40.105 8.51961 39.896 8.59804 39.6073 8.59804C39.3186 8.59804 39.0896 8.51961 38.9403 8.36274C38.781 8.20588 38.7114 7.95098 38.7114 7.62745V4.30392C38.7114 4.21569 38.6815 4.14706 38.6218 4.08824C38.562 4.02941 38.4923 4 38.4028 4H37.3276C37.238 4 37.1584 4.02941 37.1086 4.08824C37.0489 4.14706 37.019 4.21569 37.019 4.30392V7.63725C37.019 8.16667 37.1285 8.61765 37.3376 8.97059C37.5566 9.31373 37.8652 9.57843 38.2534 9.7549C38.6417 9.92157 39.0996 10 39.6172 10C40.1349 10 40.5928 9.92157 40.981 9.7549C41.3693 9.58824 41.6779 9.32353 41.8969 8.97059C42.1159 8.61765 42.2154 8.16667 42.2154 7.63725V4.30392C42.2154 4.21569 42.1856 4.13725 42.1159 4.08824C42.0561 4.02941 41.9865 4 41.9068 4H41.8969Z""
                                            fill=""#FEFFFF""></path>
                                        <path
                                            d=""M49.9005 4.08824C49.8407 4.02941 49.771 4 49.6815 4H48.7855C48.6561 4 48.5665 4.03922 48.5068 4.10784C48.457 4.15686 48.4272 4.19608 48.4072 4.23529L47.0235 6.69608L45.6398 4.2451C45.6398 4.2451 45.5801 4.15686 45.5303 4.10784C45.4706 4.03922 45.371 4 45.2516 4H44.3457C44.2661 4 44.1864 4.02941 44.1267 4.08824C44.067 4.14706 44.0371 4.21569 44.0371 4.30392V9.68627C44.0371 9.77451 44.067 9.85294 44.1267 9.91177C44.1864 9.97059 44.2661 9.9902 44.3457 9.9902H45.3511C45.4407 9.9902 45.5204 9.96078 45.5701 9.90196C45.6299 9.84314 45.6597 9.77451 45.6597 9.68627V6.97059L46.4163 8.36274C46.4462 8.42157 46.4959 8.48039 46.5457 8.51961C46.6054 8.57843 46.695 8.59804 46.7946 8.59804H47.2326C47.3321 8.59804 47.4217 8.56863 47.4815 8.51961C47.5412 8.47059 47.581 8.41176 47.6009 8.36274L48.3575 6.97059V9.68627C48.3575 9.77451 48.3873 9.85294 48.4471 9.91177C48.5068 9.97059 48.5864 9.9902 48.676 9.9902H49.6715C49.7611 9.9902 49.8407 9.96078 49.8905 9.91177C49.9602 9.85294 49.99 9.77451 49.99 9.68627V4.30392C49.99 4.21569 49.9602 4.13725 49.8905 4.08824H49.9005Z""
                                            fill=""#FEFFFF""></path>
                                    </g>
                                    <defs>
                                        <clipPath id=""clip0_3541_3928"">
                                            <rect width=""44"" height=""6"" fill=""white"" transform=""translate(6 4)""></rect>
                                        </clipPath>
                                    </defs>
                                </svg>
                            </i>
                    ";
                }
                string img = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail);
                res += string.Format(@"
                        <div class=""select-item"">
                            <div class=""checkbox-wrapper""><label class=""checkbox""><input type=""checkbox""></label></div>
                            <div class=""list-item bor-b-1 media-item hide-right is-vip"">
                                <div class=""media"">
                                    <div class=""media-left"">
                                        <div class=""song-prefix mar-r-15""><i class=""icon ic-song""></i></div>
                                        <div class=""song-thumb"">
                                            <figure class=""image is-40x40"" title=""{2}"">
                                                <img src=""{0}"" alt="""">
                                            </figure>
                                            <div class=""opacity ""></div>
                                            <div class=""zm-actions-container"">
                                                <div class=""zm-box zm-actions"">
                                                    <button class=""zm-btn zm-tooltip-btn animation-like is-hidden active is-hover-circle button""
                                                        tabindex=""0"">
                                                        <i class=""icon ic-like""></i><i class=""icon ic-like-full""></i>
                                                    </button><button class=""zm-btn action-play  button"" tabindex=""0"">
                                                        <i class=""icon action-play ic-play""></i>
                                                    </button><button class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button""
                                                        tabindex=""0"">
                                                        <i class=""icon ic-more""></i>
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class=""card-info"">
                                            <div class=""title-wrapper"">
                                                <span class=""item-title has-icon title"">
                                                    <span>
                                                        <span><span>{2}</span></span><span
                                                            style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span>
                                                    </span>
                                                    {1}
                                                </span>
                                            </div>
                                            <h3 class=""is-one-line is-truncate subtitle"">
                                                {3}
                                            </h3>
                                        </div>
                                    </div>
                                    <div class=""media-content"">
                                        <div>{4}</div>
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
                                                    <button class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                                        tabindex=""0"">
                                                        <i class=""icon ic-like""></i><i class=""icon ic-like-full""></i>
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
                                                    <button class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                                        tabindex=""0"">
                                                        <i class=""icon ic-like""></i><i class=""icon ic-like-full""></i>
                                                    </button>
                                                </div>
                                                <div class=""level-item duration"">{5}</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                ", img, premium, song.title, song.GetHtmlArtist(), HelperUtility.getBetweenDate(song.ReleaseDate()), song.Duration());
            }
            return res;
        }

        public static string GeneratePlaylists(List<PlaylistDTO> playlists, bool classColumn = false)
        {
            StringBuilder str = new StringBuilder();
            foreach (var playlist in playlists)
            {
                str.Append(GeneratePlaylist(playlist, classColumn));
            }
            return str.ToString();
        }
        public static string GeneratePlaylist(PlaylistDTO playlist, bool classColumn = false)
        {
            StringBuilder str = new StringBuilder();
            string img = DataHelper.GetThumbnailPlaylist(playlist);
            string column = string.Empty;
            if(classColumn)
            {
                column = " column mar-b-30 ";
            }
            str.AppendFormat(@"
                    <div class=""zm-carousel-item is-fullhd-20 is-widescreen-20 is-desktop-3 is-touch-3 is-tablet-3 {4}"">
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
                                    <h4 class=""title is-6""><a class="""" title=""xin đừng lặng im"" href=""{1}""><span><span><span>{0}</span></span><span style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></a></h4>
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
                ", playlist.title, $"/Album?encodeId={playlist.encodeId}", img, GenerateArtistLink(playlist.artists), column);
            return str.ToString(); 
        }

        public static string GenerateArtistInfo(ArtistDTO artist)
        {
            StringBuilder str = new StringBuilder();
            string img = DataHelper.GetThumbnailArtist(artist.id, artist.thumbnail);
            str.AppendFormat(@"
                    <div class=""blur-container"" style=""left: -118px; right: -118px;"">
                        <div class=""blur""
                            style=""background-image: url({0});"">
                        </div>
                        <div class=""bg-alpha""></div>
                    </div>
                    <div class=""container hero-body"">
                        <div class=""left"">
                            <figure class=""image avatar is-48x48""><img
                                    src=""{1}""
                                    alt=""""></figure>
                            <div class=""information"">
                                <div class=""top"">
                                    <h3 class=""artist-name title"" style=""width: fit-content; font-size: 60px;""><span><span><span>{2}</span></span><span
                                                style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></h3>
                                    <button class=""zm-btn play-btn pause is-outlined active is-medium button"" tabindex=""0""><i
                                            class=""icon ic-play""></i></button>
                                </div>
                                <div class=""bottom""><span class=""follow"">{3} người quan tâm</span><span><button
                                            class=""zm-btn is-outlined is-medium follow-btn is-upper button"" tabindex=""0""><i
                                                class=""icon ic-addfriend""></i><span>Quan tâm</span></button></span></div>
                            </div>
                        </div>
                    </div>
                ", img, img, artist.name, string.Format("{0:0,0.#}", artist.totalFollow));
            return str.ToString();
        }
        public static string GenerateArtistNoiBat(ArtistDTO artist, int optionList = 0)
        {
            StringBuilder res = new StringBuilder();
            StringBuilder col_left = new StringBuilder();
            StringBuilder col_right = new StringBuilder();
            string main = @"
                <div class=""column mar-b-0 is-fullhd-6 is-widescreen-6 is-desktop-6 is-touch-6 is-tablet-6"">
                    <div class=""list list-border"">
                        {0}
                    </div>
                </div>        
            ";
            string col = @"
                <div class=""list-item media-item hide-right full-left"">
                    <div class=""media"">
                        <div class=""media-left"">
                            <div class=""song-thumb"">
                                <figure class=""image is-40x40"" title=""{0}""><img
                                        src=""{1}""
                                        alt=""""></figure>
                                <div class=""opacity ""></div>
                                <div class=""zm-actions-container"">
                                    <div class=""zm-box zm-actions""><span class=""is-hidden""><button
                                                class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0""><i
                                                    class=""icon ic-like""></i></button></span><button
                                            class=""zm-btn action-play  button"" tabindex=""0""><i
                                                class=""icon action-play ic-play""></i></button><button
                                            class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0""><i
                                                class=""icon ic-more""></i></button></div>
                                </div>
                            </div>
                            <div class=""card-info"">
                                <div class=""title-wrapper""><span class=""item-title title""><span><span><span>{2}</span></span><span
                                                style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></span>
                                </div>
                                <h3 class=""is-one-line is-truncate subtitle"">{3}</h3>
                            </div>
                        </div>
                        <div class=""media-right"">
                            <div class=""hover-items"">
                                <div class=""level"">
                                    <div class=""level-item""><button class=""zm-btn zm-tooltip-btn is-hover-circle button""
                                            tabindex=""0""><i class=""icon ic-karaoke""></i></button></div>
                                    <div class=""level-item""><span><button class=""zm-btn zm-tooltip-btn is-hover-circle button""
                                                tabindex=""0""><i class=""icon ic-like""></i></button></span></div>
                                    <div class=""level-item""><button class=""zm-btn zm-tooltip-btn is-hover-circle button""
                                            tabindex=""0""><i class=""icon ic-more""></i></button></div>
                                </div>
                            </div>
                            <div class=""action-items"">
                                <div class=""level"">
                                    <div class=""level-item""><span><button class=""zm-btn zm-tooltip-btn is-hover-circle button""
                                                tabindex=""0""><i class=""icon ic-like""></i></button></span></div>
                                    <div class=""level-item duration"">{4}</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            ";
            string img = DataHelper.GetThumbnailArtist(artist.id, artist.thumbnail);
            SectionDTO secNoiBat = artist.sections.Where(s => s.title.Equals("Bài hát nổi bật")).First();
            List<SongDTO> songs = DataHelper.GetSongs(secNoiBat);

            for (int i = 0; i < 3 && i < songs.Count; i++)
            {
                SongDTO song = songs[i];
                string imgSong = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail);
                string betweenDate = HelperUtility.getBetweenDate(song.ReleaseDate());
                string duration = song.Duration();
                col_left.AppendFormat(col, song.title, imgSong, song.title, GenerateArtistLink(song.artists), duration);
            }
            res.AppendFormat(main, col_left.ToString());
            for (int i = 3; i < 6 && i < songs.Count; i++)
            {
                SongDTO song = songs[i];
                string imgSong = DataHelper.GetThumbnailSong(song.encodeId, img);
                int iArt = 0;
                string betweenDate = HelperUtility.getBetweenDate(song.ReleaseDate());
                string duration = song.Duration();
                StringBuilder artistname = new StringBuilder();

                if (song.artists != null)
                {
                    artistname.Append(GenerateArtistLink(song.artists));
                }
                col_right.AppendFormat(col, song.title, imgSong, song.title, artistname.ToString(), duration);
            }
            res.AppendFormat(main, col_right.ToString());
            return res.ToString();
        }
        
        #region Song
        public static string GenerateSongElement(SongDTO song)
        {
            string img = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail);
            string premium = "";
            if(song.streamingStatus == -1)
            {
                premium = @"
                    <i class=""icon""><svg width=""56"" height=""14"" viewBox=""0 0 56 14"" fill=""none""><rect width=""56"" height=""14"" rx=""4"" fill=""#E5AC1A""></rect><g clip-path=""url(#clip0_3541_3928)""><path d=""M9.89231 4.22549C9.54389 4.07843 9.12579 4 8.64796 4H6.3086C6.219 4 6.14932 4.02941 6.08959 4.08824C6.02986 4.14706 6 4.21569 6 4.30392V9.68627C6 9.77451 6.02986 9.85294 6.08959 9.90196C6.14932 9.96078 6.219 9.9902 6.3086 9.9902H7.43348C7.52308 9.9902 7.60271 9.96078 7.65249 9.91177C7.72217 9.85294 7.75204 9.77451 7.75204 9.68627V7.97059H8.64796C9.12579 7.97059 9.53394 7.90196 9.89231 7.76471C10.2507 7.62745 10.5394 7.40196 10.7385 7.11765C10.9475 6.82353 11.0471 6.45098 11.0471 6.0098C11.0471 5.56863 10.9475 5.18627 10.7385 4.88235C10.5394 4.58824 10.2507 4.36275 9.89231 4.21569V4.22549ZM9.29502 6C9.29502 6.21569 9.23529 6.37255 9.11584 6.48039C8.99638 6.58824 8.82715 6.63725 8.6181 6.63725H7.74208V5.35294H8.6181C8.86697 5.35294 9.04615 5.41176 9.1457 5.52941C9.2552 5.65686 9.30498 5.80392 9.30498 6H9.29502Z"" fill=""#FEFFFF""></path><path d=""M16.5818 7.63725C16.8606 7.4902 17.0995 7.29412 17.2787 7.03922C17.4877 6.7549 17.5873 6.40196 17.5873 5.9902C17.5873 5.36275 17.3583 4.86275 16.9203 4.51961C16.4922 4.17647 15.895 4 15.1583 4H12.8787C12.7891 4 12.7194 4.02941 12.6597 4.08824C12.5999 4.14706 12.5701 4.21569 12.5701 4.30392V9.68627C12.5701 9.77451 12.5999 9.85294 12.6597 9.90196C12.7194 9.96078 12.7891 9.9902 12.8787 9.9902H13.9538C14.0434 9.9902 14.123 9.96078 14.1728 9.90196C14.2325 9.84314 14.2624 9.77451 14.2624 9.68627V7.94118H14.9592L15.885 9.70588C15.9149 9.7549 15.9547 9.81373 16.0144 9.88235C16.0841 9.95098 16.1836 9.9902 16.323 9.9902H17.428C17.5076 9.9902 17.5674 9.96078 17.6271 9.91177C17.6868 9.85294 17.7167 9.78431 17.7167 9.71569C17.7167 9.67647 17.7067 9.62745 17.6769 9.57843L16.5719 7.62745L16.5818 7.63725ZM15.8352 5.97059C15.8352 6.16667 15.7755 6.31373 15.666 6.42157C15.5565 6.52941 15.3873 6.58824 15.1483 6.58824H14.2823V5.35294H15.1483C15.3873 5.35294 15.5664 5.41176 15.666 5.51961C15.7755 5.63725 15.8352 5.78431 15.8352 5.97059Z"" fill=""#FEFFFF""></path><path d=""M23.5801 8.60784H20.9421V7.64706H23.3312C23.4208 7.64706 23.5005 7.61765 23.5602 7.55882C23.6199 7.5 23.6398 7.42157 23.6398 7.34314V6.61765C23.6398 6.52941 23.61 6.46078 23.5602 6.40196C23.5005 6.33333 23.4208 6.30392 23.3312 6.30392H20.9421V5.38235H23.5104C23.6 5.38235 23.6697 5.35294 23.7294 5.29412C23.7892 5.23529 23.819 5.16667 23.819 5.07843V4.30392C23.819 4.21569 23.7892 4.14706 23.7294 4.08824C23.6697 4.02941 23.6 4 23.5104 4H19.6082C19.5186 4 19.4489 4.02941 19.3892 4.08824C19.3294 4.14706 19.2996 4.21569 19.2996 4.30392V9.68627C19.2996 9.77451 19.3294 9.85294 19.3892 9.90196C19.4489 9.96078 19.5186 9.9902 19.6082 9.9902H23.5801C23.6697 9.9902 23.7394 9.96078 23.7991 9.90196C23.8588 9.84314 23.8887 9.77451 23.8887 9.68627V8.91177C23.8887 8.82353 23.8588 8.7549 23.7991 8.69608C23.7394 8.63725 23.6697 8.60784 23.5801 8.60784Z"" fill=""#FEFFFF""></path><path d=""M31.2054 4H30.3095C30.19 4 30.0904 4.03922 30.0208 4.10784C29.9809 4.15686 29.9411 4.19608 29.9212 4.23529L28.5375 6.69608L27.1638 4.2451C27.1638 4.2451 27.104 4.15686 27.0542 4.10784C26.9945 4.03922 26.895 4 26.7755 4H25.8696C25.79 4 25.7203 4.02941 25.6506 4.08824C25.5909 4.14706 25.561 4.21569 25.561 4.30392V9.68627C25.561 9.77451 25.5909 9.85294 25.6506 9.91177C25.7104 9.97059 25.79 9.9902 25.8696 9.9902H26.8751C26.9647 9.9902 27.0443 9.96078 27.0941 9.90196C27.1538 9.84314 27.1837 9.77451 27.1837 9.68627V6.97059L27.9402 8.36274C27.9701 8.42157 28.0199 8.48039 28.0696 8.51961C28.1294 8.57843 28.219 8.59804 28.3185 8.59804H28.7565C28.8561 8.59804 28.9457 8.56863 29.0054 8.51961C29.0651 8.47059 29.1049 8.41176 29.1248 8.36274L29.8814 6.97059V9.68627C29.8814 9.77451 29.9113 9.85294 29.971 9.91177C30.0307 9.97059 30.1104 9.9902 30.1999 9.9902H31.1954C31.285 9.9902 31.3647 9.96078 31.4144 9.91177C31.4841 9.85294 31.514 9.77451 31.514 9.68627V4.30392C31.514 4.21569 31.4841 4.13725 31.4144 4.08824C31.3547 4.02941 31.285 4 31.1954 4H31.2054Z"" fill=""#FEFFFF""></path><path d=""M34.8488 4H33.7239C33.6343 4 33.5546 4.02941 33.5049 4.08824C33.4451 4.14706 33.4153 4.21569 33.4153 4.30392V9.68627C33.4153 9.77451 33.4451 9.85294 33.5049 9.90196C33.5646 9.96078 33.6343 9.9902 33.7239 9.9902H34.8488C34.9384 9.9902 35.018 9.96078 35.0678 9.90196C35.1275 9.84314 35.1574 9.77451 35.1574 9.68627V4.30392C35.1574 4.21569 35.1275 4.14706 35.0678 4.08824C35.008 4.02941 34.9384 4 34.8488 4Z"" fill=""#FEFFFF""></path><path d=""M41.8969 4H40.8118C40.7322 4 40.6625 4.02941 40.5928 4.08824C40.5331 4.14706 40.5032 4.21569 40.5032 4.30392V7.62745C40.5032 7.95098 40.4236 8.19608 40.2643 8.36274C40.105 8.51961 39.896 8.59804 39.6073 8.59804C39.3186 8.59804 39.0896 8.51961 38.9403 8.36274C38.781 8.20588 38.7114 7.95098 38.7114 7.62745V4.30392C38.7114 4.21569 38.6815 4.14706 38.6218 4.08824C38.562 4.02941 38.4923 4 38.4028 4H37.3276C37.238 4 37.1584 4.02941 37.1086 4.08824C37.0489 4.14706 37.019 4.21569 37.019 4.30392V7.63725C37.019 8.16667 37.1285 8.61765 37.3376 8.97059C37.5566 9.31373 37.8652 9.57843 38.2534 9.7549C38.6417 9.92157 39.0996 10 39.6172 10C40.1349 10 40.5928 9.92157 40.981 9.7549C41.3693 9.58824 41.6779 9.32353 41.8969 8.97059C42.1159 8.61765 42.2154 8.16667 42.2154 7.63725V4.30392C42.2154 4.21569 42.1856 4.13725 42.1159 4.08824C42.0561 4.02941 41.9865 4 41.9068 4H41.8969Z"" fill=""#FEFFFF""></path><path d=""M49.9005 4.08824C49.8407 4.02941 49.771 4 49.6815 4H48.7855C48.6561 4 48.5665 4.03922 48.5068 4.10784C48.457 4.15686 48.4272 4.19608 48.4072 4.23529L47.0235 6.69608L45.6398 4.2451C45.6398 4.2451 45.5801 4.15686 45.5303 4.10784C45.4706 4.03922 45.371 4 45.2516 4H44.3457C44.2661 4 44.1864 4.02941 44.1267 4.08824C44.067 4.14706 44.0371 4.21569 44.0371 4.30392V9.68627C44.0371 9.77451 44.067 9.85294 44.1267 9.91177C44.1864 9.97059 44.2661 9.9902 44.3457 9.9902H45.3511C45.4407 9.9902 45.5204 9.96078 45.5701 9.90196C45.6299 9.84314 45.6597 9.77451 45.6597 9.68627V6.97059L46.4163 8.36274C46.4462 8.42157 46.4959 8.48039 46.5457 8.51961C46.6054 8.57843 46.695 8.59804 46.7946 8.59804H47.2326C47.3321 8.59804 47.4217 8.56863 47.4815 8.51961C47.5412 8.47059 47.581 8.41176 47.6009 8.36274L48.3575 6.97059V9.68627C48.3575 9.77451 48.3873 9.85294 48.4471 9.91177C48.5068 9.97059 48.5864 9.9902 48.676 9.9902H49.6715C49.7611 9.9902 49.8407 9.96078 49.8905 9.91177C49.9602 9.85294 49.99 9.77451 49.99 9.68627V4.30392C49.99 4.21569 49.9602 4.13725 49.8905 4.08824H49.9005Z"" fill=""#FEFFFF""></path></g><defs><clipPath id=""clip0_3541_3928""><rect width=""44"" height=""6"" fill=""white"" transform=""translate(6 4)""></rect></clipPath></defs></svg></i>
                ";
            }
            string format = @"
                <div class=""select-item {7}"" data-id=""{5}"">
                    <div class=""checkbox-wrapper"">
                        <label class=""checkbox""><input type=""checkbox"" /></label>
                    </div>
                    <div class=""list-item bor-b-1 media-item hide-right"">
                        <div class=""media"">
                            <div class=""media-left"">
                                <div class=""song-prefix mar-r-10""><i class=""icon ic-song""></i></div>
                                <div class=""song-thumb"">
                                    <figure class=""image is-40x40"" title=""{0}"">
                                        <img src=""{1}"" alt="""" />
                                    </figure>
                                    <div class=""opacity""></div>
                                    <div class=""zm-actions-container"">
                                        <div class=""zm-box zm-actions"">
                                            <button class=""zm-btn zm-tooltip-btn animation-like is-hidden active is-hover-circle button""
                                                tabindex=""0"">
                                                <i class=""icon ic-like""></i><i class=""icon ic-like-full""></i></button><button
                                                class=""zm-btn action-play button"" tabindex=""0"">
                                                <i class=""icon action-play ic-play""></i></button><button
                                                class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0"">
                                                <i class=""icon ic-more""></i>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                                <div class=""card-info"">
                                    <div class=""title-wrapper"">
                                        <span class=""item-title title""><span><span><span>{0}</span></span><span style=""
                                    position: fixed;
                                    visibility: hidden;
                                    top: 0px;
                                    left: 0px;
                                  "">…</span></span>
                                            {6}
                                        </span>
                                    </div>
                                    <h3 class=""is-one-line is-truncate subtitle"">
                                        {2}
                                    </h3>
                                </div>
                            </div>
                            <div class=""media-content"">
                                <div class=""album-info"">{3}</div>
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
                                            <button class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                                tabindex=""0"">
                                                <i class=""icon ic-like""></i><i class=""icon ic-like-full""></i>
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
                                            <button class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                                tabindex=""0"">
                                                <i class=""icon ic-like""></i><i class=""icon ic-like-full""></i>
                                            </button>
                                        </div>
                                        <div class=""level-item duration"">{4}</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            ";
            return string.Format(format, song.title, img, song.GetHtmlArtist(), song.GetHtmlAlbum(), song.Duration(), song.encodeId, premium, string.IsNullOrEmpty(premium) ? "" : "is-premium");
        }
        #endregion

        #region Playlist
        public static string GenerateAlbumSpecial(PlaylistDTO playlist)
        {
            string img = DataHelper.GetThumbnailPlaylist(playlist);
            string format = @"
                <a class="""" title=""{0}""
                    href=""/Album?encodeId{1}"">
                    <div class=""playlist-wrapper is-normal allow-click"">
                        <div class=""zm-card"">
                            <div class=""zm-card-image"">
                                <figure class=""image is-48x48"">
                                    <img src=""{2}""
                                             alt="">
                                </figure>
                            </div>
                            <div class=""zm-card-content"">
                                <span>Single</span>
                                <h3 class=""title"">
                                    <span>
                                        <span>
                                            {0}
                                        </span>
                                        <span style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span>
                                    </span>
                                </h3><span class=""artist-name"">
                                    <h3 class=""is-one-line is-truncate subtitle"">
                                        {4}
                                    </h3>
                                </span><span>{5}</span>
                            </div>
                        </div>
                    </div>
                </a>
                <div class=""media-blur"">
                    <div class=""cover-bg""
                        style=""background-image: url({2});"">
                    </div>
                    <div class=""gradient-layer""></div>
                    <div class=""blur-layer""></div>
                </div>
            ";
            return string.Format(format, playlist.title, playlist.encodeId, img, GenerateArtistLink(playlist.artists), playlist.ContentLastUpdate());
        }
        public static string GeneratePlaylistElement(PlaylistDTO playlist, bool classColumn = false)
        {
            string img = DataHelper.GetThumbnailPlaylist(playlist);
            string column = string.Empty;
            if (classColumn)
            {
                column = " column mar-b-30 ";
            }
            string format = @"
                <div class=""zm-carousel-item is-fullhd-20 is-widescreen-20 is-desktop-3 is-touch-3 is-tablet-3 {4} "">
                    <div class=""playlist-wrapper is-normal"">
                        <div class=""zm-card"">
                            <div><a class="""" title=""{0}""
                                    href=""/Album?encodeId={1}"">
                                    <div class=""zm-card-image"">
                                        <figure class=""image is-48x48""><img
                                                src=""{2}""
                                                alt=""""></figure>
                                    </div>
                                </a></div>
                            <div class=""zm-card-content"">
                                <h4 class=""title is-6""><a class="""" title=""{1}""
                                        href=""/Album?encodeId={1}""><span><span><span>{0}</span></span><span
                                                style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></a>
                                </h4>
                                <h3 class=""mt-10 subtitle"">{3}</h3>
                            </div>
                        </div>
                    </div>
                </div>
            ";
            return string.Format(format, playlist.title, playlist.encodeId, img, GenerateArtistLink(playlist.artists), column);
        }
        public static string GeneratePlaylistsElement(List<PlaylistDTO> playlists, bool classColumn = false)
        {
            string res = "";
            if(playlists != null && playlists.Count > 0)
            {
                foreach (var item in playlists)
                {
                    res += GeneratePlaylistElement(item, classColumn);
                }
            }
            return res;
        }
        public static string GeneratePlaylistsElement(List<string> playlists, bool classColumn = false)
        {
            string res = "";
            if (playlists != null && playlists.Count > 0)
            {
                foreach (var item in playlists)
                {
                    PlaylistDTO playlist = DataHelper.GetPlaylist(item);
                    if(playlist != null)
                    {
                        res += GeneratePlaylistElement(playlist, classColumn);
                    }
                }
            }
            return res;
        }
        #endregion

        #region Artist
        public static string GenerateArtistItemLink(ArtistDTO artist)
        {
            if(artist != null)
            {
                return $"<a class=\"is-ghost\" href=\"/Artist/Index?id={artist.id}\">{artist.name}</a>";
            }
            return string.Empty;
        }
        public static string GenerateArtistLink(List<ArtistDTO> artists)
        {
            string res = "";
            if (artists != null && artists.Count > 0)
            {
                for (int i = 0; i < artists.Count; i++)
                {
                    ArtistDTO artist = artists[i];
                    if (artist != null)
                    {
                        if (i > 0)
                        {
                            res += ", ";
                        }
                        res += GenerateArtistItemLink(artist);
                    }
                }
            }
            return res;
        }
        public static string GenerateArtistLink(List<string> artists)
        {
            string res = "";
            if (artists != null && artists.Count > 0)
            {
                for (int i = 0; i < artists.Count; i++)
                {
                    ArtistDTO artist = DataHelper.GetArtist(artists[i]);
                    if (artist != null)
                    {
                        if (i > 0)
                        {
                            res += ", ";
                        }
                        res += GenerateArtistItemLink(artist);
                    }
                }
            }
            return res;
        }
        public static string GenerateArtistElement(ArtistDTO artist)
        {
            string img = DataHelper.GetThumbnailArtist(artist.id, artist.thumbnail);
            string format = @"
                <div class=""zm-carousel-item is-fullhd-20 is-widescreen-20 is-desktop-3 is-touch-3 is-tablet-3"">
                    <div class=""zm-card zm-card--artist"">
                        <div class=""image-wrapper"">
                            <div class=""zm-card-image is-rounded""><a class="""" title=""{0}"" href=""/Artist/Index?id={1}"">
                                    <figure class=""image is-48x48""><img
                                            src=""{2}""
                                            alt=""""></figure>
                                    <div class=""opacity ""></div>
                                    <div class=""zm-actions-container"">
                                        <div class=""zm-box zm-actions artist-actions""><span class=""is-hidden""><button
                                                    class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0""><i
                                                        class=""icon ic-like""></i></button></span><button
                                                class=""zm-btn action-play  button"" tabindex=""0""><i
                                                    class=""icon action-play ic-24-Shuffle""></i></button><button
                                                class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0""><i
                                                    class=""icon ic-more""></i></button></div>
                                    </div>
                                </a></div>
                        </div>
                        <div class=""zm-card-content"">
                            <div class=""title"">{3}</div>
                            <div class=""subtitle""><span class=""followers"">{4} quan tâm</span></div>
                        </div>
                        <div class=""zm-card-footer""><span><button class=""zm-btn is-outlined mar-t-15 mar-b-20 is-small is-upper button""
                                    tabindex=""0""><i class=""icon ic-addfriend""></i><span>Quan tâm</span></button></span></div>
                    </div>
                </div>
            ";
            return string.Format(format, artist.name, artist.id, img, GenerateArtistItemLink(artist), HelperUtility.GetCompactNum(artist.totalFollow));
        }
        public static string GenerateArtistsElement(List<ArtistDTO> artists)
        {
            if(artists != null && artists.Count > 0)
            {
                string res = "";
                foreach (ArtistDTO artist in artists)
                {
                    res += GenerateArtistElement(artist);
                }
                return res;
            }
            return string.Empty;
        }
        public static string GenerateArtistsElement(List<string> artists)
        {
            string res = "";
            if (artists != null && artists.Count > 0)
            {
                foreach (string item in artists)
                {
                    ArtistDTO artist = DataHelper.GetArtist(item);
                    if(artist != null)
                    {
                        res += GenerateArtistElement(artist);
                    }
                }
            }
            return res;
        }
        public static string GenerateArtist(List<ArtistDTO> artists, int optionLast = 0)
        {
            StringBuilder str = new StringBuilder();
            foreach (var artist in artists)
            {
                string img = DataHelper.GetThumbnailArtist(artist.id, artist.thumbnail);
                str.AppendFormat(@"
                    <div class=""zm-carousel-item is-fullhd-20 is-widescreen-20 is-desktop-3 is-touch-3 is-tablet-3"">
                        <div class=""playlist-wrapper is-description"">
                            <div class=""zm-card"">
                                <div>
                                    <a class="""" title=""Những Bài Hát Hay Nhất Của {0}""
                                       href=""/Artist/Index?id={1}"">
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
                                                <a class=""is-ghost"" href=""/Artist/Index?id={3}"">{0}</a>
                                            </span>
                                            <span style=""position: fixed; visibility: hidden; top: 0px; left: 0px;""></span>
                                        </span>
                                    </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                ", artist.name, artist.id, img, artist.id);
            }
            return str.ToString();
        }
        #endregion
    }
}
