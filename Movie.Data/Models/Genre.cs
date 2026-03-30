namespace Movie.Data.Models;
public class Genre
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation Property - علاقة One-to-Many مع Movies
    public ICollection<Moviee> Movies { get; set; } = new List<Moviee>();
}