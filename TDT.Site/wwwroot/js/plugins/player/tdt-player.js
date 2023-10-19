//const player = document.querySelector("#tdt-audio");
//const musicName = document.querySelector(".tdt-track-name");
//const playPauseButton = document.querySelector(".tdt-play");
//const prevButton = document.querySelector(".tdt-previous");
//const nextButton = document.querySelector(".tdt-next");
//const currentTime = document.querySelector(".tdt-current-time");
//const duration = document.querySelector(".tdt-duration");
//const progressBar = document.querySelector(".tdt-seek-bar");
//const progress = document.querySelector(".tdt-play-bar");
//const sound = document.querySelector('.knob-wrapper');

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
const info_imgsong = document.querySelector(".player-controls__container .thumbnail img");
const info_nameSong = document.querySelector(".player-controls__container .media-content .item-title");
const info_nameArtist = document.querySelector(".player-controls__container .media-content .subtitle");

//import songs from "./songs.js";
var songs = [
    {
        imgSong: "https://photo-resize-zmp3.zmdcdn.me/w240_r1x1_jpeg/cover/8/6/7/d/867dea78919c4ad9e000d1385c9042ab.jpg",
        src: "https://a320-zmp3.zmdcdn.me/75f292979e4c0f21ad76300554ce758f?authen=exp=1697385026~acl=/75f292979e4c0f21ad76300554ce758f/*~hmac=745322e13a21876f1e372c36bcc4c243",
        nameSong: "Quả Phụ Tướng",
        nameArtist: `<a class="is-ghost" href="/nghe-si/Dunghoangpham">Dunghoangpham</a>`
    },
    {
        imgSong: "https://photo-resize-zmp3.zmdcdn.me/w240_r1x1_jpeg/cover/b/f/0/1/bf0182328238f2a252496a63e51f1f74.jpg",
        src: "https://a320-zmp3.zmdcdn.me/49e28a31e7fee3089127f25498cad799?authen=exp=1697428532~acl=/49e28a31e7fee3089127f25498cad799/*~hmac=4b5832177189fc2af1f5eb7b1d8e8c16",
        nameSong: "Cắt Đôi Nỗi Sầu",
        nameArtist: `<a class="is-ghost" href="/Tang-Duy-Tan">Tăng Duy Tân</a>, <a class="is-ghost" href="/nghe-si/Drum7">Drum7</a>`
    },
    {
        imgSong: "https://photo-resize-zmp3.zmdcdn.me/w240_r1x1_jpeg/cover/6/d/9/6/6d961b2a82f151a0f9af7de928e8f809.jpg",
        src: "https://a320-zmp3.zmdcdn.me/eff67a9cd162f5ef8789d7b36c350185?authen=exp=1697428650~acl=/eff67a9cd162f5ef8789d7b36c350185/*~hmac=71908200854e3de0c6472098662c110a",
        nameSong: "À Lôi",
        nameArtist: `<a class="is-ghost" href="/nghe-si/Double2T">Double2T</a>, <a class="is-ghost" href="/Masew">Masew</a>`
    }
];
let index = 0;
var isInit = false;
var isShuffle = false;
var isRepeat = false;
var isRepeatOne = false;

var mouse_down = false;
var down_newTime = 0;

prevButton.onclick = () => changeMusic("prev");
nextButton.onclick = () => changeMusic();

shuffleButton.onclick = function() {
    if (this.classList.contains('is-active')) {
        this.classList.remove('is-active');
        isShuffle = false;
    }
    else {
        this.classList.add('is-active');
        isShuffle = true;
    }
};

repeateButton.onclick = function () {
    if (!this.classList.contains('is-active')) {
        this.classList.add('is-active');
        isRepeat = true;
        isRepeatOne = false;
        this.innerHTML = icon_repeat;
    }
    else {
        if (this.querySelector('i').classList.contains('ic-repeat')) {
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
};

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

    console.log(mouse_down);
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
        console.log(down_newTime);
        moving = true;
    }
}).mouseup(function () {
    progress.onmousemove = function () { };
    player.currentTime = down_newTime;
    console.log($(this), down_newTime);
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
    if (type !== "init") {
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
        
    }
    console.log(index);
    playPauseButton.innerHTML = icon_await;
    player.src = songs[index].src;
    info_imgsong.src = songs[index].imgSong;
    info_nameSong.innerHTML = songs[index].nameSong;
    info_nameArtist.innerHTML = songs[index].nameArtist;
    //musicName.innerHTML = songs[index].name;
    if (type !== "init")
        playPause();
    updateTime();
};
changeMusic("init");

function setIconPlay() {
    if (player.paused) {
        playPauseButton.innerHTML = icon_play;
    }
    else {
        playPauseButton.innerHTML = icon_pause;
    }
}