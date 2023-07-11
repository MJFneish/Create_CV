using cv_web_application.Data;
using cv_web_application.Models;
using cv_web_application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cv_web_application.Pages.CV
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public CVModel CVModel { get; set; }
        [BindProperty]
        public CVModelDB CV { get; set; }
        public DB DB { get; set; }
        public CVServices Services { get; set; }


        public EditModel(DB db, CVServices c)
        {
            CV = new CVModelDB();
            CVModel = new CVModel();
            Services = c;
            DB = db;
        }
        public void OnGet(int Id)
        {
            CVModelDB cv = DB.CVs.FirstOrDefault(x => x.Id == Id);
            if(cv == null)
            {
                RedirectToPage("Index");
            }
            CV = cv;
            CVModel.ConfirmEmail = CV.Email;
            CVModel.SkillsDictionary = Services.ConvertSkillsStringToDictionary(CV.Skills, CVModel.SkillsDictionary);
        }

        public IActionResult OnPost(int Id)
        {
            List<string> errors = Services.ValidateCVModel(CVModel, CV);

            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            CV.Id = Id;
            if (ModelState.IsValid)
            {
                Services.AddSkills(CVModel, CV);
                Services.AddPhoto(CVModel, CV);
                DB.CVs.Update(CV);
                DB.SaveChanges();
                return RedirectToPage("Index");
            }

            CVModelDB cv = DB.CVs.FirstOrDefault(x => x.Id == Id);
            CV = cv;
            CVModel.ConfirmEmail = CV.Email;
            CVModel.SkillsDictionary = Services.ConvertSkillsStringToDictionary(CV.Skills, CVModel.SkillsDictionary);

            return Page();
        }
    }
}
