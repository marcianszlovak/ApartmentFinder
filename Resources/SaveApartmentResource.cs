using System.ComponentModel.DataAnnotations;

namespace ApartmentFinder.Resources
{
    public class SaveApartmentResource
    {
        [Required] public string Description { get; set; }
    }
}