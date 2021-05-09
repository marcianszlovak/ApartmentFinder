using System.Collections.Generic;
using System.Threading.Tasks;
using ApartmentFinder.Domain.Models;
using ApartmentFinder.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentFinder.Controllers
{
    [Route("/api/[controller]")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Apartment>> GetAllAsync()
        {
            var apartments = await _apartmentService.ListAsync();
            return apartments;
        }
    }
}