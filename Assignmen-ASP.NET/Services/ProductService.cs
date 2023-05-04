using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Helpers.Repositories;
using Assignmen_ASP.NET.Models;
using Assignmen_ASP.NET.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Assignmen_ASP.NET.Services;

public class ProductService
{
    private readonly ProductRepository _productRepo;
    private readonly ProductTagRepository _productTagRepo;
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo, DataContext context, IWebHostEnvironment webHostEnvironment)
    {
        _productRepo = productRepo;
        _productTagRepo = productTagRepo;
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }


    public async Task<bool> CreateAsync(ProductEntity entity)
    {
        var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
        if (_entity == null)
        {
            _entity = await _productRepo.AddAsync(entity);
            if (_entity != null)
                return true;
        }
        return false;
    }


    public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
    {
        foreach(var tag in tags)
        {
            await _productTagRepo.AddAsync(new ProductTagEntity
            {
                ArticleNumber = entity.ArticleNumber,
                TagId = int.Parse(tag),
            });
        }
    }


    public async Task<bool> UploadImageAsync(ProductModel product, IFormFile image)
    {
        try
        {
            string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
            await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
            return true;
        }
        catch { return false; }
       
    }



    public async Task<IEnumerable<ProductModel>> GetAllASync()
    {
        var items = await _productRepo.GetAllAsync();
        var list = new List<ProductModel>();
        foreach (var item in items)
            list.Add(item);
        return list;
    }


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



}
