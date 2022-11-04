using BrightLandsWayfinding.Models.Rooms;

namespace BrightLandsWayfinding.Models.Steps
{
    public class Step
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int RoomID { get; set; }
        public Room? Room { get; set; }
    }
}
