using System;

namespace ReimaginedAdventure.Server
{
    public class AccountCreationResult
    {
        public bool WasSuccessful { get; set; }
        public string[] Errors { get; set; } = Array.Empty<string>();
    }
}
