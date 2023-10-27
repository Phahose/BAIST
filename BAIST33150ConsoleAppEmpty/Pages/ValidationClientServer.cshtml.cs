using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST33150ConsoleAppEmpty.Pages
{
    public class ValidationClientServerModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        [BindProperty]
        public string InputField { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "** On Get **";
        }

        public void OnPost()
        {
            if (InputField == null || !(InputField.Length > 0 && InputField.Length <= 5))
            {
                ModelState.AddModelError("InputField", "Input Field Value is Invalid contain up to 5 charachters");
            }

            // check model state

            if (ModelState.IsValid)
            {
                Message = "OnPost is Valid";
            }
            else
            {
                Message = "Onpost is Invalid";
            }
        }
    }
}
