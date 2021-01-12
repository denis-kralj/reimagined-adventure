using System.Collections.Generic;
using System.Linq;

namespace ReimaginedAdventure.Shared
{
    public class MemoryChatStore : IChatStore
    {
        private List<ChatMessage> _messageStore = new List<ChatMessage>();

        public void PostMessage(ChatMessage newMessage)
        {
            _messageStore.Add(newMessage);
        }
        public IList<ChatMessage> GetAllMessages()
        {
            return _messageStore.OrderBy(e => e.Posted).ToList();
        }
    }
}
