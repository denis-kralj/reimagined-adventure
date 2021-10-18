using System;

namespace ReimaginedAdventure.Server
{
    public class AccountLoginResult
    {
        public bool WasSuccessful { get; set; }
        public string ReturnUrl { get; set; } = string.Empty;
        public string[] Errors { get; set; } = Array.Empty<string>();
    }
}
