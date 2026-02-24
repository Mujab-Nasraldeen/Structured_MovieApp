namespace Movie.API.Extensions;
public static class ApiConfiguration
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }
}