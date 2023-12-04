using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using BAIS3110___Authentication__1.Controller;
using BAIS3110___Authentication__1.Domain;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System;

namespace BAIS3110Authentication.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnPost()
        {
            BCS bCS = new BCS();
            User existingUser = new();

            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: Password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

           // Password = hashed;

            existingUser = bCS.GetUser(Email);

            string UserEmail = existingUser.Email;
            string UserName = existingUser.Username;
            string UserPassword = existingUser.Password;
            string UserRole = existingUser.Role;

            if (Email == UserEmail)
            {
                if (Password == UserPassword)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, Email),
                        new Claim(ClaimTypes.Name, UserName)
                    };
                        var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, UserRole));
                        AuthenticationProperties authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.
                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A
                        // value set here overrides the ExpireTimeSpan option of
                        // CookieAuthenticationOptions set with AddCookie.
                        //IsPersistent = true,
                        // Whether the authentication session is persisted across
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session‐based.
                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.
                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http
                        // redirect response value.
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToPage("/Admin/Index");
                }
               
            }
            Message = "Invalid attempt";
            return Page();
        }
    }
}

