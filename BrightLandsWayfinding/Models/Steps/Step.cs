using BrightLandsWayfinding.Models.Offices;
using MessagePack;

namespace BrightLandsWayfinding.Models.Steps
{
    public class Step
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Office Office { get; set; }
    }
}
