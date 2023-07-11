using cv_web_application.Data;
using cv_web_application.Models;
using cv_web_application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webpplication1.Pages.CV
{
    public class IndexModel : PageModel
    {
        public DB DB { get; set; }
        public CVServices Services { get; set; }
        public List<CVModelDB> CVs { get; set; } = new List<CVModelDB>();

        public IndexModel(DB db, CVServices c)
        {
            Services = c;
            DB = db;
        }

        public void OnGet()
        {
            CVs = DB.CVs.ToList();
        }

        public void OnGetDelete(int Id)
        {
            CVModelDB cv = DB.CVs.FirstOrDefault(x => x.Id == Id);
            if(cv != null)
            {
                DB.CVs.Remove(cv);
                DB.SaveChanges();
            }
            CVs = DB.CVs.ToList();
        }
    }
}
