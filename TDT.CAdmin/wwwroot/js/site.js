$(document).ready(function () {
    var temp_black = {
        "--bg-temp": "#12151e", "--bg-main-content": "#12151e", "--nav-link-hover": "#0f1015",
        "--navbar-shadow": "20px 19px 34px -15px rgba(0, 0, 0, 0.5)", "--color-separate": "#2c2e33",
        "--color-icon-nav": "#fff", "--color-change": "#fff", "--bg-popup": "#191C24", "--bg-hover": "#0F1015",
        "--border-temp": "1px px solid #2c2e33", "--popup-shadow": "0px 0px 35px -3px black"
    };
    var temp_white = {
        "--bg-temp": "white", "--bg-main-content": "#F0F2F5", "--nav-link-hover": "#0f1015",
        "--navbar-shadow": "4px 0 0px 2px rgba(0 0 0 / 0.03)", "--color-separate": "#eaecf0",
        "--color-icon-nav": "#767676", "--color-change": "#000", "--bg-popup": "#fff", "--bg-hover": "#e5e7eb",
        "--border-temp": "1px solid #efebeb", "--popup-shadow": "0px 0px 35px -3px #eae4e4"
    };
    $('.dot-bg-color').on('click', function () {
        if ($(this).hasClass('white')) {
            $(":root").css(temp_white);
            $('.sidebar-brand-wrapper img').attr("src", '../image/logo_TDT_Devil_red.png');
        }
        else {
            $(":root").css(temp_black);
            $('.sidebar-brand-wrapper img').attr("src", '../image/logo_TDT_Devil-transparent.png');
        }
    })
});