using System.ComponentModel.DataAnnotations;

namespace sbojWebApp.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        [Url(ErrorMessage = "Please enter a valid Website URL")]
        public string Website { get; set; }
        [Url(ErrorMessage = "Please enter a valid LinkedIn URL")]
        public string LinkedIn { get; set; }
        [Url(ErrorMessage = "Please enter a valid Facebook URL")]
        public string Facebook { get; set; }
        [Url(ErrorMessage = "Please enter a valid Instagram URL")]
        public string Instagram { get; set; }
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }

        public ICollection<AppUser> Recruiters { get; set; } = new List<AppUser>();

    }

}
