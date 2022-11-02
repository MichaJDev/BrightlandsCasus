using BrightLandsWayfinding.Models.Stories;

namespace BrightLandsWayfinding.Models.Locations
{
    public class Building
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public List<Story>? Stories { get; set; }
    }
}
