using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
namespace BAIS3110InputValidation.Pages
{
    public class IndexModel : PageModel
    {
        public string NameResponse = string.Empty;

        public string MessageResponse = string.Empty;
        [BindProperty]
        public string UserName { get; set; } = string.Empty;
        [BindProperty]
        public string MessageText { get; set; } = string.Empty;
        public void OnPost()
        {
            // Name Textbox
            if (UserName != null)
            {
                string Name = UserName; // Grab the UserName from the Form
                Regex NameRegularExpression = new Regex(@"^[A-Za-z]{3,}$");
                if (NameRegularExpression.Match(Name).Success)
                {
                    NameResponse = Name;
                }         
                else
                {                               
                    NameResponse = "Name is too short";
                }
                
            }
            // MessageText Textarea
            if (MessageText != null)
            {
                MessageResponse = SanaitizeAndUnitizeText(MessageText);
            }
                
        }
        static string SanaitizeAndUnitizeText(string text)
        {
            string encodedText = HttpUtility.HtmlEncode(text);
            var tagMapping = new[]
            {
                new { Encoded = "&lt;b&gt;", HTML = "<b>" },
                new { Encoded = "&lt;/b&gt;", HTML = "</b>" },
                new { Encoded = "&lt;i&gt;", HTML = "<i>" },
                new { Encoded = "&lt;/i&gt;", HTML = "</i>" },
                new { Encoded = "&lt;u&gt;", HTML = "<u>" },
                new { Encoded = "&lt;/u&gt;", HTML = "</u>" }
            };

            foreach (var tag in tagMapping)
            {
                encodedText = encodedText.Replace(tag.Encoded, tag.HTML);
            }

            return encodedText;
        }
    }
}