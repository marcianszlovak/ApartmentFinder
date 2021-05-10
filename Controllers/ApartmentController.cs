using System.Collections.Generic;
using System.Threading.Tasks;
using ApartmentFinder.Domain.Models;
using ApartmentFinder.Domain.Services;
using ApartmentFinder.Extensions;
using ApartmentFinder.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentFinder.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;

        public ApartmentController(IApartmentService apartmentService, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApartmentResource>), 200)]
        public async Task<IEnumerable<ApartmentResource>> GetAllAsync()
        {
            var apartments = await _apartmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Apartment>, IEnumerable<ApartmentResource>>(apartments);

            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApartmentResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
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

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApartmentResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveApartmentResource resource)
        {
            var apartment = _mapper.Map<SaveApartmentResource, Apartment>(resource);
            var result = await _apartmentService.UpdateAsync(id, apartment);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var apartmentResource = _mapper.Map<Apartment, ApartmentResource>(result.Resource);
            return Ok(apartmentResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApartmentResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _apartmentService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var apartmentResource = _mapper.Map<Apartment, ApartmentResource>(result.Resource);
            return Ok(apartmentResource);
        }
    }
}