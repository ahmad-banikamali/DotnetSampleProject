using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Infrastructure.EntityConfigurations;

namespace Repository.Infrastructure;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PriceHistoryConfiguration());
        builder.Entity<IdentityRole>().HasData(new List<IdentityRole> {new("admin")});
        builder.Entity<IdentityRole>().HasData(new List<IdentityRole> {new("other")});
        base.OnModelCreating(builder);
    }
}