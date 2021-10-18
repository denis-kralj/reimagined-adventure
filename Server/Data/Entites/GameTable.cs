using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ReimaginedAdventure.Server.Data
{
    public class GameTable
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(IdentityUser))]
        public IdentityUser Owner { get; set; } = Activator.CreateInstance<IdentityUser>();
    }
}