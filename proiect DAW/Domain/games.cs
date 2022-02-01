using System;
using System.Collections.Generic;

namespace Domain
{
    public class games
    {
        public Guid Id{get; set;}
        public string Name{get; set; }
        public float Cost{get; set; }

        public int Idprod{get;set;}

        public virtual ICollection<achizitii> achizitie { get; set; }
    }
}