using System;

namespace Domain
{
    public class login
    {
        public login(string parola)
        {
            Parola=parola;
        }

        public Guid Id{get; set;}
        public string Parola{get; set;}
    }
}