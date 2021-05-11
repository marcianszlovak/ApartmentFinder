using ApartmentFinder.Domain.Models;
using ApartmentFinder.Resources;
using AutoMapper;

namespace ApartmentFinder.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Apartment, ApartmentResource>();
            CreateMap<Location, LocationResource>();
        }
    }
}