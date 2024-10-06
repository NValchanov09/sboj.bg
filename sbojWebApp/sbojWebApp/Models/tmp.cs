using Microsoft.AspNetCore.Identity;
using sbojWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class JobPosition
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        public DateTime? CreationDate { get; set; }
        public string? EmploymentRole { get; set; }

        public int? SalaryLow { get; set; }
        public int? SalaryHigh { get; set; }

        public int? ExperienceLow { get; set; }
        public int? ExperienceHigh { get; set; }

        public int? VacationDaysLow { get; set; }
        public int? VacationDaysHigh { get; set; }

        public ICollection<Language>? RequiredLanguages { get; set; }
        public ICollection<JobApplication>? Applications { get; set; }

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

    public class JobApplication
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }
        public ApplicationStatus Status { get; set; }

        [ForeignKey("CoverLetter")]
        public int? CoverLetterId { get; set; }
        public CoverLetter? CoverLetter { get; set; }

        [ForeignKey("JobPosition")]
        public int? JobPositionId { get; set; }
        public JobPosition? JobPosition { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }

        public string? Website { get; set; }
        public string? LinkedIn { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<AppUser>? Recruiters { get; set; }

    }

    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? ProfileImagePath { get; set; }
        public DateTime? CreationDate { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public ICollection<JobApplication>? AppliedFor { get; set; }
        public ICollection<JobPosition>? Added { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class Language
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }
    }

    public class CoverLetter
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public string? Conclusion { get; set; }
    }
}
