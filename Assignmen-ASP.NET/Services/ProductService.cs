using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assignmen_ASP.NET.Services;

public class ProductService
{
    //private readonly DataContext _context;

    //public ProductService(DataContext context)
    //{
    //    _context = context;
    //}

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


    //public async Task<IEnumerable<ProductModel>> GetAllASync()
    //{
    //    var products = new List<ProductModel>();
    //    var items = await _context.Products.ToListAsync();
    //    foreach (var item in items)
    //    {
    //        ProductModel productModel = item;
    //        products.Add(productModel);
    //    }
    //    return products;
    //}
}
