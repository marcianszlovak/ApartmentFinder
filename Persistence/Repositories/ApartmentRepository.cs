using System.Collections.Generic;
using System.Threading.Tasks;
using ApartmentFinder.Domain.Models;
using ApartmentFinder.Domain.Repositories;
using ApartmentFinder.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ApartmentFinder.Persistence.Repositories
{
    public class ApartmentRepository : BaseRepository, IApartmentRepository
    {
        public ApartmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Apartment>> ListAsync()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task AddAsync(Apartment apartment)
        {
            await _context.Apartments.AddAsync(apartment);
        }
    }
}