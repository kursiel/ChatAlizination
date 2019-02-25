using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketManager;

namespace ChatAlizination
{
    public class ChatHandler : WebSocketHandler
    {
        public ChatHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }

        public async Task SendMessage(string socketId, string message)
        {
            //it will be notify if something trigger in the client with the method pingMessage
            await InvokeClientMethodToAllAsync("pingMessage", socketId, message);
        }
    }
}
