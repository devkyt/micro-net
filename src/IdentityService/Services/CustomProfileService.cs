using System.Security.Claims;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Services;

public class CustomProfileService : IProfileService
{   
    private UserManager<ApplicationUser> _userManager;

    public CustomProfileService(UserManager<ApplicationUser> _userManager)
    {
        _userManager = _userManager;
    }
    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var user = await _userManager.GetUserAsync(context.Subject);
        var existingClaims = await _userManager.GetClaimsAsync(user);

        var calims = new List<Claim>
        {
            new Claim("username", user.UserName)
        };

        context.IssuedClaims.AddRange(calims);
        context.IssuedClaims.Add(existingClaims.FirstOrDefault(x => x.Type == JwtClaimTypes.Name));
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        return Task.CompletedTask;
    }
} 