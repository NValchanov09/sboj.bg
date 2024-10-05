using System.ComponentModel.DataAnnotations.Schema;

namespace sbojWebApp.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public CoverLetter? CoverLetter { get; set; }

        [ForeignKey("JobPosition")]
        public int? JobPositionId { get; set; }
        public JobPosition? JobPosition { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public bool? Status { get; set; } // True = Application has been reviewed, False = Application has not been reviewed
    }
}
