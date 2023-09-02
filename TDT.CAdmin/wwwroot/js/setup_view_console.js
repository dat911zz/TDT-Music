function appendConsole(c, html) {
    $(c).append(html);
    scrollToBottom($(c));
}

function startSignalR_Clone(c) {
    const connect = new signalR.HubConnectionBuilder().withUrl("/TDTRealtimeCrawlData").build();
    connect.start().then(function () {
        console.log("SignalR connected");
        connect.on("ReceiveRealtimeContent", function (jsonValue) {
            appendWithJson(c, jsonValue);
        });
    }).catch(function (error) {
        showError(c, error.toString());
    });
}

function appendWithJson(element, jsonValue) {
    var res = JSON.parse(jsonValue);
    var color = getColor(res.color);
    appendConsole(element, `<div` + (String.isNullOrEmpty(color) ? `` : ` style="color:${color}" `) + `>` + res.result + `</div>`);
}

function showStart(c) {
    appendConsole(c, `<div style="color:orange; font-weight:bold;"> --------------- Start --------------- </div>`);
}
function showEnd(c) {
    appendConsole(c, `<div style="color:green; font-weight:bold;"> >>>>>>>>>>>>>> End <<<<<<<<<<<<<<< </div>`);
}
function showError(c, strError) {
    appendConsole(c, `<div style="color:red; font-weight:bold;">` + strError + `</div>`);
}