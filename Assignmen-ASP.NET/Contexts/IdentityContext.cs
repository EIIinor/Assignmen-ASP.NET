using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignmen_ASP.NET.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {  
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<UserAddressEntity> UsersAddresses { get; set; }

    }
}
