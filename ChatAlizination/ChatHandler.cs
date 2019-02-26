using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketManager;
using System.Dynamic;

namespace ChatAlizination
{
    public class ChatHandler : WebSocketHandler
    {
        private readonly ChatManager _chatMana;
        public ChatHandler(WebSocketConnectionManager webSocketConnectionManager, ChatManager chatManager) : base(webSocketConnectionManager)
        {
            _chatMana = chatManager;
        }

        public async Task SendMessage(string socketId, string message)
        {
            dynamic dynamicMessage = new ExpandoObject();
            dynamicMessage.UserId = socketId;
            dynamicMessage.Message = message;
            _chatMana.Messages.Add(dynamicMessage);
            //it will be notify if something trigger in the client with the method pingMessage
            await InvokeClientMethodToAllAsync("pingMessage", socketId, message);
        }
    }
}
