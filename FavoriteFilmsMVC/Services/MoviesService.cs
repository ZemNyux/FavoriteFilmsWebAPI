using FavoriteFilmsMVC.Models;
using FavoriteFilmsMVC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FavoriteFilmsMVC.Services;

public class MoviesService : IMoviesService
{
    private readonly IMovieRepository _repository;
    private readonly IWebHostEnvironment _environment;

    public MoviesService(IMovieRepository repository, IWebHostEnvironment environment)
    {
        _repository = repository;
        _environment = environment;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Movie?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Movie> CreateAsync(Movie movie, IFormFile? posterFile)
    {
        if (posterFile != null && posterFile.Length > 0)
        {
            var savedPath = await SavePosterAsync(posterFile);
            movie.PosterPath = savedPath;
            movie.PosterUrl = savedPath;
        }

        await _repository.AddAsync(movie);
        await _repository.SaveAsync();
        return movie;
    }

    public async Task<bool> UpdateAsync(int id, Movie movie, IFormFile? posterFile)
    {
        var existingMovie = await _repository.GetByIdAsync(id);
        if (existingMovie == null) return false;

        existingMovie.Title = movie.Title;
        existingMovie.Director = movie.Director;
        existingMovie.Genre = movie.Genre;
        existingMovie.ReleaseYear = movie.ReleaseYear;
        existingMovie.Description = movie.Description;

        if (posterFile != null && posterFile.Length > 0)
        {
            DeletePoster(existingMovie.PosterPath);
            var savedPath = await SavePosterAsync(posterFile);
            existingMovie.PosterPath = savedPath;
            existingMovie.PosterUrl = savedPath;
        }

        _repository.Update(existingMovie);
        await _repository.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var movie = await _repository.GetByIdAsync(id);
        if (movie == null) return false;

        DeletePoster(movie.PosterPath);
        _repository.Delete(movie);
        await _repository.SaveAsync();
        return true;
    }

    private async Task<string> SavePosterAsync(IFormFile posterFile)
    {
        var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqueFileName = Guid.NewGuid().ToString() + "_" + posterFile.FileName;
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await posterFile.CopyToAsync(fileStream);
        }

        return "/images/" + uniqueFileName;
    }

    private void DeletePoster(string? posterPath)
    {
        if (string.IsNullOrEmpty(posterPath)) return;

        var fullPath = Path.Combine(_environment.WebRootPath, posterPath.TrimStart('/'));
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }

}