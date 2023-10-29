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
const icon_repeat = `<i class="icon ic-repeat"></i>`;
const icon_repeatone = `<i class="icon ic-repeat-one"></i>`;

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
let index = 0;
getCurIndex();
var isInit = false;
var isShuffle = false;
getIsShuffle()
var isRepeat = false;
getIsRepeat();
var isRepeatOne = false;
getIsRepeatOne();

var mouse_down = false;
var down_newTime = 0;

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

function start() {
    changeMusic("init");
}

playPauseButton.onclick = () => playPause();

const playPause = () => {
    if (!isInit) {
        isInit = true;
    }
    if (player.paused) {
        player.play();
        playPauseButton.innerHTML = icon_pause;        
    } else {
        player.pause();
        playPauseButton.innerHTML = icon_play;
    }
    changeIconActionPlay();
};

player.ontimeupdate = () => updateTime();
player.onended = () => changeMusic();

const updateTime = () => {
    if (playPauseButton.querySelector('.lds-spinner')) {
        setIconPlay();
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


const changeMusic = (type = "next") => {
    if (type !== "init" && type !== "cur") {
        if (isRepeatOne) {
            index = index;
        }
        else if (isShuffle) {
            var cur = index;
            while (cur == index) {
                cur = Math.floor(Math.random() * songs.length);
            }
            index = cur;
        }
        else if (type == "next") {
            if (index + 1 == songs.length) {
                if (isRepeat) {
                    index = 0;
                }
                else {
                    player.pause();
                    setIconPlay();
                }
            }
            else {
                index += 1;
            }
        }
        else if (type == "prev") {
            if (index - 1 < 0) {
                if (isRepeat) {
                    index = songs.length - 1;
                }
                else {
                    player.pause();
                    setIconPlay();
                }
            }
            else {
                index -= 1;
            }
        }
        setCurIndex(index);
    }
    playPauseButton.innerHTML = icon_await;
    if (index == undefined) {
        index = 0;
    }
    if (index < songs.length) {
        if (songs[index].Src == "") {
            changeMusic("next");
            return;
        }
        player.src = songs[index].Src;
        info_imgsong.src = songs[index].Thumbnail;
        info_nameSong.innerHTML = songs[index].Name;
        info_nameArtist.innerHTML = songs[index].Artists;
        info_urlAlbum.href = songs[index].UrlPlaylist;
    }
    //musicName.innerHTML = songs[index].name;
    if (type !== "init")
        playPause();
    updateTime();
};

function setIconPlay() {
    if (player.paused) {
        playPauseButton.innerHTML = icon_play;
    }
    else {
        playPauseButton.innerHTML = icon_pause;
    }
}

function checkShowPlayer(type = "init") {
    var layout = $('#root .zm-layout:first');
    var cover = $('.now-playing-bar');
    $.ajax({
        url: "/Player/CheckShowPlayer",
        success: function (data) {
            if (data) {
                layout.addClass("has-player");
                cover.show();
                $.ajax({
                    url: "/Player/GetSrc",
                    success: function (data) {
                        if (data != '') {
                            songs = [];
                            songs = JSON.parse(data);
                            changeMusic(type);
                        }
                    }
                });
            }
            else {
                cover.hide();
            }
        }
    });
}
$(document).ready(function () {
    start();
    $('.player-controls__container .media div, .player-controls__container .level-item, .player-controls__player-bar').click(function (e) {
        e.stopPropagation();
    });
    $('.player-controls__container').click(function () {
        redirectPlaylist(); 
    });
});

function changeIconActionPlay() {
    var icon = $('.header-thumbnail i.action-play')
    if (player.paused) {
        icon.addClass('ic-svg-play-circle');
        icon.removeClass('ic-gif-playing-white');
        if (!setFirst) {
            $('button.btn-play-all').html(`<i class="icon ic-play"></i><span>Phát tất cả</span>`);
        }
        else {
            $('button.btn-play-all').html(`<i class="icon ic-play"></i><span>Tiếp tục phát</span>`);
        }
    }
    else {
        icon.addClass('ic-gif-playing-white');
        icon.removeClass('ic-svg-play-circle');
        $('button.btn-play-all').html(`<i class="icon ic-pause"></i><span>Tạm dừng</span>`);
    }
}

var setFirst = false;
$('button.btn-play-all').click(function () {
    if (!setFirst) {
        var arrId = [];
        $('div[data-id]').each(function (index, item) {
            arrId.push($(item).data('id'));
        });
        playPauseButton.innerHTML = icon_await;
        $.ajax({
            type: "POST",
            url: "/Player/SetSrc",
            data: {
                list: arrId
            },
            success: function () {
                actionButton();
            }
        });
        setFirst = true;
        setCurPlaylist();
    }
    else {
        $(playPauseButton).trigger('click');
    }
});

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
            index = data;
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

function redirectPlaylist() {
    $.ajax({
        url: "/Player/GetCurUrl",
        success: function (data) {
            window.location = data;
        }
    });
}
function setCurPlaylist() {
    $.ajax({
        type: "POST",
        url: "/Player/SetCurUrl",
        data: {
            url: window.location.href
        }
    });
}

function getIndexSong(id) {
    return songs.findIndex(function (item) { return item.Id == id })
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
            }
        }
    });
}

function setEvent() {
    $('.select-item button.action-play').each(function (i, item) {
        $(item).click(function () {
            var parent = $(this).parents('.select-item');
            var iParent = parseInt(parent.attr("data-index"));
            console.log(iParent)
            if (songs[iParent].Src == "") {
                SendNotiWarning("Vui lòng nâng cấp Premium để được trải nghiệm");
            }
        });
    })
}