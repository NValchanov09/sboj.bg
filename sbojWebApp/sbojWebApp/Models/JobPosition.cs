using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } 

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string? EmploymentRole { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public int? SalaryLow { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public int? SalaryHigh { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Experience must be a positive number.")]
        public int? ExperienceLow { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Experience must be a positive number.")]
        public int? ExperienceHigh { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Vacation days must be a positive number.")]
        public int? VacationDaysLow { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Vacation days must be a positive number.")]
        public int? VacationDaysHigh { get; set; }

        public ICollection<Language> RequiredLanguages { get; set; } = new List<Language>();
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
