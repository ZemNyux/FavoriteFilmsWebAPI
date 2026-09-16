using FavoriteFilmsMVC.Services;

namespace FavoriteFilmsMVC.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMoviesService, MoviesService>();
        return services;
    }
}