using FavoriteFilmsMVC.Models;

namespace FavoriteFilmsMVC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<Movie> Movies { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Movies = new Repository<Movie>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}