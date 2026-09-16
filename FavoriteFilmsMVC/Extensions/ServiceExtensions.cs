using FavoriteFilmsMVC.Repositories;
using FavoriteFilmsMVC.Services;

namespace FavoriteFilmsMVC.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMoviesService, MoviesService>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        return services;
    }
}