using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BAIST33150ConsoleAppEmpty.Pages
{
    public class ValidationDDAModelModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        [StringLength(5, MinimumLength = 1)]
        public string InputField { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Welcome Bomboclattt";
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Congratulation Mi Bloodclat You Afi put di right bloodclat value";
            }
            else
            {
                Message = "Nono Broda Why you not put the Right Value Fo di place man";
            }
        }
    }
}
