using ABCHardWare.Domian;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardWare.Pages
{
    public class UpdateCustomerModel : PageModel
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
            Message = "Update A Customer";
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
                        ModelState.AddModelError("LastNameInput", "Last NAme is Required");
                    }

                    if (ModelState.IsValid)
                    {
                        Customer customer = aBCPOS.FindCustomer(FirstName, LastName);
                        if (customer.FirstName == "")
                        {
                            Message = "This Customer Not Found Check The Name ";
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
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        Message = "The Customer Could not be Found Errors In the Form";
                    }
                    
                    break;
                case "UpdateCustomer":
                    if (Address == null)
                    {
                        ModelState.AddModelError("AddressInput", "Address is Required");
                    }
                    else if (City == null)
                    {
                        ModelState.AddModelError("CityInput", "The City is Required");
                    }
                    else if (Province == null)
                    {
                        ModelState.AddModelError("ProvinceInput", "Province is Required");
                    }
                    else if (PostalCode == null)
                    {
                        ModelState.AddModelError("PostalCodeInput", "PostalCode is Required");
                    }

                    if (ModelState.IsValid)
                    {
                        Customer newCustomer = new Customer()
                        {
                            FirstName = FirstName,
                            LastName = LastName,
                            Address = Address,
                            City = City,
                            Province = Province,
                            PostalCode = PostalCode,
                            CustomerID = CustomerID,
                        };
                        aBCPOS.UpdateCustomer(newCustomer);
                        Message = "Customer Updated Successfully";
                    }
                    else
                    {
                        Message = "Customer Could Not be updated Errors In the Form";
                    }
                    
                break;
            }
        }
    }
}
