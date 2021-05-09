using ApartmentFinder.Domain.Models;
using ApartmentFinder.Resources;
using AutoMapper;

namespace ApartmentFinder.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveApartmentResource, Apartment>();
        }
    }
}