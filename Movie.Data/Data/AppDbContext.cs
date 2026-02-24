using Microsoft.EntityFrameworkCore;

namespace Movie.Data.Data;
public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public const string DBConnectionString = ConnectionString.TestString;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(DBConnectionString);
    }

    //public DbSet<Genre> Genres { get; set; }
    //public DbSet<Moviee> Movies { get; set; }
}