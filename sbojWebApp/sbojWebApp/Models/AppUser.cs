using Microsoft.AspNetCore.Identity;
using sbojWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageURL { get; set; }
        public DateTime? CreationDate { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public UserRole Role { get; set; }   
    }
}
