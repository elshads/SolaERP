using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


public class ApiAuthorizationDbContext<TUser> : KeyApiAuthorizationDbContext<TUser, IdentityRole, string>
    where TUser : IdentityUser
{
    public ApiAuthorizationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }
}