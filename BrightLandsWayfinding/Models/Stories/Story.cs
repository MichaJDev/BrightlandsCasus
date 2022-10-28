using BrightLandsWayfinding.Models.Locations;
using BrightLandsWayfinding.Models.Offices;

namespace BrightLandsWayfinding.Models.Stories
{
    public class Story
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Office> Offices { get; set; }
        public Location Location { get; set; }

    }
}
