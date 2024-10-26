using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(50, ErrorMessage = "The maximum length for the name is 50 characters.")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The maximum length for the name is 50 characters.")]
        public string? LastName { get; set; }
        [Required]
        [StringLength(2048, ErrorMessage = "The maximum length for the URL is 2048 characters.")]
        public string? ProfileImageURL { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
