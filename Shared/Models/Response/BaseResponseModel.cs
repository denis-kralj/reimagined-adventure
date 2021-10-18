using System;

namespace ReimaginedAdventure.Shared.Models
{
    public class BaseResponseModel
    {
        public bool WasSuccessful { get; set; }
        public string ReturnUrl { get; set; } = string.Empty;
        public string[] Errors { get; set; } = Array.Empty<string>();
    }
}
