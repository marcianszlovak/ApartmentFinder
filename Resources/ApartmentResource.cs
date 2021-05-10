namespace ApartmentFinder.Resources
{
    public class ApartmentResource
    {
        public int Id { get; set; }
        public int Rooms { get; set; }
        public string Description { get; set; }
        public LocationResource Location { get; set; }
    }
}