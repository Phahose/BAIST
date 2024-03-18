using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhishingDemo.Controller;

namespace PhishingDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            BCS controlls = new BCS();
            controlls.AddUser(Email, Password);
        }
    }
}
