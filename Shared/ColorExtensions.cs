using System.Drawing;

namespace ReimaginedAdventure.Shared
{
    public static class ColorExtensions
    {
        public static string ToHexCode(this Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }
    }
}
