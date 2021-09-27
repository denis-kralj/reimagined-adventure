using System;
using SD = System.Drawing;

namespace ReimaginedAdventure.Shared
{
    public record User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Handle { get; set; } = string.Empty;
        public string Color { get; set; } = SD.Color.Black.ToHexCode();
    }
}
