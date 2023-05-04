using System.ComponentModel.DataAnnotations;

namespace Assignmen_ASP.NET.Models.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

    public ICollection<ProductCategoryEntity> ProductTags { get; set; } = new HashSet<ProductCategoryEntity>();
}
