using BrightLandsWayfinding.Models.Companies;
using BrightLandsWayfinding.Models.enums.UserType;
using System.ComponentModel.DataAnnotations;

namespace BrightLandsWayfinding.Models.Users
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname can't be empty")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [Required(ErrorMessage = "Description can't be empty")]
        [StringLength(400)]
        public string Description { get; set; }
        public Company? company;

    }
}
