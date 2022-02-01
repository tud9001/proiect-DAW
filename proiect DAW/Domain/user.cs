using System;
using System.Collections.Generic;

namespace Domain
{
    public class user
    {
        public int Id{get; set;}
        public string Name{get; set; }

        public string Tip{get;set;}
        public float Balance{get;set;}
        public int Idlogin{get; set;}
        public virtual ICollection<achizitii> achizitie { get; set; }
    }
}
