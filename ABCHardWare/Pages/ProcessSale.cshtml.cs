#nullable disable
using ABCHardWare.Domian;
using ABCHardWare.SalesManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
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
        public decimal Total { get; set; }
        public decimal GST { get; set; }
        [BindProperty]
        public List<Item> SaleItems { get; set; } = new();
        public Item Item { get; set; } = new();
        public string SalesItemString { get; set; } = string.Empty;
        [BindProperty]
        public string SelectedItem { get; set; }
        public List<SalesItem> ProcessedSalesItem { get; set; } = new();   
        public decimal ItemTotal { get; set; }
        public DateOnly SaleDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public TimeOnly SaleTime { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
        public List<Customer> CustomerList { get; set; } = new();
        [BindProperty]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public int SaleNumber { get; set; } = 123456789;
        public string SalesPerson { get; set; } = "Novak Djokovic";
        public void OnGet()
        {            
            ABCPOS aBCPOS = new ABCPOS();
            CustomerList = aBCPOS.GetAllCustomers(); 
            Message = "Process A Sale";
        }


        public void OnPost()
        {
            ABCPOS aBCPOS = new ABCPOS();
            switch (Submit)
            {
                case "AddItem":
                    ModelState.Clear();
                    Customer = new Customer();
                    CustomerList = aBCPOS.GetAllCustomers();
                    Customer = CustomerList.FirstOrDefault();
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
                            Item.Quantity = Quantity;
                            Item.Price = Item.UnitPrice * Item.Quantity;
                            ItemCode = Item.ItemCode;
                            Description = Item.Description;
                            UnitPrice = Item.UnitPrice;
                            Deleted = Item.Deleted;

                            SalesItemString = string.Empty;
                            bool exists = false;
                            if (HttpContext.Session.GetString("SaleItems") != null)
                            {
                                SalesItemString = HttpContext.Session.GetString("SaleItems");
                                SaleItems = JsonSerializer.Deserialize<List<Item>>(SalesItemString);
                            }

                            if (SaleItems.Count > 0)
                            {
                                exists = SaleItems.Any(x => x.ItemCode == ItemCode);
                            }
                            if (exists == false)
                            {
                                SaleItems.Add(Item);
                            }
                            else
                            {
                                SaleItems.Where(x => x.ItemCode == ItemCode).First().Quantity += Quantity;
                                SaleItems.Where(x => x.ItemCode == ItemCode).First().Price = SaleItems.Where(x => x.ItemCode == ItemCode).First().UnitPrice * SaleItems.Where(x => x.ItemCode == ItemCode).First().Quantity;
                            }

                            
                            Item.ItemTotal = SaleItems.Sum(SaleItems => SaleItems.Price);
                            GST = (Item.ItemTotal * 0.05m);
                            Total = GST + Item.ItemTotal;
                            Total = Math.Round(Total, 2);
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

                    Item deletedItem = SaleItems.Where(x => x.ItemCode == SelectedItem).FirstOrDefault();

                    SaleItems.Remove(deletedItem);
                    SalesItemString = JsonSerializer.Serialize(SaleItems);
                    HttpContext.Session.SetString("SaleItems", SalesItemString);   
                   
                    Message = "Item Removed";
                break;
                case "ProcessSale":
                    CustomerList = aBCPOS.GetAllCustomers();
                    Customer = CustomerList.FirstOrDefault();
                    Random random = new Random();
                    SaleNumber = random.Next(100000000, 999999999);
                    SalesItemString = string.Empty;
                    if (HttpContext.Session.GetString("SaleItems") != null)
                    {
                        SalesItemString = HttpContext.Session.GetString("SaleItems");
                        SaleItems = JsonSerializer.Deserialize<List<Item>>(SalesItemString);
                    }
                    
                    foreach (Item item in SaleItems)
                    {
                        SalesItem SalesItem = new()
                        {
                            SaleNumber = SaleNumber,
                            ItemCode = item.ItemCode,
                            Quantity = item.Quantity,
                            ItemTotal = item.ItemTotal,
                        };
                        ProcessedSalesItem.Add(SalesItem);
                    }

                    Item.ItemTotal = SaleItems.Sum(SaleItems => SaleItems.Price);
                    GST = (Item.ItemTotal * 0.05m);
                    Total = GST + Item.ItemTotal;
                    Total = Math.Round(Total, 2);

                    Sale processedSale = new()
                    {
                        SaleNumber = SaleNumber,
                        SaleDate = SaleDate,
                        SalesPerson = SalesPerson,
                        FirstName = Customer.FirstName,
                        LastName = Customer.LastName,
                        SubTotal = Item.ItemTotal,
                        GST = GST,
                        SaleTotal = Total,
                        SalesItems = ProcessedSalesItem
                    };
             
                    aBCPOS.AddSaleItem(ProcessedSalesItem);
                    int saleNo = aBCPOS.ProcessSale(processedSale);
                    Message = $"Sale Has Been Processed {saleNo}";
                    break;
            }
        }
    }
}
