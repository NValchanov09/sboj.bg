using System.ComponentModel.DataAnnotations;

namespace sbojWebApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? Website { get; set; }
        public string? LinkedIn { get; set; }
        public string? Facebook { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ICollection<AppUser> Recruiters { get; set; }
    }

}
