using sbojWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        [Required]
        [StringLength(1000, ErrorMessage = "The maximum length for the cover letter is 1000 characters.")]
        public string? CoverLetter { get; set; }

        [ForeignKey("JobPosition")]
        public int? JobPositionId { get; set; }
        public JobPosition? JobPosition { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        [Required]
        [StringLength(400, ErrorMessage = "The maximum length for the feedback is 400 characters.")]
        public string? Feedback { get; set; }
    }
}
