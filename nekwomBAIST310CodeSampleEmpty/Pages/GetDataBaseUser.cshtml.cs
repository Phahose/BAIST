using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwomBAIST310CodeSampleEmpty.Domain;
using nekwomBAIST310CodeSampleEmpty.TechnicalServices;

namespace nekwomBAIST310CodeSampleEmpty.Pages
{
    public class GetDataBaseUserModel : PageModel
    {
        public required DatabserUser CurrentDatabaseuser { get; set; }
        public void OnGet()
        {
            BCS bcs = new BCS();
           CurrentDatabaseuser =  bcs.FindDatabaseuser();
        }
    }
}
