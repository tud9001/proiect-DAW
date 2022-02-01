using System;

namespace Domain
{
    public class login
    {
        public login()
        {
        }
        public login(string Email)
        {
            email=Email;
        }

        public int Id{get; set;}
        public string email{get; set;}
    }
}