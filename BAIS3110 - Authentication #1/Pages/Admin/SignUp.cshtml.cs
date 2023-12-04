using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3110___Authentication__1.Domain;
using BAIS3110___Authentication__1.Controller;

namespace BAIS3110___Authentication__1.Pages.Admin
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Role { get; set; }
        [BindProperty]
        public string Email { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Add user";
        }
        public void OnPost()
        {
            BCS bCS = new BCS();

            User newUser = new()
            {
                Username = Username,
                Password = Password,
                Role = Role,
                Email = Email
            };
            bCS.AddUser(newUser);
            Message = "User Added SuccessFully";
        }
    }
}
