using Microsoft.Extensions.DependencyInjection;
using Movie.Services.IService;
using Movie.Services.Service;

namespace Movie.Services.Configurations;
public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IMovieService, MovieService>();

        return services;
    }
}