$(document).ready(function () {
    $('.dot-bg-color').on('click', function () {
        var bg = $(this).css("background-color");
        $(`body,html,
            .sidebar-brand-wrapper,
            .sidebar,
            .navbar-menu-wrapper,
            .navbar .navbar-menu-wrapper .search input`).css({ "background-color": bg });
        if ($(this).hasClass('white')) {
            $('.sidebar-brand-wrapper img').attr("src", '../image/logo_TDT_Devil.png');
            $('.navbar .navbar-menu-wrapper').css({ "-webkit-box-shadow": "20px 19px 34px -15px rgba(0, 0, 0, 0.05)" });
        }
        else {
            $('.sidebar-brand-wrapper img').attr("src", '../image/logo_TDT_Devil-transparent.png');
            $('.navbar .navbar-menu-wrapper').css({ "-webkit-box-shadow": "20px 19px 34px -15px rgba(0, 0, 0, 0.5)" });
        }
    })
});