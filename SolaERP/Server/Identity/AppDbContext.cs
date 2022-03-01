using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class AppDbContext : KeyApiAuthorizationDbContext<AppUser, AppRole, int>
{
    public AppDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Config");
        modelBuilder.Entity<AppUser>(entity => { entity.ToTable(name: "AppUser"); });
        modelBuilder.Entity<AppRole>(entity => { entity.ToTable(name: "AppRole"); });
    }
}