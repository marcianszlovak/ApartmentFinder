using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApartmentFinder.Domain.Models;
using ApartmentFinder.Domain.Repositories;
using ApartmentFinder.Domain.Services;
using ApartmentFinder.Domain.Services.Communication;

namespace ApartmentFinder.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public async Task<IEnumerable<Apartment>> ListAsync()
        {
            return await _apartmentRepository.ListAsync();
        }

        public async Task<ApartmentResponse> SaveAsync(Apartment apartment)
        {
            try
            {
                await _apartmentRepository.AddAsync(apartment);
                
                return new ApartmentResponse(apartment);
            }
            catch (Exception e)
            {
                return new ApartmentResponse($"An error occurred when saving the apartment: {e.Message}");
            }
        }
    }
}