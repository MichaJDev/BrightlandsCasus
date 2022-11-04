using BrightLandsWayfinding.Models.Companies;
using BrightLandsWayfinding.Models.enums.RoomType;
using BrightLandsWayfinding.Models.Steps;
using BrightLandsWayfinding.Models.Stories;

namespace BrightLandsWayfinding.Models.Rooms
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StoryID { get; set; }
        public Story? Story { get; set; }
        public RoomType? Type { get; set; }
    }
}
