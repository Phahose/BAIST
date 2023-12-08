using ABCHardWare.Domian;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardWare.Pages
{
    public class DeleteItemModel : PageModel
    {
        [BindProperty]
        public string ItemCode { get; set; } = string.Empty;
        [BindProperty]
        public string Description { get; set; } = string.Empty;
        [BindProperty]
        public decimal UnitPrice { get; set; }
        [BindProperty]
        public int Deleted { get; set; }
        [BindProperty]
        public string Submit { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Find Then Delete an Item";
        }

        public void OnPost()
        {
            ABCPOS aBCPOS = new ABCPOS();
            switch (Submit)
            {
                case "FindItem":

                    Item item = aBCPOS.GetItem(ItemCode);

                    if (item.Description == "")
                    {
                        Message = "This Item Dosent Exist - Check your Item Number ";
                    }
                    else
                    {
                        ItemCode = item.ItemCode;
                        Description = item.Description;
                        UnitPrice = item.UnitPrice;
                        Deleted = item.Deleted;
                    }
                    Message = "Item Found Do you Still Wish To Delete";
                    break;
                case "DeleteItem":
                    aBCPOS.DeleteItem(ItemCode);
                    Message = "Item Has been Deleted Successfully";
                 break;
            }

        }
    }
}
