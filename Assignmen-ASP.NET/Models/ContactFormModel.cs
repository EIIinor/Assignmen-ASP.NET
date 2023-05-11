namespace Assignmen_ASP.NET.Models;

public class ContactFormModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Company { get; set; }
    public string? Text { get; set; }
    public bool? SaveMe { get; set; }

}
