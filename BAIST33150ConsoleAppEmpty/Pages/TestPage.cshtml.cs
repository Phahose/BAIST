using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST33150ConsoleAppEmpty.Pages
{
    public class TestPageModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        [BindProperty]
        public string Field { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "** OnGet **";
        }
        public void OnPost()
        {
            Message = "** OnPost **";
        }
    }
}
