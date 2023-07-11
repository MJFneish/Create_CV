using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cv_web_application.Models
{
    public class CVModelDB
    {
        [Key] 
        public int Id { get; set; }

        [Display(Name = "FIRST NAME"), Required]
        public string FirstName { get; set; } = "";

        [Required]
        [Display(Name = "Last NAME")]
        public string LastName { get; set; } = "";

        [Required]
        [Display(Name = "BIRTHDAY")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "2002-03-22", ApplyFormatInEditMode = true)]
        public DateTime BDay { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; } = "";

        [Required]
        [Display(Name = "GENDER")]
        public string Gender { get; set; } = "Male";

        [Required]
        [Display(Name = "EMAIL")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [Display(Name = "PASSWORD")]
        [PasswordPropertyText]
        public string Password { get; set; } = "";

        public string Photo { get; set; } = "";

        public string? Skills { get; set; } = "";
    }
}
