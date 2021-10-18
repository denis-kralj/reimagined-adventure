using System.ComponentModel.DataAnnotations;

namespace ReimaginedAdventure.Shared.Models
{
    public class CreateGameTableModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        [Display(Name = "Table name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Table description")]
        public string Description { get; set; } = string.Empty;
    }
}
