using Microsoft.AspNetCore.Mvc.Rendering;

namespace cv_web_application.Models
{
    public static class Countries
    {
        public static List<SelectListItem> CountryList { get; set; } = new List<SelectListItem>() {
            new SelectListItem { Text = "Sirya", Value = "Sirya" },
            new SelectListItem { Text = "Lebanon", Value = "Lebanon" },
            new SelectListItem { Text = "England", Value = "England" },
            new SelectListItem { Text = "Egypt", Value = "Egypt" },
            new SelectListItem { Text = "USA", Value = "USA" },
            new SelectListItem { Text = "India", Value = "India" },
            new SelectListItem { Text = "Saudi Arabia", Value = "Saudi Arabia" },
            new SelectListItem { Text = "bate5a", Value = "bate5a" },
        };

    }
}
