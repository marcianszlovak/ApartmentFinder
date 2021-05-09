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
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentService(IApartmentRepository apartmentRepository, IUnitOfWork unitOfWork)
        {
            _apartmentRepository = apartmentRepository;
            _unitOfWork = unitOfWork;
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
                await _unitOfWork.CompleteAsync();

                return new ApartmentResponse(apartment);
            }
            catch (Exception e)
            {
                return new ApartmentResponse($"An error occurred when saving the apartment: {e.Message}");
            }
        }
    }
}