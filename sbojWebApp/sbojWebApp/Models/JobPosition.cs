using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }

        public DateTime? CreationDate { get; set; }
        public string? EmploymentRole { get; set; }
        public int? SalaryLow { get; set; }
        public int? SalaryHigh { get; set; }
        public int? ExperienceLow { get; set; }
        public int? ExperienceHigh { get; set; }
        public int? VacationDaysLow { get; set; }
        public int? VacationDaysHigh { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public ICollection<Language>? RequiredLanguages { get; set; }
        public ICollection<JobApplication>? Applications { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
