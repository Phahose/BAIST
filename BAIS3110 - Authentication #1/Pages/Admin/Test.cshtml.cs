using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System;
using System.ComponentModel.DataAnnotations;

namespace BAIS3110Authentication.Pages
{
    public class TestModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            // Use the logic from your RegisterModel to check user credentials
            if (CheckUserCredentials(Email, Password))
            {
                // Authentication successful
                // You can add claims, set authentication cookies, etc.
                // For simplicity, just set a success message here
                Message = "Authentication successful!";
            }
            else
            {
                // Authentication failed
                Message = "Invalid email or password";
            }
        }

        private bool CheckUserCredentials(string email, string password)
        {
            // Replace the connection string with your actual database connection string
            string connectionString = @"Persist Security Info=False;Integrated Security=True;Database=Systems;server=(localDB)\MSSQLLocalDB";

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //SQL Query
            using SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Email = @Email", connection);
            command.Parameters.AddWithValue("@Email", email);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                byte[] storedHashedPassword = (byte[])reader["UserPassword"];
                byte[] storedSalt = (byte[])reader["Salt"];

                byte[] hashedPassword = HashPasswordWithSalt(password, storedSalt);

                if (ByteArraysAreEqual(hashedPassword, storedHashedPassword))
                {
                    // Authentication successful
                    return true;
                }
            }

            // Authentication failed
            return false;
        }

        private byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32);
            }
        }

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