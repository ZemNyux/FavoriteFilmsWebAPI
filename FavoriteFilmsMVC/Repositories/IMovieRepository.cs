using FavoriteFilmsMVC.Models;

namespace FavoriteFilmsMVC.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
        Task SaveAsync();
    }
}