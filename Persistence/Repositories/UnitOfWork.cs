using System.Threading.Tasks;
using ApartmentFinder.Domain.Repositories;
using ApartmentFinder.Persistence.Contexts;

namespace ApartmentFinder.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}