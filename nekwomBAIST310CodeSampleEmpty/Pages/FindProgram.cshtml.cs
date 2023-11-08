using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using nekwomBAIS3150CodeSampleEmpty.Domain;
using nekwomBAIS3150CodeSampleEmpty.TechnicalServices;
namespace nekwomBAIS3150CodeSampleEmpty.Pages
{
    public class FindProgramModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage ="The Program Code is Required")]
        public string ProgramCode { get; set; } = string.Empty;
        public Domain.Program Program { get; set; } = new();
        public List<Domain.Program> ProgramList { get; set; } = new();
        public string Message { get; set; } = string.Empty;
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Programs programs = new Programs();
                Program = programs.GetProgram(ProgramCode);
            }
        }
    }
}
