using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST33150ConsoleAppEmpty.Pages
{
    public class MultiplePostModel : PageModel
    {
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        public string FirstInputField { get; set; } = string.Empty;
        [BindProperty]
        public string SecondInputField {  get; set; } = string.Empty;
        [BindProperty]
        public string Submit {  get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Dis ya blodclat Message bobmoclat and e tel u dat on geat afi do";
        }
        public void OnPost()
        { 
            switch(Submit)
            {
                case "First":
                    Message = "The First Buton A fi click ediat";
                break;
                case "Second":
                    Message = "The Second One na click fo di blodclat place";
                break;
            }
        }
    }
}
