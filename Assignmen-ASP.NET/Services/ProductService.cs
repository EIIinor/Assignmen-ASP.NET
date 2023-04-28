using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assignmen_ASP.NET.Services;

public class ProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }





    public async Task<bool> CreateAsync(ProductRegisterViewModel productRegisterViewModel)
    {
        try
        {
            // Skapa en ny produkt och lägg till den i databasen
            var productEntity = new ProductEntity
            {
                Name = productRegisterViewModel.Name,
                Description = productRegisterViewModel.Description,
                Price = productRegisterViewModel.Price,
                ImageUrl = productRegisterViewModel.ImageUrl
            };

            _context.Products.Add(productEntity);

            // Hämta kategorierna från databasen
            var categories = await _context.Categories.ToListAsync();

            // Lägg till kategorierna i ProductRegisterViewModel-objektet
            productRegisterViewModel.Categories = categories;

            // Hämta de valda kategorierna för den nya produkten
            var selectedCategoryIds = productRegisterViewModel.SelectedCategoryIds;

            // Skapa en ny ProductCategoryEntity för varje vald kategori och lägg till dem i databasen
            foreach (var categoryId in selectedCategoryIds)
            {
                var productCategoryEntity = new ProductCategoryEntity
                {
                    ProductId = productEntity.Id,
                    CategoryId = categoryId
                };
                _context.ProductCategories.Add(productCategoryEntity);
            }

            // Spara ändringar i databasen
            await _context.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }




    //public async Task<bool> CreateAsync(ProductRegisterViewModel productRegisterViewModel)
    //{
    //    try
    //    {
    //        ProductEntity productEntity = productRegisterViewModel;

    //        _context.Products.Add(productEntity);
    //        await _context.SaveChangesAsync();
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}


    public async Task<IEnumerable<ProductModel>> GetAllASync()
    {
        var products = new List<ProductModel>();
        var items = await _context.Products.ToListAsync();
        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }
        return products;
    }
}
