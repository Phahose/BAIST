using BAIS3110___Authentication__1.Domain;
using BAIS3110___Authentication__1.Technical_Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
namespace BAIS3110___Authentication__1.Controller
{
    public class BCS
    {
        public void AddUser(User addeduser)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
              password: addeduser.Password,
              salt: salt,
              prf: KeyDerivationPrf.HMACSHA256,
              iterationCount: 100000,
              numBytesRequested: 256 / 8));

            Controls controll= new Controls();
            Console.WriteLine(addeduser.Password);
            controll.AddUser(addeduser);
        }
    }
}
