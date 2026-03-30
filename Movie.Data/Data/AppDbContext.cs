using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie.Data.DTOs;
using Movie.Data.Models;

namespace Movie.Data.Data;
public partial class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public const string DBConnectionString = ConnectionString.TestString;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(DBConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");

        builder.Entity<Moviee>().HasKey(e => e.Id);
        builder.Entity<Moviee>().Property(m => m.Title).HasMaxLength(5);
        builder.Entity<Moviee>().HasCheckConstraint("CK_Moviee_Year", "[Year] >= 2000 AND [Year] <= 9999");
    }

    //public DbSet<Genre> Genres { get; set; }
    //public DbSet<Moviee> Movies { get; set; }

}