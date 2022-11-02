using BrightLandsWayfinding.Models.Buildings;
using BrightLandsWayfinding.Models.Rooms;

namespace BrightLandsWayfinding.Models.Stories
{
    public class Story
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Room>? Rooms { get; set; }
        public Building? Building { get; set; }

    }
}
