using System.ComponentModel.DataAnnotations;

namespace ApartmentFinder.Resources
{
    public class LocationResource
    {
        [Required] public string County { get; set; }
        [Required] public string City { get; set; }
        public string District { get; set; }
    }
}