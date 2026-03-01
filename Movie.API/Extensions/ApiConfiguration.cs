namespace Movie.API.Extensions;
public static class ApiConfiguration
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddCors(options =>
        {
            options.AddPolicy("MovieAPI", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }
}