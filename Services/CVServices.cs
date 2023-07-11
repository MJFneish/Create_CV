using cv_web_application.Data;
using cv_web_application.Models;
using System;

namespace cv_web_application.Services
{
    public class CVServices
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _Logger;
        private DB DB;

        public CVServices(IHttpContextAccessor httpContextAccessor, ILoggerFactory factory, DB DB)
        {
            _httpContextAccessor = httpContextAccessor;
            _Logger = factory.CreateLogger<CVServices>();
            DB = DB;
        }

        public void AddPhoto(CVModel CVModel, CVModelDB CV)
        {
            var file = CVModel.Photo;
            var fileName = DateTimeOffset.UtcNow.Ticks + "_" + file.FileName;
            fileName = fileName.Replace(" ", "_");
            String filePath = "wwwroot/Images/" + fileName;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (CVModel.Photo != null)
            {
                CV.Photo = $"~/Images/{fileName}";
            }
        }
        public void AddSkills(CVModel CVModel, CVModelDB CV)
        {
            HttpRequest request = _httpContextAccessor.HttpContext.Request;
            foreach (var skills in CVModel.SkillsDictionary.Keys)
            {
                bool isChecked = request.Form.ContainsKey($"SkillsDictionary[{skills}]") && request.Form[$"SkillsDictionary[{skills}]"] == "on";
                CVModel.SkillsDictionary[skills] = isChecked;
            }
            var skill = CVModel.SkillsDictionary.Where(x => x.Value).Select(x => x.Key).ToList();
            CV.Skills = string.Join(", ", skill);
        }

        internal List<string> ValidateCVModel(CVModel CVModel, CVModelDB CV)
        {
            List<string> errors = new List<string>();

            if (CV.Email != CVModel.ConfirmEmail)
            {
                errors.Add("The email and the confirm email should be the same");
            }

            if ((CVModel.Verification.Nbr1 + CVModel.Verification.Nbr2) != CVModel.Verification.Nbr3)
            {
                errors.Add("nb1 + nb2 should equal to nb3");
            }

            if (CVModel.Photo == null || CVModel.Photo.Length < 0 || CVModel.Photo.Length > 4096000)
            {
                errors.Add("Please enter a photo or enter a photo less than 4MB");
            }

            try
            {
                if (CVModel.Photo != null && CVModel.Photo.ContentType != null && !CVModel.Photo.ContentType.StartsWith("image/"))
                {
                    errors.Add("Please enter an image, not anything else");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return errors;
        }

        public Dictionary<string, bool> ConvertSkillsStringToDictionary(string skills, Dictionary<string, bool> oldDictionary)
        {
            // Create an empty dictionary
            var skillsDictionary = oldDictionary;

            // Split the skills string by comma
            var skillItems = skills.Split(", ");

            foreach (var item in skillItems)
            {
                // Add the item to the dictionary with a default value of true
                skillsDictionary[item] = true;
            }

            return skillsDictionary;
        }

    }
}
