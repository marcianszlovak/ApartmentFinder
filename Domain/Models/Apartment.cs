namespace ApartmentFinder.Domain.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
    }
}