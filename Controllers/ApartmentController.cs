using System.Collections.Generic;
using System.Threading.Tasks;
using ApartmentFinder.Domain.Models;
using ApartmentFinder.Domain.Services;
using ApartmentFinder.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentFinder.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;

        public ApartmentController(IApartmentService apartmentService, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApartmentResource>> GetAllAsync()
        {
            var apartments = await _apartmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Apartment>, IEnumerable<ApartmentResource>>(apartments);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveApartmentResource resource)
        {
            var apartment = _mapper.Map<SaveApartmentResource, Apartment>(resource);
            var result = await _apartmentService.SaveAsync(apartment);


            if (!result.Success)
            {
                return BadRequest();
            }

            var apartmentResource = _mapper.Map<Apartment, ApartmentResource>(result.Resource);
            return Ok(apartmentResource);
        }
    }
}