using FavoriteFilmsMVC.Models;
using FavoriteFilmsMVC.Repositories;

namespace FavoriteFilmsMVC.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

        public MoviesService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _unitOfWork.Movies.GetAllAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Movies.GetByIdAsync(id);
        }

        public async Task<Movie> CreateAsync(Movie movie, IFormFile? posterFile)
        {
            if (posterFile != null && posterFile.Length > 0)
            {
                var savedPath = await SavePosterAsync(posterFile);
                movie.PosterPath = savedPath;
                movie.PosterUrl = savedPath;
            }

            await _unitOfWork.Movies.AddAsync(movie);
            await _unitOfWork.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> UpdateAsync(int id, Movie movie, IFormFile? posterFile)
        {
            var existingMovie = await _unitOfWork.Movies.GetByIdAsync(id);
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

            _unitOfWork.Movies.Update(existingMovie);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await _unitOfWork.Movies.GetByIdAsync(id);
            if (movie == null) return false;

            DeletePoster(movie.PosterPath);
            _unitOfWork.Movies.Delete(movie);
            await _unitOfWork.SaveChangesAsync();
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
}