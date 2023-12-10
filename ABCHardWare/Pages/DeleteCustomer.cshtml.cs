using ABCHardWare.Domian;
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
                        Customer customer = aBCPOS.FindCustomer(FirstName, LastName);
                        if (customer.FirstName == "")
                        {
                            Message = "This Customer Not Found Check The Name ";
                            FirstName = "";
                            LastName = "";
                        }
                        else
                        {
                            FirstName = customer.FirstName;
                            LastName = customer.LastName;
                            Address = customer.Address;
                            City = customer.City;
                            Province = customer.Province;
                            PostalCode = customer.PostalCode;
                            CustomerID = customer.CustomerID;

                            Message = "Customer Found Update Customer";
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
