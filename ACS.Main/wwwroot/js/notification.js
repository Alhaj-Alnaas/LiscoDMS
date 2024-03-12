"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();
connection.on("sendToUser", (NumberOfNewMessages) => {
    var NewMessagesCount = document.createElement("NewMessagesCount");
    NewMessagesCount.innerHTML = NumberOfNewMessages;
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});