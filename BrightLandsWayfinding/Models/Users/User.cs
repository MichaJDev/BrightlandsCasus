using BrightLandsWayfinding.Models.Companies;
using BrightLandsWayfinding.Models.enums.Gender;
using BrightLandsWayfinding.Models.enums.UserType;
using System.ComponentModel.DataAnnotations;

namespace BrightLandsWayfinding.Models.Users
{
    public class User
    {
        public int ID { get; set; }
        public string? Prefix { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        [StringLength(50)]
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Surname can't be empty")]
        [StringLength(50)]
        public string Surname { get; set; }
        public string? Suffix { get; set; }
        [Required(ErrorMessage = "Email Address can't be empty")]
        [StringLength(254)]
        public string EmailAddress { get; set; }
        public string? TelephoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [Required(ErrorMessage = "Description can't be empty")]
        [StringLength(400)]
        public string Description { get; set; }
        public int CompanyID { get; set; }
        public Company? Company { get; set; }
    }
}
