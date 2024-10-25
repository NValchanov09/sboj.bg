using System.ComponentModel.DataAnnotations;

namespace sbojWebApp.Models
{
    public class Company
    {
        public int Id { get; set; }
		[Required]
		[StringLength(30, ErrorMessage = "The maximum length for the name is 30 characters.")]
		public string? Name { get; set; }
		[Required]
		[StringLength(200, ErrorMessage = "The maximum length for the description is 200 characters.")]
		public string? Description { get; set; }
		[Required]
		public string? ImageURL { get; set; }

        [Url(ErrorMessage = "Please enter a valid Website URL")]
		[StringLength(100, ErrorMessage = "The maximum length for the Website URL is 100 characters.")]
		public string? Website { get; set; }
        [Url(ErrorMessage = "Please enter a valid LinkedIn URL")]
		[StringLength(100, ErrorMessage = "The maximum length for the Linkedin URL is 100 characters.")]
		public string? LinkedIn { get; set; }
        [Url(ErrorMessage = "Please enter a valid Facebook URL")]
		[StringLength(100, ErrorMessage = "The maximum length for the Facebook URL is 100 characters.")]
		public string? Facebook { get; set; }
        [Url(ErrorMessage = "Please enter a valid Instagram URL")]
		[StringLength(100, ErrorMessage = "The maximum length for the Instagram URL is 100 characters.")]
		public string? Instagram { get; set; }
        [Phone(ErrorMessage = "Please enter a valid phone number")]
		[StringLength(20, ErrorMessage = "The maximum length for the Phone Number is 20 characters.")]
		public string? PhoneNumber { get; set; }

    }

}
