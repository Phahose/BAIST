using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using ClubBAISTGolfClub.Controller;
using ClubBAISTGolfClub.Domain;
using ClubBAISTGolfClub.Techical_Services;

namespace ClubBAISTGolfClub.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = string.Empty;
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string AlertClass { get; set; } = string.Empty;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            AlertClass = "alert_error";
            MemberControlls bCS = new MemberControlls();
            Member existingMember = new();
            existingMember = bCS.GetMember(Email);

            // Convert DB Data Back to byte[] form because they werr stored in the DB as strings
            byte[] salt = Convert.FromBase64String(existingMember.MemberSalt);
            byte[] storedHashedpassword = Convert.FromBase64String(existingMember.MemberPassword);

            // Convert user Input to byte[] hash and then to strings
            byte[] enteredHashedPassword = HashPasswordWithSalt(Password, salt);
            string enteredHashedPasswordBase64 = Convert.ToBase64String(enteredHashedPassword);

            Password = enteredHashedPasswordBase64;

            string UserEmail = existingMember.MemberEmail;
            string UserPassword = existingMember.MemberPassword;
            string UserRole = existingMember.MembershipType;

            if (Email == UserEmail)
            {
                // Compare the Two arrays and not the Hashed Figures
                if (ByteArraysAreEqual(storedHashedpassword, enteredHashedPassword))
                {
                    Message = "Login Success";
                    return RedirectToPage("/MemberHome");
                }

            }
            Message = "Invalid attempt";
            return Page();
        }

        // Hashes the Enterd password with the same hashing algorithm that was used to Hash them into the DB
        private static byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            // Hash the password with PBKDF2 using HMACSHA256
            return new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256).GetBytes(32);
        }


        // Search Through all the values in the Byte Array to be sure that they match
        private bool ByteArraysAreEqual(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }
        
    }
}
