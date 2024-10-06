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

        [ForeignKey("CoverLetter")]
        public int? CoverLetterId { get; set; }
        public CoverLetter? CoverLetter { get; set; }

        [ForeignKey("JobPosition")]
        public int? JobPositionId { get; set; }
        public JobPosition? JobPosition { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public string? Feedback { get; set; }
    }
}
