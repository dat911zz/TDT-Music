function scrollToBottom(e) {
    e.scrollTop(e.prop("scrollHeight"));
}

function appendConsole(c, html) {
    $(c).append(html);
    scrollToBottom(c);
}


function startSignalR_Clone(c) {
    const connect = new signalR.HubConnectionBuilder().withUrl("/TDTRealtime").build();
    connect.start().then(function () {
        console.log("SignalR connected");
        connect.on("ReceiveRealtimeContent", function (htmlContent) {
            appendConsole(c, htmlContent);
        });
    }).catch(function (error) {
        appendConsole(c, `<div style="color:red; font-weight:bold;">` + error.toString() + `</div>`);
    });
}

function ChangeContentJS() {
    DotNet.invokeMethodAsync('InvokeFromJsApp', "ChangeParaContentValue", "New Content");
}