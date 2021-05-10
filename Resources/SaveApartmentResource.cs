using System.ComponentModel.DataAnnotations;

namespace ApartmentFinder.Resources
{
    public class SaveApartmentResource
    {
        [Required] [MinLength(30)] public string Description { get; set; }
        [Required] public int LocationId { get; set; }
    }
}