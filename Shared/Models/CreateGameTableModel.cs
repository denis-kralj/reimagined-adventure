using System.ComponentModel.DataAnnotations;

namespace ReimaginedAdventure.Shared.Models
{
    public class CreateGameTableModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} but be at most {1} characters long.")]
        [Display(Name = "Table name")]
        public string Name { get; set; }

        [Display(Name = "Table description")]
        public string Description { get; set; }
    }
}
