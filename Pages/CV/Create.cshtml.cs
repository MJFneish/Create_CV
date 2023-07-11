using cv_web_application.Data;
using cv_web_application.Models;
using cv_web_application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cv_web_application.Pages.CV
{
    public class Create : PageModel
    {
        [BindProperty]
        public CVModel CVModel { get; set; }
        [BindProperty]
        public CVModelDB CV { get; set; }
        public DB DB { get; set; }
        public CVServices Services { get; set; }


        public Create(DB db, CVServices c)
        {
            CV = new CVModelDB();
            CVModel = new CVModel();
            Services = c;
            DB = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            List<string> errors = Services.ValidateCVModel(CVModel, CV);

            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            if (ModelState.IsValid)
            {
                Services.AddSkills(CVModel, CV);
                Services.AddPhoto(CVModel, CV);
                DB.CVs.Add(CV);
                DB.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
