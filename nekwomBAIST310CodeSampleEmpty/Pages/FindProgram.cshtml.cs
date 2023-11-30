using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using nekwomBAIST310CodeSampleEmpty.Domain;
using nekwomBAIST310CodeSampleEmpty.TechnicalServices;
namespace nekwomBAIST310CodeSampleEmpty.Pages
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
            Message = "Find A Program";
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                BCS bcs = new BCS();
                Program =  bcs.FindProgram(ProgramCode);
            }
        }
    }
}
