using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthApp_Backend.Data;

public class HealthAppAuthDbContext: IdentityDbContext
{
    public HealthAppAuthDbContext(DbContextOptions<HealthAppAuthDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var readerId = "c66d46bd-ee48-4fb6-8c9a-280ffb4fdb20";
        var writerId = "6153d6bc-250c-42be-9c45-f5aee5fd4add";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = readerId,
                ConcurrencyStamp = readerId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
            },
            new IdentityRole
            {
                Id = writerId ,
                ConcurrencyStamp = writerId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}