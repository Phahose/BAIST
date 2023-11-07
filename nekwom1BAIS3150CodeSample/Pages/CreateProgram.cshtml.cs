using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwom1BAIS3150CodeSample.TechnicalServices;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace nekwom1BAIS3150CodeSample.Pages
{
    public class CreateProgramModel : PageModel
    {

        [BindProperty]
        [Required(ErrorMessage="Program Code is Required")]
        public string ProgramCode { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Description is Required")]
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
            /*else if (!programcodeRegex.Match(pCodePattern).Success)
            {
                ModelState.AddModelError("ProgramCode", "Must be Capital 4 Letter Text");
            }*/
            else if(Description == null)
            {
                ModelState.AddModelError("Description", "Description is Required");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Programs programs = new Programs();
                    try
                    {
                        programs.AddProgram(ProgramCode, Description);
                    }
                    catch (Exception ex)
                    {
                        ErrorList.Add(ex.Message);
                        Message = ex.Message;
                        Console.WriteLine(ex.Message);
                    }

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
