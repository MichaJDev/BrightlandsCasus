
using BrightLandsWayfinding.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace BrightLandsWayfinding.Models.Companies
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(400)]
        [Required(ErrorMessage = "Description can't be empty")]
        public string Description { get; set; }
        public string? ProfileImage { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? WebsiteURL { get; set; }
        public List<User>? Employees { get; set; }
    }
}
