using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace UIRazorPagesAssignment.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }  = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/",
            ErrorMessage = "Enter A valid Email")]
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        public string Program { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "User Name is Required")]
        [StringLength(8)]
        [RegularExpression(@"[A-Za-z]{4}[0-9]{4}$",
            ErrorMessage = "Your UserID Must be 4 letters followed by 4 digits (e.g. BAIS9999")]
        public string UserID { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Password Value is Required")]
        [StringLength(6)]
        [MinLength(6, ErrorMessage = "Must Be at least 6 Characters")]
        public string Password { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Must Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Message {  get; set; } = string.Empty;    

        public void OnGet()
        {
            Message = "Page is Gotten";
        }
        public void OnPost()
        {
            if (ConfirmPassword != Password)
            {
                ModelState.AddModelError("PasswordField","Passwords Must Match");
            }

            if (ModelState.IsValid)
            {
                Message = "Page has been Posted";
            }
            else
            {
                Message = "Page Cannot be Posted";
            }
            
        }
    }
}
