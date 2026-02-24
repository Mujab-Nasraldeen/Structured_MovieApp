using Microsoft.EntityFrameworkCore;
using Movie.Data.Models;

namespace Movie.Data.Data;
public partial class AppDbContext
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Moviee> Movies { get; set; }
}