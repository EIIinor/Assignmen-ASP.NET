﻿using Assignmen_ASP.NET.Helpers.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Assignmen_ASP.NET.Services;

public class CategoryService
{


    private readonly CategoryRepository _categoryRepo;

    public CategoryService(CategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }




    public async Task<List<SelectListItem>> GetCategoriesAsync()
    {
        var categories = new List<SelectListItem>();

        foreach (var category in await _categoryRepo.GetAllAsync())
        {
            categories.Add(new SelectListItem
            {
                Value = category.Id.ToString(),
                Text = category.CategoryName,
            });
        }
        return categories;
    }



    public async Task<List<SelectListItem>> GetCategoriesAsync(string[] selectedCategories)
    {
        var categories = new List<SelectListItem>();

        foreach (var category in await _categoryRepo.GetAllAsync())
        {
            categories.Add(new SelectListItem
            {
                Value = category.Id.ToString(),
                Text = category.CategoryName,
                Selected = selectedCategories.Contains(category.Id.ToString())
            });
        }
        return categories;
    }
}
