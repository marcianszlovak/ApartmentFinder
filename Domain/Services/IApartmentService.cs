using System.Collections.Generic;
using System.Threading.Tasks;
using ApartmentFinder.Domain.Models;

namespace ApartmentFinder.Domain.Services
{
    public interface IApartmentService
    {
        Task<IEnumerable<Apartment>> ListAsync();
    }
}