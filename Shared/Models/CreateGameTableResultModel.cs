namespace ReimaginedAdventure.Shared.Models
{
    public class CreateGameTableResultModel
    {
        public bool WasSuccessful { get; set; }
        public string ReturnUrl { get; set; }
        public string[] Errors { get; set; }
    }
}
