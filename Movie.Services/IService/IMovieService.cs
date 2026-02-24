using Movie.Data.Models;

namespace Movie.Services.IService;
public interface IMovieService
{
    Task<IEnumerable<Moviee>> GetAllAsync();
    Task<Moviee?> GetByIdAsync(long id);
    Task<Moviee?> CreateAsync(Moviee movie);
    Task<Moviee?> UpdateAsync(long id, Moviee movie);
    Task<Moviee?> DeleteAsync(long id);
}