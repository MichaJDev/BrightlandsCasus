﻿using BrightLandsWayfinding.Models.Companies;
using BrightLandsWayfinding.Models.Stories;

namespace BrightLandsWayfinding.Models.Offices
{
    public class Office
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Story? Story { get; set; }
        public Company? Company { get; set; }
        public List<String> NavigationSteps { get; set; }
    }
}
