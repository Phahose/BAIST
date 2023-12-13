using ABCHardWare.Domian;
using ABCHardWare.SalesManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardWare.Pages
{
    public class DeleteCustomerModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        public string FirstName { get; set; } = string.Empty;
        [BindProperty]
        public string LastName { get; set; } = string.Empty;
        [BindProperty]
        public string Address { get; set; } = string.Empty;
        [BindProperty]
        public string City { get; set; } = string.Empty;
        [BindProperty]
        public string Province { get; set; } = string.Empty;
        [BindProperty]
        public string PostalCode { get; set; } = string.Empty;
        [BindProperty]
        public string Submit { get; set; } = string.Empty;
        [BindProperty]
        public int CustomerID { get; set; }
        public List<Customer> Customers { get; set; } = new();
        public void OnGet()
        {
            Message = "Delete A Customer";
        }

        public void OnPost()
        {
            ABCPOS aBCPOS = new ABCPOS();
            switch (Submit)
            {
                case "FindCustomer":
                    if (FirstName == null)
                    {
                        ModelState.AddModelError("FirstNameInput", "First Name is Required");
                    }
                    else if (LastName == null)
                    {
                        ModelState.AddModelError("LastNameInput", "Last Name is Required");
                    }

                    if (ModelState.IsValid)
                    {
                        Customers = aBCPOS.FindCustomer(FirstName, LastName);
                        if (Customers[0].FirstName == "")
                        {
                            Message = "This Customer Not Found Check The Name ";
                        }
                        else
                        {
                            FirstName = Customers[0].FirstName;
                            LastName = Customers[0].LastName;
                            Address = Customers[0].Address;
                            City = Customers[0].City;
                            Province = Customers[0].Province;
                            PostalCode = Customers[0].PostalCode;
                            CustomerID = Customers[0].CustomerID;

                            Message = "Customer Found Update Customer";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        Message = "Customer Could Not be Added";
                    }               
                    break;
                case "Delete":
                    aBCPOS.DeleteCustomer(CustomerID);
                    Message = "Customer Deleted Successfully";
                break;
            }
        }
    }
}
