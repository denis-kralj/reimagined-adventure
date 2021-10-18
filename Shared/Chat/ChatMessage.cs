using System;

namespace ReimaginedAdventure.Shared
{
    public record ChatMessage
    {
        public User User { get; set; } = new();
        public DateTimeOffset Posted { get; set; } = DateTimeOffset.MinValue;
        public string Message { get; set; } = string.Empty;
    }
}
