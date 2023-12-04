using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecutityBreachLoginForm.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        private string UserName { get; set; } = string.Empty;
        [BindProperty]
        private string Password { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Message = "Are You sure you wanna Put Your stuff here";
        }
        public void OnPost() 
        {
            Message = "Posted and You Might have beeb Hacked";
        }
    }
}