﻿using ClubBAISTGolfClub.Techical_Services;
using ClubBAISTGolfClub.Domain;
using System.Security.Cryptography;

namespace ClubBAISTGolfClub.Controller
{
    public class MemberControlls
    {
        public Member CreateMembership(Member member)
        { 
            MembershipServices membershipServices = new MembershipServices();
            member = membershipServices.CreateApplication(member);
            return member;
        }
        public void AddUser(Member addeduser)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            byte[] hashedPassword = HashPasswordWithSalt(addeduser.MemberPassword, salt);

            // Convert the salt and hashed password to Base64 for storage
            string saltBase64 = Convert.ToBase64String(salt);
            string hashedPasswordBase64 = Convert.ToBase64String(hashedPassword);

            SecurityManager controll = new SecurityManager();
            addeduser.MemberPassword = hashedPasswordBase64;
            addeduser.MemberSalt = saltBase64;
            Console.WriteLine(addeduser.MemberPassword);
            CreateMembership(addeduser);
        }
        public Member GetMember(string existingUseremail)
        {
            Member member = new Member();
            SecurityManager controll = new SecurityManager();
            member = controll.GetUser(existingUseremail);

            return member;
        }
        private static byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            // Hash the password with PBKDF2 using HMACSHA256
            return new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256).GetBytes(32);
        }
    }
}