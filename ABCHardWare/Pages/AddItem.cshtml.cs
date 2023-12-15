using ABCHardWare.Domian;
using ABCHardWare.SalesManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ABCHardWare.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        [RegularExpression("[A-Za-z][0-9]{5}", ErrorMessage = "Item Code must start with a letter and be followed by five numbers")]
        public string ItemCode { get; set; } = string.Empty;
        [BindProperty]
        public string Description { get; set; } = string.Empty;
        [BindProperty]
        public decimal UnitPrice { get; set; }
        [BindProperty]
        public int QOH { get; set; }
        [BindProperty]
        public int Deleted { get; set; }
        public string Message { get; set; } = string.Empty;   
        public void OnGet()
        {
            Message = "Add New Item";
        }

        public void OnPost() 
        {
            bool success = true;
            if(Description == null)
            {
                ModelState.AddModelError("DescriptionInput", "Description is Required");
            }
            else if(UnitPrice == 0)
            {
                ModelState.AddModelError("UnitPriceInput", "Unit Price is Required");
            }
            else if(ItemCode == string.Empty)
            {
                ModelState.AddModelError("ItemCodeInput", "ItemCode is Required");
            }
            else if(QOH == 0)
            {
                ModelState.AddModelError("QOHInput", "Must Have At Least One Item To Add");
            }

            if (ModelState.IsValid)
            {
                ABCPOS aBCPOS = new ABCPOS();

                Item newItem = new Item()
                {
                    ItemCode = ItemCode,
                    Description = Description,
                    UnitPrice = UnitPrice,
                    QOH = QOH,
                    Deleted = 1
                };

                success =  aBCPOS.AddNewItem(newItem);

                if (success == true)
                {
                    Message = "Item has Been Added";
                }
                else
                {
                    Message = "Item Could Not Be Added This ItemCode Already exists";
                }
                
            }
            else
            {
                Message = "Item Cannot Be added Errors Found In the Form";
            }
            
        }
    }
}
