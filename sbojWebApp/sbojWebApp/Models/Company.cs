using System.ComponentModel.DataAnnotations;

namespace sbojWebApp.Models
{
    public class Company
    {
        public int Id { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "The maximum length for the name is 50 characters.")]
		public string? Name { get; set; }
		[Required]
		[StringLength(500, ErrorMessage = "The maximum length for the description is 500 characters.")]
		public string? Description { get; set; }
        [Required]
        [StringLength(2048, ErrorMessage = "The maximum length for the URL is 2048 characters.")]
        public string? ImageURL { get; set; }

        [Url(ErrorMessage = "Please enter a valid Website URL")]
		[StringLength(150, ErrorMessage = "The maximum length for the Website URL is 150 characters.")]
		public string? Website { get; set; }
        [Url(ErrorMessage = "Please enter a valid LinkedIn URL")]
		[StringLength(150, ErrorMessage = "The maximum length for the Linkedin URL is 150 characters.")]
		public string? LinkedIn { get; set; }
        [Url(ErrorMessage = "Please enter a valid Facebook URL")]
		[StringLength(150, ErrorMessage = "The maximum length for the Facebook URL is 150 characters.")]
		public string? Facebook { get; set; }
        [Url(ErrorMessage = "Please enter a valid Instagram URL")]
		[StringLength(150, ErrorMessage = "The maximum length for the Instagram URL is 150 characters.")]
		public string? Instagram { get; set; }
        [Phone(ErrorMessage = "Please enter a valid phone number")]
		[StringLength(30, ErrorMessage = "The maximum length for the Phone Number is 30 characters.")]
		public string? PhoneNumber { get; set; }

    }

}
