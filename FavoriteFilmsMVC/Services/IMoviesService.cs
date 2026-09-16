using FavoriteFilmsMVC.Models;
using Microsoft.AspNetCore.Http;

namespace FavoriteFilmsMVC.Services;

public interface IMoviesService
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> GetByIdAsync(int id);
    Task<Movie> CreateAsync(Movie movie, IFormFile? posterFile);
    Task<bool> UpdateAsync(int id, Movie movie, IFormFile? posterFile);
    Task<bool> DeleteAsync(int id);
}