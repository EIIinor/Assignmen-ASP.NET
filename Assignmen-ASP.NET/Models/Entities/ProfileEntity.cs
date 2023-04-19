using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignmen_ASP.NET.Models.Entities;

public class ProfileEntity
{
    [Key, ForeignKey("User")]
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public UserEntity User { get; set; } = null!;
}
