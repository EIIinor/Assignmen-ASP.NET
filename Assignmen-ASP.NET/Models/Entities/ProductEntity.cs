using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignmen_ASP.NET.Models.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }
   
    public string? ImageUrl { get; set; }


    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();


    public ICollection<ProductCategoryEntity> ProductCategories { get; set; } = new List<ProductCategoryEntity>();



    public static implicit operator ProductModel(ProductEntity entity)
    {
        return new ProductModel
        {
            ArticleNumber = entity?.ArticleNumber,
            Name = entity?.Name,
            Description = entity?.Description,
            Price = entity?.Price,
            ImageUrl = entity?.ImageUrl,
        };
    }
}
