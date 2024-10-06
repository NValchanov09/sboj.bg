using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? ProfileImagePath { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public ICollection<JobApplication> AppliedFor { get; set; } = new List<JobApplication>();
        public ICollection<JobPosition> Added { get; set; } = new List<JobPosition>();
    }
}
