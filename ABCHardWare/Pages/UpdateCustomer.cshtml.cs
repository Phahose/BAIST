using ABCHardWare.Domian;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

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
        public List<Customer> Customers { get; set; } = new();
        public string CustomerString { get; set; } = string.Empty;
        [BindProperty]
        public int SelectedCustomer {  get; set; }

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
                    ModelState.Clear();
                    HttpContext.Session.Clear();
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
                        Customers = aBCPOS.FindCustomer(FirstName!, LastName!);

                        if (Customers.Count == 0)
                        {
                            Message = "This Customer Not Found Check The Name ";
                        }
                        CustomerString = string.Empty;
                        if (HttpContext.Session.GetString("Customers") != null)
                        {
                            CustomerString = HttpContext.Session.GetString("Customers")!;
                            Customers = JsonSerializer.Deserialize<List<Customer>>(CustomerString)!;
                        }
                        CustomerString = JsonSerializer.Serialize(Customers);
                        HttpContext.Session.SetString("Customers", CustomerString);
                    }
                    else
                    {
                        Message = "The Customer Could not be Found Errors In the Form";
                    }
                    
                    break;
                case "Select":
                    CustomerString = string.Empty;
                    if (HttpContext.Session.GetString("Customers") != null)
                    {
                        CustomerString = HttpContext.Session.GetString("Customers")!;
                        Customers = JsonSerializer.Deserialize<List<Customer>>(CustomerString)!;
                    }

                    Customer selectedCustomer = new Customer();
                    selectedCustomer =  Customers.Where(x => x.CustomerID == SelectedCustomer).FirstOrDefault()!;

                    if (selectedCustomer != null)
                    {
                        FirstName = selectedCustomer.FirstName;
                        LastName = selectedCustomer.LastName;
                        Address = selectedCustomer.Address;
                        City = selectedCustomer.City;
                        Province = selectedCustomer.Province;
                        PostalCode = selectedCustomer.PostalCode;
                        CustomerID = selectedCustomer.CustomerID;

                        Message = "Customer Found Update Customer";
                        ModelState.Clear();
                    }  
                    break;
                case "UpdateCustomer":
                    ModelState.Clear();
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

                    CustomerString = string.Empty;
                    if (HttpContext.Session.GetString("Customers") != null)
                    {
                        CustomerString = HttpContext.Session.GetString("Customers")!;
                        Customers = JsonSerializer.Deserialize<List<Customer>>(CustomerString)!;
                    }

                    Customer newselectedCustomer = new Customer();
                    newselectedCustomer = Customers.Where(x => x.CustomerID == SelectedCustomer).FirstOrDefault()!;

                    if (ModelState.IsValid)
                    {
                        newselectedCustomer = new Customer()
                        {
                            FirstName = FirstName,
                            LastName = LastName,
                            Address = Address!,
                            City = City!,
                            Province = Province!,
                            PostalCode = PostalCode!,
                            CustomerID = CustomerID!,
                        };
                        aBCPOS.UpdateCustomer(newselectedCustomer);
                        Message = "Customer Updated Successfully";
                        HttpContext.Session.Clear();
                        Customers.Clear();
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
