using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIRazorPagesAssignment.Pages
{
    public class SignUpModel : PageModel
    {
        public string FirstName { get; set; }  = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Program { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordConfirmed { get; set; } = string.Empty;

        public string Message {  get; set; } = string.Empty;    

        public void OnGet()
        {
            Message = "Page is Gotten";
        }
        public void OnPost()
        {
            Message = "Page has been Posted";
        }
    }
}
