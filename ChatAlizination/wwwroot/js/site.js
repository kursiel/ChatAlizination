// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    var connection = new WebSocketManager.Connection("ws:localhost:5000/ChatAlizination");
    connection.enableLogging = true;

    connection.connectionMethods.onConnected = () => {

    }

    connection.connectionMethods.onDisconnected = () => {

    }
    //This will notify the client that the message was posted in the channel
    connection.clientMethods["pingMessage"] = (socketId, message) => {
        var messageText = socketId + ' said:' + message;
        //console.log(messageText);
        $('#messages').append('<li>' + messageText + '</li>');
        $('#messages').scrollTop($('#messages').prop('scrollHeight'));
    }

    var $messagecontent = $('#message-content');
    $messagecontent.keyup(function (e) {
        if (e.keyCode == 13) {
            var message = $messagecontent.val().trim();
            if (message.lenght == 0) {
                return false;
            }

            // this will be invoke the method specificed on the server in this case SendMessage  
            connection.invoke("SendMessage", connection.connectionId, message);
            $messagecontent.val('');
        }
    });

    connection.start();
});