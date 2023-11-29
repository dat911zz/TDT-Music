const headerNoCheck = `
        <div class="sort-wrapper"><div class="zm-dropdown zm-group-dropdown mar-r-10"><div class="zm-dropdown-trigger-btn"><button class="zm-btn button" tabindex="0"><i class="icon ic-24-Sort"></i></button></div><div class="zm-dropdown-content"><div class="zm-dropdown-list-item">Mặc định</div><div class="zm-dropdown-list-item">Tên bài hát (A-Z)</div><div class="zm-dropdown-list-item">Tên ca sĩ (A-Z)</div><div class="zm-dropdown-list-item">Tên Album (A-Z)</div></div></div><div class="column-text">Bài hát</div></div>
    `;
const headerCheck = `
        <div class="actions"><label class="checkbox"><input type="checkbox"></label><button class="zm-btn action-btn add-queue-btn button" tabindex="0"><i class="icon ic-add-play-now"></i><span>Thêm vào danh sách phát</span></button><div id="select-menu-id" class="more-btn-wrapper"><button class="zm-btn action-btn more-btn button" tabindex="0"><i class="icon ic-more"></i></button></div></div>
    `;
const icon_await = `
    <i class="icon">
        <svg class="lds-spinner" width="40px" height="40px" fill="#f1f1f1" viewBox="0 0 100 100"
            preserveAspectRatio="xMidYMid" style="background: none;">
            <g transform="rotate(0 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.9166666666666666s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(30 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.8333333333333334s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(60 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.75s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(90 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.6666666666666666s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(120 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.5833333333333334s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(150 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.5s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(180 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.4166666666666667s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(210 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.3333333333333333s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(240 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.25s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(270 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.16666666666666666s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(300 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="-0.08333333333333333s"
                        repeatCount="indefinite"></animate>
                </rect>
            </g>
            <g transform="rotate(330 50 50)">
                <rect x="47" y="24" rx="3.7600000000000002" ry="1.92" width="6" height="12">
                    <animate attributeName="opacity" values="1;0" keyTimes="0;1" dur="1s" begin="0s"
                        repeatCount="indefinite">
                    </animate>
                </rect>
            </g>
        </svg>
    </i>
`;
const icon_play = `<i class="icon ic-play-circle-outline"></i>`;
const icon_pause = `<i class="icon ic-pause-circle-outline"></i>`;
const icon_action_play = `<i class="icon action-play ic-play"></i>`;
const icon_action_gif = `<i class="icon action-play ic-gif-playing-white"></i>`;
const icon_repeat = `<i class="icon ic-repeat"></i>`;
const icon_repeatone = `<i class="icon ic-repeat-one"></i>`;
const menu_option_stack = `
                            <div class="menu menu-settings right">
                                <ul class="menu-list">
                                    <li><button class="zm-btn button" tabindex="0"><i class="icon ic-delete"></i><span>Xóa danh sách
                                                phát</span></button></li>
                                    <li>
                                        <div class="menu-list--submenu"><button class="zm-btn button" tabindex="0"><i
                                                    class="icon ic-16-Add"></i><span>Thêm vào playlist</span><i
                                                    class="icon ic-go-right"></i></button></div>
                                    </li>
                                </ul>
                            </div>
                            `;

const player = document.querySelector(".--z--player audio");
const musicName = document.querySelector(".tdt-track-name");
const playPauseButton = document.querySelector(".btn-play");
const prevButton = document.querySelector(".btn-pre");
const nextButton = document.querySelector(".btn-next");
const shuffleButton = document.querySelector(".btn-shuffle");
const repeateButton = document.querySelector(".btn-repeat");
const volumeButton = document.querySelector(".btn-volume");
const currentTime = document.querySelector(".time.left");
const duration = document.querySelector(".time.right");
const progress = document.querySelector(".zm-slider-bar");
const progressHandler = progress.querySelector(".zm-slider-handle");
const sound = document.querySelector('.zm-player-volume .zm-slider-bar');
const soundhandler = document.querySelector('.zm-player-volume .zm-slider-handle');

// info song
const info_urlAlbum = document.querySelector(".player-controls__container .media-left a");
const info_imgsong = document.querySelector(".player-controls__container .thumbnail img");
const info_nameSong = document.querySelector(".player-controls__container .media-content .item-title");
const info_nameArtist = document.querySelector(".player-controls__container .media-content .subtitle");

//import songs from "./songs.js";
var songs = [];
var cur_song = undefined;
var url_stack = undefined;

var isInit = false;
var isShuffle = false;
getIsShuffle()
var isRepeat = false;
getIsRepeat();
var isRepeatOne = false;
getIsRepeatOne();

var mouse_down = false;
var down_newTime = 0;

var noti = false;

prevButton.onclick = () => changeMusic("prev");
nextButton.onclick = () => changeMusic();

shuffleButton.onclick = function() {
    if (isShuffle) {
        isShuffle = false;
    }
    else {
        isShuffle = true;
    }
    setIsShuffle(isShuffle);
    setIconShuffle(isShuffle);
};

function setIconShuffle(check) {
    if (check) {
        shuffleButton.classList.add('is-active');
    }
    else {
        shuffleButton.classList.remove('is-active');
    }
}

repeateButton.onclick = function () {
    if (!isRepeat && !isRepeatOne) {
        this.classList.add('is-active');
        isRepeat = true;
        isRepeatOne = false;
        this.innerHTML = icon_repeat;
    }
    else {
        if (isRepeat) {
            isRepeat = false;
            isRepeatOne = true;
            this.innerHTML = icon_repeatone;
        }
        else {
            this.classList.remove('is-active');
            isRepeat = false;
            isRepeatOne = false;
            this.innerHTML = icon_repeat;
        }
    }
    setIsRepeat(isRepeat);
    setIsRepeatOne(isRepeatOne);
};

function setIconRepeate() {
    if (isRepeat || isRepeatOne) {
        repeateButton.classList.add('is-active');
        if (isRepeatOne) {
            repeateButton.innerHTML = icon_repeatone;
        }
    }
}

function hideStack() {
    if ($('.now-playing-bar > .player-queue').length > 0) {
        $('.now-playing-bar > .player-queue').removeClass('player-queue-animation-enter-done').addClass('player-queue-animation-exit player-queue-animation-exit-active');
        sleep(500).then(() => {
            $('.now-playing-bar > .player-queue').remove();
        });
    }
}
function start() {
    changeMusic("init");
    setUrlStack();
    getCurTime();
    sleep(1000).then(() => {
        getIsPlaying();
    });
    sleep(1000).then(() => {
        changeIconActionPlay();
    });
    $('.queue-expand-button').click(function () {
        if ($(this).hasClass('active')) {
            $('header').removeClass('collapsed');
            $('.zm-mainpage').removeClass('collapsed');
            $(this).removeClass('active');
            hideStack();
        }
        else {
            $(this).addClass('active');
            changeStack(function () {
                sleep(250).then(() => {
                    $('header').addClass('collapsed');
                    $('.zm-mainpage').addClass('collapsed');
                });
                sleep(1500).then(() => {
                    $('#queue_menu').click(function (e) {
                        e.stopPropagation();
                        if ($(this).find('.menu-settings').length > 0) {
                            $(this).find('.menu-settings').remove();
                        }
                        else {
                            $(this).find('button').after(menu_option_stack);
                            $(this).find('.menu-settings .menu-list li:eq(0)').click(function () {
                                $.ajax({
                                    url: "/Player/ClearStack",
                                    success: function () {
                                        showPlayer(false);
                                    }
                                });
                            });
                        }
                    });
                    $('.player-queue__header .tab-bars .level-left .level-item').each(function (i, item) {
                        $(item).click(function () {
                            $(this).addClass('is-active');
                            $(this).siblings().removeClass('is-active');
                            changeStack();
                        });
                    });
                });
            });
            
        }
    });
}

function changeStack(callback = null) {
    if (callback == null) {
        callback = function () { };
    }
    if ($('.queue-expand-button').hasClass('active')) {
        if ($('.player-queue__header .tab-bars .level-left .level-item:eq(0).is-active').length > 0 || $('.player-queue').length <= 0) {
            if ($('.now-playing-bar > .player-queue').length > 0) {
                $.ajax({
                    url: "/Player/GetHtmlChangeStack",
                    success: function (data) {
                        $('.player-queue__scroll').replaceWith(data);
                        changeIconActionPlay();
                        $('#queue-scroll').scrollTop($('#queue-scroll div[data-index] .media').not('.is-pre').eq(0).position().top - 116);
                        setEventSongsInStack();
                        callback();
                    }
                });
            }
            else {
                $.ajax({
                    url: "/Player/GetHtmlStack",
                    success: function (data) {
                        $('.now-playing-bar > .player-controls').before(data);
                        sleep(100).then(() => {
                            $('.player-queue').removeClass('player-queue-animation-exit player-queue-animation-exit-active').addClass('player-queue-animation-enter player-queue-animation-enter-active');
                        });
                        sleep(400).then(() => {
                            $('.now-playing-bar > .player-queue').removeClass('player-queue-animation-enter player-queue-animation-enter-active').addClass('player-queue-animation-enter-done');
                        });
                        changeIconActionPlay();
                        $('#queue-scroll').scrollTop($('#queue-scroll div[data-index] .media').not('.is-pre').eq(0).position().top - 116);
                        setEventSongsInStack();
                        callback();
                    }
                });
            }
        }
        else {
            $.ajax({
                url: "/Player/GetHtmlHistory",
                success: function (data) {
                    $('.player-queue__scroll').replaceWith(data);
                    setEventSongsInStack(true);
                    callback();
                }
            });
        }
    }
}

function setEventSongsInStack(isHistory = false) {
    $('.queue-item-pinned > .list-item button.action-play').click(function () {
        $(playPauseButton).trigger('click');
    });
    $('.player-queue__list > div[data-index] button.action-play').each(function (i, item) {
        $(item).click(function () {
            playPauseButton.innerHTML = icon_await;
            var parent = $(this).parents('div[data-index]');
            iSongStart = parseInt(parent.attr("data-index"));
            idSongStart = parent.attr("data-id");
            noti = true;
            $.ajax({
                type: "POST",
                url: "/Player/ChoosePlayer",
                data: {
                    index: iSongStart,
                    id: idSongStart,
                    isHistory: isHistory
                },
                success: function () {
                    changeMusic("cur");
                }
            });
        });
    });
}

playPauseButton.onclick = () => playPause();

const playPause = () => {
    if (!isInit) {
        isInit = true;
    }
    if (player.paused) {
        player.play().catch(err => { });
        playPauseButton.innerHTML = icon_pause; 
        setIsPlaying(true);
    } else {
        player.pause();
        setIsPlaying(false);
        playPauseButton.innerHTML = icon_play;
    }
    changeIconActionPlay();
};

player.ontimeupdate = () => updateTime();
player.onended = () => changeMusic();

const updateTime = () => {
    if (playPauseButton.querySelector('.lds-spinner')) {
        //setIconPlay();
        changeIconActionPlay();
    }
    if (!player.paused) {
        setCurTime(player.currentTime);
    }
    const currentMinutes = Math.floor(player.currentTime / 60);
    const currentSeconds = Math.floor(player.currentTime % 60);
    currentTime.textContent = currentMinutes + ":" + formatZero(currentSeconds);

    const durationFormatted = isNaN(player.duration) ? 0 : player.duration;
    const durationMinutes = Math.floor(durationFormatted / 60);
    const durationSeconds = Math.floor(durationFormatted % 60);
    duration.textContent = durationMinutes + ":" + formatZero(durationSeconds);

    const progressWidth = durationFormatted
        ? (player.currentTime / durationFormatted) * 100
        : 0;

    if (!mouse_down) {
        setProgressHandler(progressWidth);
        progress.style.background = "linear-gradient( to right, var(--progressbar-active-bg) 0%, var(--progressbar-active-bg) " + progressWidth + "%, var(--progressbar-player-bg) " + progressWidth + "%, var(--progressbar-player-bg) 100% )";
    }
};

const formatZero = (n) => (n < 10 ? "0" + n : n);

var moving = false;
progress.onclick = (e) => {
    if (!moving) {
        const newTime = (e.offsetX / progress.offsetWidth) * player.duration;
        player.currentTime = newTime;
    }
    else {
        moving = true;
    }
};

$(progress).focusout(function () {
    moving = false;
    progress.onmousemove = function () { }
});

$(progress).mousedown(function (et) {
    mouse_down = true;
    progress.onmousemove = function (e) {
        down_newTime = (e.offsetX / progress.offsetWidth) * player.duration;
        setProgressHandler(e.offsetX, "px");
        progress.style.background = "linear-gradient( to right, var(--progressbar-active-bg) 0%, var(--progressbar-active-bg) " + e.offsetX + "px, var(--progressbar-player-bg) " + e.offsetX + "px, var(--progressbar-player-bg) 100% )";
        moving = true;
    }
}).mouseup(function () {
    progress.onmousemove = function () { };
    player.currentTime = down_newTime;
    mouse_down = false;
});

function setProgressHandler(width, option = "%") {
    //var matrix = new WebKitCSSMatrix(progressHandler.style.transform);
    //var xCurHandlerProgress = matrix.m41;
    //var yCurHandlerProgress = matrix.m42;
    if (option == "%") {
        width = (width / 100) * progress.offsetWidth;
    }
    progressHandler.style.transform = 'translate(' + width + 'px, -3.5px)';
}

function setVolume(volume) {
    if (volume > 1) {
        player.volume = 1;
    } else if (volume <= 0) {
        player.volume = 0;
    } else {
        player.volume = volume;
    }
}

sound.onclick = (e) => {
    var width = 100;
    if (e.offsetX < 60) {
        width = e.offsetX;
    }
    setVolume(width / 100);
    sound.style.background = "linear-gradient( to right, var(--progressbar-active-bg) 0%, var(--progressbar-active-bg) " + width + "%, var(--progressbar-player-bg) " + width + "%, var(--progressbar-player-bg) 100% )";
    soundhandler.style.transform = 'translate(' + ((width / 100) * sound.offsetWidth - 2) + 'px, -3.5px)';
}

volumeButton.onclick = function () {
    if (!this.querySelector("i").classList.contains("ic-volume")) {
        this.innerHTML = `<i class="icon ic-volume"></i>`;
        sound.style.background = "linear-gradient( to right, var(--progressbar-active-bg) 100%, var(--progressbar-active-bg) 100%, var(--progressbar-player-bg) 0%, var(--progressbar-player-bg) 100% )";
        soundhandler.style.transform = 'translate(' + sound.offsetWidth + 'px, -3.5px)';
        player.volume = 1;
    }
    else {
        this.innerHTML = `<i class="icon ic-volume-mute"></i>`;
        sound.style.background = "linear-gradient( to right, var(--progressbar-active-bg) 0%, var(--progressbar-active-bg) 0%, var(--progressbar-player-bg) 0%, var(--progressbar-player-bg) 100% )";
        soundhandler.style.transform = 'translate(0px, -3.5px)';
        player.volume = 0;
    }
};

function importSong(type) {
    if (cur_song != undefined) {
        if (!PlayerShowing) {
            showPlayer();
        }
        if (cur_song.Src == "") {
            if (noti) {
                toastr.warning("Vui lòng nâng cấp Premium để được trải nghiệm");
                noti = false;
            }
            changeMusic("next");
            return;
        }
        else {
            noti = false;
        }
        if ($('.queue-expand-button.active').length > 0) {
            changeStack();
        }
        player.src = cur_song.Src;
        info_imgsong.src = cur_song.Thumbnail;
        info_nameSong.innerHTML = cur_song.Name;
        info_nameArtist.innerHTML = cur_song.Artists;
        info_urlAlbum.href = cur_song.UrlPlaylist;
        changeIconActionPlay();
        if (type !== "init")
            playPause();
        updateTime();
    }
    else {
        showPlayer(false);
    }
}

const changeMusic = (type = "next") => {
    $.ajax({
        type: "POST",
        url: "/Player/ChangeMusic?=" + type,
        data: {
            type: type
        },
        success: function (data) {
            if (data == '') {
                cur_song = undefined;
            }
            else {
                cur_song = JSON.parse(data);
            }
            importSong(type);
        }
    });
};

function setIconPlay() {
    if (player.paused) {
        playPauseButton.innerHTML = icon_play;
    }
    else {
        playPauseButton.innerHTML = icon_pause;
    }
}

var PlayerShowing = false;
function showPlayer(show = true) {
    var layout = $('#root .zm-layout:first');
    var cover = $('.now-playing-bar');
    if (show) {
        layout.addClass("has-player");
        cover.show();
        PlayerShowing = true;
    }
    else {
        setPauseAll();
        hideStack();
        sleep(300).then(() => {
            cover.hide();
            layout.removeClass("has-player");
        });
        PlayerShowing = false;
    }
}
function checkShowPlayer(type = "init") {
    $.ajax({
        url: "/Player/CheckShowPlayer",
        success: function (data) {
            if (data) {
                showPlayer(true);
                changeMusic(type);
            }
            else {
                showPlayer(false);
            }
        }
    });
}

function changeIconActionPlay() {
    var icon = $('.header-thumbnail i.action-play');
    $('.select-item .list-item.active').removeClass('active');
    $('.select-item .list-item i.action-play.ic-gif-playing-white').removeClass('ic-gif-playing-white').addClass('ic-play');
    if (cur_song != undefined) { 
        $('.select-item[data-index=' + cur_song.Index + '][data-id=' + cur_song.Id + '] .list-item').addClass('active');
        let curElement = $('.select-item[data-index=' + cur_song.Index + '][data-id=' + cur_song.Id + ']');
        if (curElement.length > 0) {
            $('#body-scroll').scrollTop(curElement.position().top - 150);
        }
        if (player.paused) {
            playPauseButton.innerHTML = icon_play;
            $('.select-item[data-index=' + cur_song.Index + '][data-id=' + cur_song.Id + '] button.action-play').html(icon_action_play);
            $('.player-queue__container .media.is-active button.action-play').html(icon_action_play);
            if (url_stack == window.location.href) {
                icon.addClass('ic-svg-play-circle').removeClass('ic-gif-playing-white');
                if (!setFirst) {
                    $('button.btn-play-all').html(`<i class="icon ic-play"></i><span>Phát tất cả</span>`);
                }
                else {
                    $('button.btn-play-all').html(`<i class="icon ic-play"></i><span>Tiếp tục phát</span>`);
                }
            }
        }
        else {
            playPauseButton.innerHTML = icon_pause;
            $('.select-item[data-index=' + cur_song.Index + '][data-id=' + cur_song.Id + '] button.action-play').html(icon_action_gif);
            $('.player-queue__container .media.is-active button.action-play').html(icon_action_gif);
            if (url_stack == window.location.href) {
                icon.addClass('ic-gif-playing-white');
                icon.removeClass('ic-svg-play-circle');
                $('button.btn-play-all').html(`<i class="icon ic-pause"></i><span>Tạm dừng</span>`);
            }
        }
    }
}
function setPauseAll() {
    player.pause();
    $('.queue-expand-button').removeClass('active');
    $('.select-item .list-item.active').removeClass('active');
    $('.select-item .list-item i.action-play.ic-gif-playing-white').removeClass('ic-gif-playing-white').addClass('ic-play');
    playPauseButton.innerHTML = icon_play;
    $('.player-queue__container .media.is-active button.action-play').html(icon_action_play);
    $('.header-thumbnail i.action-play').addClass('ic-svg-play-circle').removeClass('ic-gif-playing-white');
    $('button.btn-play-all').html(`<i class="icon ic-play"></i><span>Phát tất cả</span>`);
    setFirst = false;
    iSongStart = null;
    idSongStart = null;
}
function actionButton() {
    if (player.paused) {
        checkShowPlayer("cur");
    }
    else {
        checkShowPlayer();
    }
    changeIconActionPlay();
}

function getCurIndex() {
    $.ajax({
        url: "/Player/GetCurIndex",
        success: function (data) {
            //index = data;
        }
    });
}
function setCurIndex(index) {
    $.ajax({
        type: "POST",
        url: "/Player/SetCurIndex",
        data: {
            index: index
        }
    });
}

function getCurTime() {
    $.ajax({
        url: "/Player/GetCurTime",
        success: function (data) {
            player.currentTime = data;
        }
    });
}
function setCurTime(time) {
    $.ajax({
        type: "POST",
        url: "/Player/SetCurTime",
        data: {
            time: time.toString().replace('.', ',')
        }
    });
}

function getIsShuffle() {
    $.ajax({
        url: "/Player/GetIsShuffle",
        success: function (data) {
            isShuffle = data;
            setIconShuffle(isShuffle);
        }
    });
}
function setIsShuffle(value) {
    $.ajax({
        type: "POST",
        url: "/Player/SetIsShuffle",
        data: {
            value: value
        },
        success: function () {
            changeStack();
        }
    });
}

function getIsRepeat() {
    $.ajax({
        url: "/Player/GetIsRepeat",
        success: function (data) {
            isRepeat = data;
            setIconRepeate();
        }
    });
}
function setIsRepeat(value) {
    $.ajax({
        type: "POST",
        url: "/Player/SetIsRepeat",
        data: {
            value: value
        }
    });
}

function getIsRepeatOne() {
    $.ajax({
        url: "/Player/GetIsRepeatOne",
        success: function (data) {
            isRepeatOne = data;
            setIconRepeate();
        }
    });
}
function setIsRepeatOne(value) {
    $.ajax({
        type: "POST",
        url: "/Player/SetIsRepeatOne",
        data: {
            value: value
        }
    });
}
function getIsPlaying() {
    $.ajax({
        url: "/Player/GetIsPlaying",
        success: function (data) {
            if (data) {
                playPause();
            }
        }
    });
}
function setIsPlaying(value) {
    $.ajax({
        type: "POST",
        url: "/Player/SetIsPlaying",
        data: {
            value: value
        }
    });
}

function setUrlStack() {
    $.ajax({
        url: "/Player/GetCurUrl",
        success: function (data) {
            url_stack = data;
        }
    });
}
function setCurPlaylist() {
    url_stack = window.location.href;
    $.ajax({
        type: "POST",
        url: "/Player/SetCurUrl",
        data: {
            url: url_stack
        }
    });
}

function sortHtmlPlaylist(arrId) {
    $.ajax({
        type: "POST",
        url: "/Player/GetSrc",
        data: {
            list: arrId
        },
        success: function (data) {
            if (data != '') {
                temp = JSON.parse(data);
                $('.playlist-content [data-id]').each(function (index, item) {
                    if ($(item).attr("data-index") == undefined) {
                        $(item).attr("data-index", temp.findIndex(function (itemp) { return itemp.Id == $(item).attr("data-id") }));
                    }
                });
                var objs = $('.playlist-content [data-index]');
                var objArr = Array.from(objs);
                let sorted = objArr.sort((a, b) => {
                    if (parseFloat($(a).attr("data-index")) < parseFloat($(b).attr("data-index"))) return -1;
                    if (parseFloat($(a).attr("data-index")) > parseFloat($(b).attr("data-index"))) return 1;
                    return 0;
                });
                $('#songs').html('');
                $(sorted).each(function (index, item) {
                    $('#songs').append(item);
                });
                setEvent();
                bindEvents();
            }
        }
    });
}

$(document).ready(function () {
    start();
    $(document).click(function () {
        $('#queue_menu .menu-settings').remove();
        hideMenuAddPlaylist();
    });
    $('.player-controls__container .media div, .player-controls__container .level-item, .player-controls__player-bar').click(function (e) {
        e.stopPropagation();
    });
    $('.player-controls__container').click(function () {
        window.location = url_stack;
    });
});

var setFirst = false;
var iSongStart = null;
var idSongStart = null;
var fromStack = null;
var titleStack = null;
$('button.btn-play-all').click(function () {
    if (!setFirst) {
        setFirst = true;
        var arrId = [];
        setCurPlaylist();
        $('div[data-id]').each(function (index, item) {
            arrId.push($(item).data('id'));
        });
        playPauseButton.innerHTML = icon_await;
        $.ajax({
            type: "POST",
            url: "/Player/SetSrc",
            data: {
                list: arrId,
                from: fromStack,
                title: titleStack,
                index: iSongStart,
                id: idSongStart
            },
            success: function () {
                actionButton();
            }
        });
    }
    else {
        $(playPauseButton).trigger('click');
    }
});

function setEvent() {
    $('.select-item button.action-play').each(function (i, item) {
        $(item).click(function () {
            playPauseButton.innerHTML = icon_await;
            var parent = $(item).parents('.select-item');
            iSongStart = parseInt(parent.attr("data-index"));
            idSongStart = parent.attr("data-id");
            if (cur_song != undefined && iSongStart == cur_song.Index && idSongStart == cur_song.Id) {
                $(playPauseButton).trigger('click');
                return;
            }
            noti = true;
            if (!setFirst) {
                $('button.btn-play-all').trigger('click');
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "/Player/ChoosePlayer",
                    data: {
                        index: iSongStart,
                        id: idSongStart
                    },
                    success: function () {
                        changeMusic("cur");
                    }
                });
            }
        });
    });
    $('#songs input[type="checkbox"]').click(function () {
        if ($(this).closest('div.is-premium').length > 0) {
            $(this).prop("checked", false);
            toastr.warning("Vui lòng nâng cấp Premium để được trải nghiệm");
            return;
        }
        var allCheckbox = $('input[type=checkbox]');
        if ($(this).is(':checked')) {
            $(this).parents().closest('.select-item').addClass('is-selected');
        }
        else {
            $(this).parents().closest('.select-item').removeClass('is-selected');
        }
        var isChecked = allCheckbox.is(function () { return $(this).is(':checked'); });
        if (isChecked) {
            $('.song-list-select').addClass('isChecked');
            $('.song-list-select .select-header > .media-left').html(headerCheck);
            bindEvents();
        }
        else {
            $('.song-list-select').removeClass('isChecked');
            $('.song-list-select .select-header > .media-left').html(headerNoCheck);
        }
    });
}

function unbindEvents() {
    $('.select-header .media-left input[type="checkbox"]').unbind();
    $('.add-queue-btn').unbind();
    $('#select-menu-id > .more-btn').unbind();
}

function bindEvents() {
    unbindEvents();
    $('.select-header .media-left input[type="checkbox"]').bind("click", function () {
        var v = false;
        if ($(this).is(':checked')) {
            v = true;
        }
        $('#songs input[type="checkbox"]').each(function (i, item) {
            if ($(this).closest('div.is-premium').length > 0) {
                toastr.warning("Vui lòng nâng cấp Premium để được trải nghiệm");
                return;
            }
            $(item).prop("checked", v);
            if (v) {
                $(item).parents().closest('.select-item').addClass('is-selected');
            }
            else {
                $(item).parents().closest('.select-item').removeClass('is-selected');
                $('.song-list-select').removeClass('isChecked');
                $('.song-list-select .select-header > .media-left').html(headerNoCheck);
            }
        });
    });
    $('.add-queue-btn').bind("click", function () {
        var arrId = Array();
        $('#songs input[type="checkbox"]').each(function (i, item) {
            if ($(item).is(":checked") && $(item).closest('div.is-premium').length == 0) {
                arrId.push($(item).parents('div[data-id]').attr('data-id'));
            }
        });
        $.ajax({
            type: "POST",
            url: "/Player/AddStack",
            data: {
                list: arrId
            },
            success: function (data) {
                clearCheckbox();
                if (data == "0") {
                    toastr.error("Thêm vào danh sách phát thất bại");
                }
                else {
                    toastr.info("Đã thêm " + data + " bài hát vào danh sách phát");
                    changeStack();
                }
            }
        });
    });
    $('#select-menu-id > .more-btn').bind("click", function (e) {
        e.stopPropagation();
        if ($(this).siblings().length > 0) {
            $(this).siblings().remove();
        }
        else {
            $(this).after(`
                <div class="zm-contextmenu select-menu">
                    <div>
                        <div class="menu">
                            <ul class="menu-list">
                                <li>
                                    <div class="menu-list--submenu"><button class="zm-btn button" tabindex="0"><i
                                                class="icon ic-16-Add"></i><span>Thêm vào playlist</span><i
                                                class="icon ic-go-right"></i></button></div>
                                </li>
                                <li></li>
                            </ul>
                        </div>
                    </div>
                </div>
            `);
            $(this).closest('#select-menu-id').find('.select-menu .menu-list li:eq(0)').hover(function () {
                showMenuUserPlaylist($(this));
            }, () => { });
            $(this).closest('#select-menu-id').find('.select-menu .menu-list li:eq(0)').click(function (e) {
                e.stopPropagation();
                showMenuUserPlaylist($(this), () => { window.location.href = '/Auth/Index?urlCallback=' + window.location.href; });
            });
        }
    });
}
function clearCheckbox() {
    $('#songs input[type="checkbox"]').prop("checked", false).parents().closest('.select-item').removeClass('is-selected');
    $('.song-list-select').removeClass('isChecked');
    $('.song-list-select .select-header > .media-left').html(headerNoCheck);
}
function showMenuUserPlaylist(objTrigger, callback = null) {
    $.ajax({
        url: "/User/GetHtmlMenuUserPlaylist",
        success: function (data) {
            if (data != '') {
                $('#select-menu-id .add-playlist-content').remove();
                $(objTrigger).find('button').after(data);
                $('.add-playlist-content').hover(function (e) {
                    e.stopPropagation();
                });
                $('.add-playlist-content .playlist-container ul.menu-list li button').click(function () {
                    var arrId = Array();
                    var idPlaylistUser = $(this).attr('data-id');
                    $('#songs input[type="checkbox"]').each(function (i, item) {
                        if ($(item).is(":checked") && $(item).closest('div.is-premium').length == 0) {
                            arrId.push($(item).parents('div[data-id]').attr('data-id'));
                        }
                    });
                    $.ajax({
                        type: "POST",
                        url: "/User/AddSongToPlaylist",
                        data: {
                            idPlaylist: idPlaylistUser,
                            list: arrId
                        },
                        success: function (data) {
                            clearCheckbox();
                            if (data.type == 'error') {
                                toastr.error(data.msg);
                            }
                            else if (data.type == 'success') {
                                toastr.success(data.msg);
                                showUserPlaylist();
                            }
                            else {
                                toastr.info(data.msg);
                            }
                        }
                    });
                });
                $('#select-menu-id .add-playlist-content').click(function (e) {
                    e.stopPropagation();
                });
                $('#select-menu-id .add-playlist-content ul.menu-list li:eq(1)').click(function () {
                    showAddPlaylist();
                    showMenuUserPlaylist(objTrigger);
                });
            }
            else if(callback != null) {
                callback();
            }
        }
    });
}
function hideMenuAddPlaylist() {
    $('#select-menu-id .select-menu').remove();
}