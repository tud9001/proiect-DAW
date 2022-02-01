using System;

namespace Domain
{
    public class login
    {
        public login()
        {
        }
        public login(string parola)
        {
            Parola=parola;
        }

        public int Id{get; set;}
        public string Parola{get; set;}
    }
}