using BrightLandsWayfinding.Models.Rooms;

namespace BrightLandsWayfinding.Models.Events
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RoomID { get; set; }
        public Room? Room { get; set; }
    }
}
