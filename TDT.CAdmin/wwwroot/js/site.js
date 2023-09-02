function scrollToBottom(e) {
    e.scrollTop(e.prop("scrollHeight"));
}

String.isNullOrEmpty = function (value) {
    return !value || value === undefined || value == "" || value.length == 0;
}

function getColor(strColor) {
    var s = new Option().style;
    s.color = strColor;
    return String.isNullOrEmpty(s.color) ? "" : s.color;
}

function ajaxUpdateViewColor(input) {
    $.ajax({
        type: "POST",
        url: "/api/helper/SetViewColor",
        data: {
            value:input
        }
    });
}