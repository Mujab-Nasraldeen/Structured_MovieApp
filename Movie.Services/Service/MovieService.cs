using Movie.Data.Data;
using Movie.Data.Models;
using Movie.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace Movie.Services.Service;
public class MovieService(AppDbContext context) : IMovieService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Moviee>> GetAllAsync()
    {
        return await _context.Movies
            .Include(m => m.Genre)
            .ToListAsync();
    }

    public async Task<Moviee?> GetByIdAsync(long id)
    {
        return await _context.Movies
            .Include(m => m.Genre)
            .SingleOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Moviee?> CreateAsync(Moviee movie)
    {
        // التحقق من وجود الـ Genre
        var genreExists = await _context.Genres.AnyAsync(g => g.Id == movie.GenreId);
        if (!genreExists) return null;

        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<Moviee?> UpdateAsync(long id, Moviee movie)
    {
        var existingMovie = await _context.Movies.FindAsync(id);
        if (existingMovie == null) return null;

        // التحقق من وجود الـ Genre
        var genreExists = await _context.Genres.AnyAsync(g => g.Id == movie.GenreId);
        if (!genreExists) return null;

        existingMovie.Title = movie.Title;
        existingMovie.Year = movie.Year;
        existingMovie.Rate = movie.Rate;
        existingMovie.Location = movie.Location;
        existingMovie.GenreId = movie.GenreId;

        await _context.SaveChangesAsync();
        return existingMovie;
    }

    public async Task<Moviee?> DeleteAsync(long id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return null;

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return movie;
    }
}