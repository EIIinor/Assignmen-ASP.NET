using Assignmen_ASP.NET.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignmen_ASP.NET.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ContactFormEntity> Comments { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<CategoryEntity>().HasData(
          new CategoryEntity { Id = 1, Name = "New" },
          new CategoryEntity { Id = 2, Name = "Popular" },
          new CategoryEntity { Id = 3, Name = "Featured" }
      );
    }
}

