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
    private readonly CategoryRepository _categoryRepo;
    private readonly ProductCategoryRepository _productCategoryRepo;
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo, DataContext context, IWebHostEnvironment webHostEnvironment, CategoryRepository categoryRepo, ProductCategoryRepository productCategoryRepo)
    {
        _productRepo = productRepo;
        _productTagRepo = productTagRepo;
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _categoryRepo = categoryRepo;
        _productCategoryRepo = productCategoryRepo;
    }


    public async Task<ProductModel> CreateAsync(ProductEntity entity)
    {
        var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
        if (_entity == null)
        {
            _entity = await _productRepo.AddAsync(entity);
            if (_entity != null)
                return _entity;
        }
        return null!;
    }


    //public async Task<bool> CreateAsync(ProductEntity entity)
    //{
    //    var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
    //    if (_entity == null)
    //    {
    //        _entity = await _productRepo.AddAsync(entity);
    //        if (_entity != null)
    //            return true;
    //    }
    //    return false;
    //}


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



    public async Task AddProductCategoriesAsync(ProductEntity entity, string[] tags)
    {
        foreach (var tag in tags)
        {
            await _productCategoryRepo.AddAsync(new ProductCategoryEntity
            {
                ArticleNumber = entity.ArticleNumber,
                CategoryId = int.Parse(tag),
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



    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var items = await _productRepo.GetAllAsync(/*includeProperties: "ProductTags"*/);

        var list = new List<ProductModel>();
        foreach (var item in items)
        {
            var productModel = new ProductModel
            {
                ArticleNumber = item.ArticleNumber,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                ImageUrl = item.ImageUrl,
                ProductTags = item.ProductTags
            };
            list.Add(productModel);
        }
        return list;
    }


    //public async Task<IEnumerable<ProductModel>> GetAllAsync()
    //{
    //    var items = await _productRepo.GetAllAsync();

    //    var list = new List<ProductModel>();
    //    foreach (var item in items)
    //        list.Add(item);
    //    return list;
    //}


    //public async Task<IEnumerable<ProductModel>> GetAllAsync(Func<IQueryable<ProductEntity>, IQueryable<ProductEntity>> include = null)
    //{
    //    IQueryable<ProductEntity> queryable = _productRepo.GetAllAsync().AsQueryable();

    //    if (include != null)
    //    {
    //        queryable = include(queryable);
    //    }

    //    var items = await queryable.ToListAsync();

    //    return items.Select(p => (ProductModel)p).ToList();
    //}






    public async Task<ProductModel> GetProductByArticleNumberAsync(string articleNumber)
    {
        var productEntity = await _productRepo.GetAsync(x => x.ArticleNumber == articleNumber);

        return productEntity;
    }


    public async Task<IEnumerable<ProductModel>> GetProductsByTagAsync(string tagName, int numberOfProducts)
    {
        var tag = await _context.Tags.SingleOrDefaultAsync(t => t.TagName == tagName);
        if (tag == null)
        {
            return Enumerable.Empty<ProductModel>();
        }

        var productIds = (await _productTagRepo.GetAllAsync(pt => pt.TagId == tag.Id))
            .Select(pt => pt.ArticleNumber)
            .Take(numberOfProducts)
            .ToList();

        var products = await _productRepo.GetAllAsync(
            p => productIds.Contains(p.ArticleNumber));
            //includeProperties: "ProductTags.Tag");


        return products.Select(p => (ProductModel)p).ToList();
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
