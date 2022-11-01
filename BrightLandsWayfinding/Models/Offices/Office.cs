using BrightLandsWayfinding.Models.Companies;
using BrightLandsWayfinding.Models.Steps;
using BrightLandsWayfinding.Models.Stories;

namespace BrightLandsWayfinding.Models.Offices
{
    public class Office
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Story? Story { get; set; }
        public Company? Company { get; set; }
        public List<Step> NavigationSteps { get; set; }
    }
}
