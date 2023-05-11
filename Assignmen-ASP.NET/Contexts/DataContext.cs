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
    public DbSet<ProductTagEntity> ProductTags { get; set; }
    public DbSet<TagEntity> Tags { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<CategoryEntity>().HasData(
          new CategoryEntity { Id = 1, CategoryName = "All" },
          new CategoryEntity { Id = 2, CategoryName = "Bags" },
          new CategoryEntity { Id = 3, CategoryName = "Dress" },
          new CategoryEntity { Id = 4, CategoryName = "Decoration" },
          new CategoryEntity { Id = 5, CategoryName = "Essentials" },
          new CategoryEntity { Id = 6, CategoryName = "Interior" },
          new CategoryEntity { Id = 7, CategoryName = "Laptop" },
          new CategoryEntity { Id = 8, CategoryName = "Mobile" },
          new CategoryEntity { Id = 9, CategoryName = "Beauty" }
      );

        modelBuilder.Entity<TagEntity>().HasData(
          new TagEntity { Id = 1, TagName = "New" },
          new TagEntity { Id = 2, TagName = "Featured" },
          new TagEntity { Id = 3, TagName = "Popular" }
        );
    }
}

