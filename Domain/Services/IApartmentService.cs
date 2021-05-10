using System.Collections.Generic;
using System.Threading.Tasks;
using ApartmentFinder.Domain.Models;
using ApartmentFinder.Domain.Services.Communication;

namespace ApartmentFinder.Domain.Services
{
    public interface IApartmentService
    {
        Task<IEnumerable<Apartment>> ListAsync();
        Task<ApartmentResponse> SaveAsync(Apartment apartment);
        Task<ApartmentResponse> UpdateAsync(int id, Apartment apartment);
        Task<ApartmentResponse> DeleteAsync(int id);
        
    }
}