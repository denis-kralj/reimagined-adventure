using SD = System.Drawing;

namespace ReimaginedAdventure.Shared
{
    public record User
    {
        public string Handle { get; set; } = string.Empty;
        public string Color { get; set; } = SD.Color.Black.ToHexCode();
    }
}