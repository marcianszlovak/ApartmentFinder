using System.Collections.Generic;

namespace ApartmentFinder.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public IList<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}