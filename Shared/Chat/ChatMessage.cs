using System;

namespace ReimaginedAdventure.Shared
{
    public record ChatMessage
    {
        public User User { get; set; }
        public DateTimeOffset Posted { get; set; }
        public string Message { get; set; }
    }
}