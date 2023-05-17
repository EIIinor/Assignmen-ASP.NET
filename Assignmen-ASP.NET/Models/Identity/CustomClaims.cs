using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Assignmen_ASP.NET.Models.Identity;

public class CustomClaims : UserClaimsPrincipalFactory<AppUser>
{
    private readonly UserManager<AppUser> userManager;

    public CustomClaims(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
    {
        this.userManager = userManager;
    }



    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
    {
        var claimsIdentity = await base.GenerateClaimsAsync(user);
        var profilePictureUrl = GetUserImageUrl(user.Id);

        var appUser = await userManager.FindByIdAsync(user.Id);

        claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));
        claimsIdentity.AddClaim(new Claim("ProfilePicture", profilePictureUrl));

        return claimsIdentity;
    }

    private string GetUserImageUrl(string userId)
    {
        var user = userManager.FindByIdAsync(userId).Result;

        if (user != null)
        {
            return user.ImageUrl ?? string.Empty;
        }

        return string.Empty;
    }

}
