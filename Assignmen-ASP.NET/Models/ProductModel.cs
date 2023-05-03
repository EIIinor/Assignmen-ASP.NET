namespace Assignmen_ASP.NET.Models;

public class ProductModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public byte[]? ImageData { get; set; }
}



//public IFormFile? ImageFile { get; set; }