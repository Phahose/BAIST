using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace nekwomBAIST310CodeSampleEmpty.Pages
{
    public class SessionSampleModel : PageModel
    {
        public string Messsage { get; set; } = string.Empty;

        public void OnGet()
        {
            // set the initial Value 
            HttpContext.Session.SetInt32("ValueKey",0); // session GetString, SetString, GetInt32, SetInt32 methods
            
            // get initial value
            int Value = (int)HttpContext.Session.GetInt32("ValueKey")!;

            Messsage = Value.ToString();
        }
        public void OnPost() 
        {
            // get Value
            int Value = (int)HttpContext.Session.GetInt32("ValueKey")!;

            Value++;

            //set new value
            HttpContext.Session.SetInt32("ValueKey", Value);

            Messsage = Value.ToString();
        }
    }
}
