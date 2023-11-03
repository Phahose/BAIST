using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace UIRazorPagesAssignment.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage ="User Name is Required")]
        [StringLength(8)]
        [RegularExpression(@"[A-Za-z]{4}[0-9]{4}$",
            ErrorMessage = "Your UserID Must be 4 letters followed by 4 digits (e.g. BAIS9999")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required (ErrorMessage ="Password Value is Required")]
        [StringLength(6)]
        [MinLength(6, ErrorMessage ="Must Be at least 6 Characters")]
        public string Password { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Sign In Complete";
            }
           
        }
    }
}
