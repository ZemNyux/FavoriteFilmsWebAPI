using FavoriteFilmsMVC.Models;

namespace FavoriteFilmsMVC.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> Movies { get; }
        Task<int> SaveChangesAsync();
    }
}