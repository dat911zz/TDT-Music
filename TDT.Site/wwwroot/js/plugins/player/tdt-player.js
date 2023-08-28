const player = document.querySelector("#tdt-audio");
const musicName = document.querySelector(".tdt-track-name");
const playPauseButton = document.querySelector(".tdt-play");
const prevButton = document.querySelector(".tdt-previous");
const nextButton = document.querySelector(".tdt-next");
const currentTime = document.querySelector(".tdt-current-time");
const duration = document.querySelector(".tdt-duration");
const progressBar = document.querySelector(".tdt-seek-bar");
const progress = document.querySelector(".tdt-play-bar");
const sound = document.querySelector('.knob-wrapper');

//import songs from "./songs.js";
var songs = [{
    src: "https://mp3-s1-zmp3.zmdcdn.me/890e3488f4c81d9644d9/6841713295008143453?authen=exp=1691456833~acl=/890e3488f4c81d9644d9/*~hmac=0bf31b1c6463e9206ea18799bba8f283&fs=MTY5MTI4NDAzMzmUsIC3OHx3ZWJWNnwwfDExOC42OC4xMjIdUngMTY5",
    name: "Châu Thịnh làm nè he !!!"
}];

let index = 0;

prevButton.onclick = () => prevNextMusic("prev");
nextButton.onclick = () => prevNextMusic();

playPauseButton.onclick = () => playPause();

const playPause = () => {
    if (player.paused) {
        player.play();
        $('#tdt_container_1').addClass('tdt-state-playing');
    } else {
        player.pause();
        $('#tdt_container_1').removeClass('tdt-state-playing');
    }
};

player.ontimeupdate = () => updateTime();

const updateTime = () => {
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

    progress.style.width = progressWidth + "%";
};

const formatZero = (n) => (n < 10 ? "0" + n : n);

progressBar.onclick = (e) => {
    const newTime = (e.offsetX / progressBar.offsetWidth) * player.duration;
    player.currentTime = newTime;
};

const prevNextMusic = (type = "next") => {
    if ((type == "next" && index + 1 === songs.length) || type === "init") {
        index = 0;
    } else if (type == "prev" && index === 0) {
        index = songs.length;
    } else {
        index = type === "prev" && index ? index - 1 : index + 1;
    }

    player.src = songs[index].src;
    musicName.innerHTML = songs[index].name;
    if (type !== "init") playPause();

    updateTime();
};

function setVolume() {
    var angle1 = getRotationDegrees($('.knob')),
        volume = angle1 / 270

    if (volume > 1) {
        player.volume = 1;
    } else if (volume <= 0) {
        player.volume = 0;
    } else {
        player.volume = volume;
    }
}

sound.onclick = () => {
    setVolume();
}

prevNextMusic("init");

function getRotationDegrees(obj) {
    var matrix = obj.css("-webkit-transform") ||
        obj.css("-moz-transform") ||
        obj.css("-ms-transform") ||
        obj.css("-o-transform") ||
        obj.css("transform");
    if (matrix !== 'none') {
        var values = matrix.split('(')[1].split(')')[0].split(',');
        var a = values[0];
        var b = values[1];
        var angle = Math.round(Math.atan2(b, a) * (180 / Math.PI));
    } else { var angle = 0; }
    return (angle < 0) ? angle + 360 : angle;
}

$('.knob-wrapper').mousedown(function () {
    $(window).mousemove(function (e) {
        setVolume();
    });

    return false;
}).mouseup(function () {
    $(window).unbind("mousemove");
});