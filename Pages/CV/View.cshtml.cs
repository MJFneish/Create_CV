using cv_web_application.Data;
using cv_web_application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace cv_web_application.Pages.CV
{
    public class ViewModel : PageModel
    {
        public CVModelDB CV { get; set; }
        private readonly DB DB;

        public ViewModel(DB DB)
        {
            this.DB = DB;
        }
        public void OnGet(int Id)
        {
            this.CV = DB.CVs.FirstOrDefault(x => x.Id == Id);
        }
    }
}
