using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cv_web_application.Models
{
    public class CVModel
    {
        [Required]
        [Display(Name = "SKILLS")]
        public Dictionary<string, bool> SkillsDictionary { get; set; } = new Dictionary<string, bool>()
        {
            { "JAVA", false },
            { "PYTHON", false },
            { "ASP.CORE", false }
        };

        [Required]
        [Display(Name = "CONFIRM EMAIL")]
        [EmailAddress]
        public string ConfirmEmail { get; set; } = "";
        
        [Required]
        [Display(Name = "IMAGE")]
        public IFormFile? Photo { get; set; }

        [Required]
        [Display(Name = "Verification Number")]
        public VerficationNumber Verification { get; set; } = new VerficationNumber();
    }
}
