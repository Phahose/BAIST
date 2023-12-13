#nullable disable
using ABCHardWare.Domian;
using ABCHardWare.SalesManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ABCHardWare.Pages
{
    public class ProcessSaleModel : PageModel
    {
        [BindProperty]
        public string ItemCode { get; set; } = string.Empty;
        [BindProperty]
        public string Description { get; set; } = string.Empty;
        [BindProperty]
        public decimal UnitPrice { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        public string SaleId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        [BindProperty]
        public string Submit { get; set; } = string.Empty;
        [BindProperty]
        public int Deleted { get; set; }
        public int Price { get; set; }
        [BindProperty]
        public List<Item> SaleItems { get; set; } = new();
        public Item Item { get; set; } = new();
        public string SalesItemString { get; set; } = string.Empty;
        public void OnGet()
        {            
            Message = "Process A Sale";
        }


        public void OnPost()
        {
            ABCPOS aBCPOS = new ABCPOS();
            switch (Submit)
            {
                case "AddItem":
                    ModelState.Clear();
                    if (ItemCode == string.Empty)
                    {
                        ModelState.AddModelError("ItemCodeInput", "Please Enter a Valid ItemCode");
                    }
                  
                    if (ModelState.IsValid)
                    {
                        Item = aBCPOS.GetItem(ItemCode);

                        if (Item.Description == "")
                        {
                            Message = "This Item Dosent Exist - Check your Item Number ";
                        }
                        else
                        {
                            ItemCode = Item.ItemCode;
                            Description = Item.Description;
                            UnitPrice = Item.UnitPrice;
                            Deleted = Item.Deleted;

                            SalesItemString = string.Empty;
                            if (HttpContext.Session.GetString("SaleItems") != null)
                            {
                                SalesItemString = HttpContext.Session.GetString("SaleItems");
                                SaleItems = JsonSerializer.Deserialize<List<Item>>(SalesItemString);
                            }

                            SaleItems.Add(Item);
                            SalesItemString = JsonSerializer.Serialize(SaleItems);
                            HttpContext.Session.SetString("SaleItems", SalesItemString);
                            Message = $"Total Items {SaleItems.Count}";
                        }
                        
                        
                    }
                    else
                    {
                        Message = "Item Not Found Errors Found in the Form";
                    }

                    break;
                case "Delete":
                    SalesItemString = string.Empty;
                    if (HttpContext.Session.GetString("SaleItems") != null)
                    {
                        SalesItemString = HttpContext.Session.GetString("SaleItems");
                        SaleItems = JsonSerializer.Deserialize<List<Item>>(SalesItemString);
                    }

                    Item deletedItem = SaleItems.Where(x => x.ItemCode == ItemCode).FirstOrDefault();

                    SaleItems.Remove(deletedItem);
                    SalesItemString = JsonSerializer.Serialize(SaleItems);
                    HttpContext.Session.SetString("SaleItems", SalesItemString);   
                   
                    Message = "Item Removed";
                break;
            }
        }
    }
}
