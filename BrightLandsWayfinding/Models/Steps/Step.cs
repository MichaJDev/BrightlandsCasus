using BrightLandsWayfinding.Models.MapRoutes;
using BrightLandsWayfinding.Models.Rooms;

namespace BrightLandsWayfinding.Models.Steps
{
    public class Step
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int MapRouteID { get; set; }
        public MapRoute? MapRoute { get; set; }
    }
}
