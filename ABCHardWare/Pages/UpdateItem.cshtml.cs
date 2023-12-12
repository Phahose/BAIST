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
                    ModelState.Clear();
                    if (ItemCode == 0)
                    {
                        ModelState.AddModelError("DescriptionInput", "Description is Required");
                    }
                    if (ModelState.IsValid)
                    {
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
                    }
                    else
                    {
                        Message = "Item not Found Errors in the Form";
                    }
                    
                    break;
                case "UpdateItem":
                    if (Description == null)
                    {
                        ModelState.AddModelError("DescriptionInput", "Description is Required");
                    }
                    else if (UnitPrice == 0)
                    {
                        ModelState.AddModelError("UnitPriceInput", "Unit Price is Required");
                    }

                    if (ModelState.IsValid)
                    {
                        Item updateditem = new Item()
                        {
                            ItemCode = ItemCode,
                            Description = Description,
                            UnitPrice = UnitPrice,
                            Deleted = Deleted
                        };
                        aBCPOS.UpdateItem(updateditem);
                        Message = "Update successfull";
                    }
                    else
                    {
                        Message = "Update Not Successfull Errors in the Form";
                    }           
                break;
            }
           
        }
    }
}
