using sbojWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;

        [ForeignKey("CoverLetter")]
        public int? CoverLetterId { get; set; }
        public CoverLetter CoverLetter { get; set; }

        [ForeignKey("JobPosition")]
        [Required]
        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }

        [ForeignKey("AppUser")]
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string Feedback { get; set; }
    }
}
