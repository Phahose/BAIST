using ABCHardWare.Domian;
using ABCHardWare.SalesManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardWare.Pages
{
    public class UpdateItemModel : PageModel
    {
        [BindProperty]
        public int ItemCode { get; set; }
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
            Message = "Update Item";
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

                    break;
                case "UpdateItem":
                    Item updateditem = new Item()
                    {
                        ItemCode = ItemCode,
                        Description = Description,
                        UnitPrice = UnitPrice,
                        Deleted = Deleted
                    };
                    aBCPOS.UpdateItem(updateditem);
                break;
            }
           
        }
    }
}
