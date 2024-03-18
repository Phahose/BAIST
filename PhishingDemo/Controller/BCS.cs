using Microsoft.AspNetCore.Identity;
using PhishingDemo.TechnicalService;

namespace PhishingDemo.Controller
{
    public class BCS
    {
        public bool AddUser(string email, string password)
        {
            bool success = false;
            UserServices userManager = new();
            success = userManager.AddUser(email, password);
            return success;
        }
    }
}
