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
                return new ApartmentResponse($"An error occurred when saving the apartment: {e.Message}.");
            }
        }

        public async Task<ApartmentResponse> UpdateAsync(int id, Apartment apartment)
        {
            var existingApartment = await _apartmentRepository.FindByIdAsync(id);

            if (existingApartment == null)
                return new ApartmentResponse($"Apartment with id [{id}] not found.");

            existingApartment.Description = apartment.Description;
            existingApartment.Rooms = apartment.Rooms;

            try
            {
                _apartmentRepository.Update(existingApartment);
                await _unitOfWork.CompleteAsync();

                return new ApartmentResponse(existingApartment);
            }
            catch (Exception e)
            {
                return new ApartmentResponse($"An error occured when updating the category: {e.Message}.");
            }
        }

        public async Task<ApartmentResponse> DeleteAsync(int id)
        {
            var existingApartment = await _apartmentRepository.FindByIdAsync(id);

            if (existingApartment == null)
            {
                return new ApartmentResponse($"Apartment with id [{id}] not found.");
            }

            try
            {
                _apartmentRepository.Remove(existingApartment);
                await _unitOfWork.CompleteAsync();

                return new ApartmentResponse($"Successfully deleted Apartment with id [{id}].");
            }
            catch (Exception e)
            {
                return new ApartmentResponse($"An error occurred when deleting the apartment: {e.Message}");
            }
        }
    }
}