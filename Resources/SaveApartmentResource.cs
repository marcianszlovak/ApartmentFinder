using System.ComponentModel.DataAnnotations;
using ApartmentFinder.Domain.Models;

namespace ApartmentFinder.Resources
{
    public class SaveApartmentResource
    {
        [Required] [Range(1, 50)] public int Rooms { get; set; }
        [Required] [MinLength(30)] public string Description { get; set; }
        [Required] public LocationResource Location { get; set; }
    }
}