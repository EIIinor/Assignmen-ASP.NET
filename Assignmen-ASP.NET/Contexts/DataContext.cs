using Assignmen_ASP.NET.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignmen_ASP.NET.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProfileEntity> Profiles { get; set; }
}
