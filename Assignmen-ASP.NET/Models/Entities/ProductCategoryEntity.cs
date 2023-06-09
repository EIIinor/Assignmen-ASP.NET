﻿using Microsoft.EntityFrameworkCore;

namespace Assignmen_ASP.NET.Models.Entities;


[PrimaryKey(nameof(ArticleNumber), nameof(CategoryId))]
public class ProductCategoryEntity
{
    public string ArticleNumber { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}
