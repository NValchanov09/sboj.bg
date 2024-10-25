using System.ComponentModel.DataAnnotations;

namespace sbojWebApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }

        [Url(ErrorMessage = "Please enter a valid Website URL")]
		[MaxLength(100)]
		public string? Website { get; set; }
        [Url(ErrorMessage = "Please enter a valid LinkedIn URL")]
		[MaxLength(100)]
		public string? LinkedIn { get; set; }
        [Url(ErrorMessage = "Please enter a valid Facebook URL")]
		[MaxLength(100)]
		public string? Facebook { get; set; }
        [Url(ErrorMessage = "Please enter a valid Instagram URL")]
		[MaxLength(100)]
		public string? Instagram { get; set; }
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

    }

}
