using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwomBAIST310CodeSampleEmpty.TechnicalServices;
using nekwomBAIST310CodeSampleEmpty.Domain;
using System.Text.RegularExpressions;

namespace nekwomBAIST310CodeSampleEmpty.Pages
{
    public class CreateProgramModel : PageModel
    {

        [BindProperty]
       
        public string ProgramCode { get; set; } = string.Empty;
        [BindProperty]
       
        public string Description { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        List<string> ErrorList { get; set; } = new List<string>();
        public void OnGet()
        {
            Message = "Add a Program";
        }

        public void OnPost() 
        {
            string pCodePattern = @"\b[A-Z]{4}\b";
            Regex programcodeRegex = new Regex(pCodePattern);
            if (ProgramCode == null)
            {
                ModelState.AddModelError("ProgramCode", "Program Code is Required");
            }
           
            else if(Description == null)
            {
                ModelState.AddModelError("Description", "Description is Required");
            }
            else
            {
                if (ModelState.IsValid)
                {

                    BCS bCS = new();
                    bCS.CreateProgram(ProgramCode, Description);
                   
                    Message = $"Program has been Added {ProgramCode} {Description}";
                }
                else
                {
                    Message = $"Program has been Added {ProgramCode} {Description}";
                }
            }
        }
    }
}
