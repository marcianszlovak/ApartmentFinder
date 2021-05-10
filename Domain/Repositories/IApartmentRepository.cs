using System.Collections.Generic;
using System.Threading.Tasks;
using ApartmentFinder.Domain.Models;

namespace ApartmentFinder.Domain.Repositories
{
    public interface IApartmentRepository
    {
        Task<IEnumerable<Apartment>> ListAsync();

        Task AddAsync(Apartment apartment);
        // void Update(Apartment apartment);
        // void Remove(Apartment apartment);
    }
}