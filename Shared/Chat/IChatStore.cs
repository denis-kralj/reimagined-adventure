using System.Collections.Generic;

namespace ReimaginedAdventure.Shared
{
    public interface IChatStore
    {
        void PostMessage(ChatMessage newMessage);
        IList<ChatMessage> GetAllMessages();
    }
}