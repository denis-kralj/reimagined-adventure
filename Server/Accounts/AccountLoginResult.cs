namespace ReimaginedAdventure.Server
{
    public class AccountLoginResult
    {
        public bool WasSuccessful { get; set; }
        public string ReturnUrl { get; set; }
        public string[] Errors { get; set; }
    }
}
