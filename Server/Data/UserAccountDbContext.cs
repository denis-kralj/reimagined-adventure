using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ReimaginedAdventure.Server.Data
{
    public class UserAccountDbContext : IdentityDbContext
    {
        public UserAccountDbContext(DbContextOptions<UserAccountDbContext> options)
            : base(options)
        {
        }
    }
}
