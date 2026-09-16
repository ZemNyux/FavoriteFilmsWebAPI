using FavoriteFilmsMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FavoriteFilmsMVC.Services;

public class MoviesService : IMoviesService
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public MoviesService(AppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _context.Movies.FindAsync(id);
    }

    public async Task<Movie> CreateAsync(Movie movie, IFormFile? posterFile)
    {
        if (posterFile != null && posterFile.Length > 0)
        {
            var path = await SavePosterAsync(posterFile);
            movie.PosterPath = path;
            movie.PosterUrl = path;
        }

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<bool> UpdateAsync(int id, Movie movie, IFormFile? posterFile)
    {
        var existingMovie = await _context.Movies.FindAsync(id);
        if (existingMovie == null) return false;

        existingMovie.Title = movie.Title;
        existingMovie.Genre = movie.Genre;
        existingMovie.ReleaseYear = movie.ReleaseYear;
        existingMovie.Description = movie.Description;

        if (posterFile != null && posterFile.Length > 0)
        {
            DeletePoster(existingMovie.PosterPath);
            existingMovie.PosterPath = await SavePosterAsync(posterFile);
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return false;

        DeletePoster(movie.PosterPath);
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<string> SavePosterAsync(IFormFile file)
    {
        var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
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