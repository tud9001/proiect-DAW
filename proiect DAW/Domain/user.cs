﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public class user
    {
        public user()
        {
            var loginuser=new login("");
            Idlogin=loginuser.Id;
        }
        public user(string parola)
        {
            var loginuser=new login(parola);
            Idlogin=loginuser.Id;
        }

        public Guid Id{get; set;}
        public string Name{get; set; }

        public string Tip{get;set;}
        public float Balance{get;set;}
        public int Idlogin{get; set;}
        public virtual ICollection<achizitii> achizitie { get; set; }
    }
}
