using Movie.Data.Models;

namespace Movie.Services.IService;
public interface IGenreService
{
    Task<IEnumerable<Genre>> GetAllAsync();
    Task<Genre?> GetByIdAsync(long id);
    Task<Genre> CreateAsync(Genre genre);
    Task<Genre?> UpdateAsync(long id, Genre genre);
    Task<Genre?> DeleteAsync(long id);
}