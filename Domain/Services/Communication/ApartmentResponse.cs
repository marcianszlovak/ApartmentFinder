using ApartmentFinder.Domain.Models;

namespace ApartmentFinder.Domain.Services.Communication
{
    public class ApartmentResponse : BaseResponse<Apartment>
    {
        public ApartmentResponse(Apartment apartment) : base(apartment)
        {
        }

        public ApartmentResponse(string message) : base(message)
        {
        }
    }
}