namespace ReimaginedAdventure.Shared.Models
{
    public class AccountDataModel
    {
        public bool IsAuthenticated { get; set; } = false;
        public string Email { get; set; } = string.Empty;
    }
}
