using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UIRazorPagesAssignment.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }  = string.Empty;
        [BindProperty]
        public string LastName { get; set; } = string.Empty;
        [BindProperty] 
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        public string Program { get; set; } = string.Empty;
        [BindProperty]
        public string UserID { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        [BindProperty]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Message {  get; set; } = string.Empty;    

        public void OnGet()
        {
            Message = "Page is Gotten";
        }
        public void OnPost()
        {
            string emailPattern = "^\\S+@\\S+\\.\\S+$";
            string usernamePattern = "^[A-Za-z]{4}\\[0-9]{4}$";
            Regex emailregex = new Regex(emailPattern);
            Regex userIDregex = new Regex(usernamePattern);
            Match emailMatch = emailregex.Match(emailPattern);
            Match userIDMatch = userIDregex.Match(usernamePattern);

            if (FirstName == null)
            {
                ModelState.AddModelError("FirstNameInput", "First Name is Required");
            }
            else if (LastName == null)
            {
                ModelState.AddModelError("LastNameInput", "Last Name is Required");
            }
            else if (Email == null)
            {
                ModelState.AddModelError("EmailInput", "Email is Required");
            }
            else if (!emailMatch.Success)
            {
                ModelState.AddModelError("EmailInput", "Valid Email is Required");
            }
            else if (UserID == null)
            {
                ModelState.AddModelError("UserNameInput", "UserID is Required");
            }
            else if (!userIDMatch.Success)
            {
                ModelState.AddModelError("UserNameInput", "Valid UserID is Required");
            }
            else if (Password == null)
            {
                ModelState.AddModelError("PasswordInput", "Password is Required");
            }
            else if (Password.Length < 6)
            {
                ModelState.AddModelError("PasswordInput", "Password must be at least 6 charcters");
            }
            else if (ConfirmPassword == null)
            {
                ModelState.AddModelError("ConfirmPasswordInput", "Must Confirm Password");
            }
            else if (ConfirmPassword != Password)
            {
                ModelState.AddModelError("ConfirmPasswordInput","Passwords Must Match");
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
