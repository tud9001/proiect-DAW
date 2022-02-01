using System;
using System.Collections.Generic;
using Domain;

namespace WebApi.Models.Users
{
    public class AuthenticateResponse
    {
        public Guid Id{get; set;}
        public string Name{get;set;}
        public float Balance{get;set;}
        public int Idlogin{get; set;}
        public role role{get; set;}
        public virtual ICollection<achizitii> achizitie { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(user user, string token)
        {
            Id = user.Id;
            Name=user.Name;
            Balance = user.Balance;
            role = user.role;
            Token = token;
        }
    }
}