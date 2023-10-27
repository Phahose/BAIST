using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIST33150ConsoleAppEmpty.Domain;

namespace BAIST33150ConsoleAppEmpty.Pages
{
    public class DynamicFormControlPageModel : PageModel
    {
        public string Message { get; set; } = string.Empty;
        public List<SampleClass> SampleObjectCollection { get; } = new();

        [BindProperty]
        public string AField { get; set; }  = string.Empty;

        [BindProperty]
        public string ACollection { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Welcome Johon Wick";

            SampleClass SampleObject = new();
            SampleObject = new()
            {
                FirstProperty = "1",
                SecondProperty = "One"
            };
            SampleObjectCollection.Add(SampleObject);
            SampleObject = new()
            {
                FirstProperty = "2",
                SecondProperty = "Two"
            };
            SampleObjectCollection.Add(SampleObject);
           SampleObject = new()
           {
                FirstProperty = "3",
                SecondProperty = "Three"
           };
           SampleObjectCollection.Add(SampleObject);        
        }

        public void OnPost()
        {
            Message = "Your Mission has Been Posted " + AField + " - " + ACollection;
        }
    }
}
