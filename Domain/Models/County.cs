using System.Collections.Generic;

namespace ApartmentFinder.Domain.Models
{
    public class County
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        
        public IList<City> Cities { get; set; } = new List<City>();

    }
}