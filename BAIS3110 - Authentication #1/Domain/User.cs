﻿namespace BAIS3110___Authentication__1.Domain
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
    }
}
