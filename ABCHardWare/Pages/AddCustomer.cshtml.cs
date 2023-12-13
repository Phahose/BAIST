using ABCHardWare.Domian;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardWare.Pages
{
    public class AddCustomerModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        public string FirstName { get; set; } = string.Empty;
        [BindProperty]
        public string LastName { get; set; } = string.Empty;
        [BindProperty]
        public string Address {  get; set; } = string.Empty;
        [BindProperty]
        public string City { get; set; }= string.Empty;
        [BindProperty]
        public string Province { get; set; } = string.Empty;
        [BindProperty]
        public string PostalCode { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Add A Customer";
        }

        public void OnPost()
        {
            ModelState.Clear();
            if (FirstName == null)
            {
                ModelState.AddModelError("FirstNameInput","First Name is Required");
            }
            else if (LastName == null)
            {
                ModelState.AddModelError("LastNameInput", "Last NAme is Required");
            }
            else if(Address == null) {
                ModelState.AddModelError("AddressInput", "Address is Required");
            }
            else if (City == null) 
            {
                ModelState.AddModelError("CityInput", "The City is Required");
            }
            else if(Province == null)
            {
                ModelState.AddModelError("ProvinceInput", "Province is Required");
            }
            else if (PostalCode == null)
            {
                ModelState.AddModelError("PostalCodeInput", "PostalCode is Required");
            }

            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Address = Address,
                    City = City,
                    Province = Province,
                    PostalCode = PostalCode
                };
                ABCPOS aBCPOS = new ABCPOS();
                aBCPOS.AddCustomer(customer);
                Message = "Customer Added SuccessFully";
            }
            else
            {
                Message = "The Customer Cannot Be Added Errors Found";
            }
            
        }
    }
}
