using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        [Required]
        [StringLength(75, ErrorMessage = "The maximum length for the title is 75 characters.")]
        public string? Title { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "The maximum length for the description is 300 characters.")]
        public string? Description { get; set; } 

        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        [StringLength(50, ErrorMessage = "The maximum length for the name is 50 characters.")]
        public string? EmploymentRole { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a nonnegative number.")]
        public int? SalaryLow { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a nonnegative number.")]
        public int? SalaryHigh { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Experience must be a nonnegative number.")]
        public int? ExperienceLow { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Experience must be a nonnegative number.")]
        public int? ExperienceHigh { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Vacation days must be a nonnegative number.")]
        public int? VacationDaysLow { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Vacation days must be a nonnegative number.")]
        public int? VacationDaysHigh { get; set; }

        public ICollection<Language> RequiredLanguages { get; set; } = new List<Language>();

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
