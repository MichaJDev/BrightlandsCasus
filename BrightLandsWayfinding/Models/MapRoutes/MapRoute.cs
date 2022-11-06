using BrightLandsWayfinding.Models.Rooms;
using BrightLandsWayfinding.Models.Steps;

namespace BrightLandsWayfinding.Models.MapRoutes
{
    public class MapRoute
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int StartLocationID { get; set; }
        public Room? StartLocation { get; set; }
        public int EndLocationID { get; set; }
        public Room? EndLocation { get; set; }
        public List<Step>? Steps { get; set; }
    }
}
