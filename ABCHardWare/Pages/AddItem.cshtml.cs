using ABCHardWare.Domian;
using ABCHardWare.SalesManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardWare.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public string ItemCode { get; set; } = string.Empty;
        [BindProperty]
        public string Description { get; set; } = string.Empty;
        [BindProperty]
        public decimal UnitPrice { get; set; }
        [BindProperty]
        public int Deleted { get; set; }
        public string Message { get; set; } = string.Empty;   
        public void OnGet()
        {
            Message = "Add New Item";
        }

        public void OnPost() 
        {
            ABCPOS aBCPOS = new ABCPOS();

            Item newItem = new Item()
            {
                ItemCode = ItemCode,
                Description = Description,
                UnitPrice = UnitPrice,
                Deleted = 1
            };

            aBCPOS.AddNewItem(newItem);

            Message = "Item has Been Added";
        }
    }
}
