using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistance
{
    public class Config
    {
        public static void ConfigData(DataContext context)
        {
            if(!context.User.Any())
            {
                var useri = new List<user>
                {
                    new user {Name = "tud", Tip = "user", Balance = 10, Idlogin = 1},
                
                    new user {Name = "jeff", Tip = "user", Balance = 20, Idlogin = 2},
                
                    new user {Name = "chef", Tip = "user", Balance = 0, Idlogin = 3}
                };
                context.User.AddRange(useri);
                context.SaveChanges();
            }
            if(!context.Games.Any())
            {
                var jocuri = new List<games>
                {
                    new games {Name = "The Binding of Isaac",  Cost = 15, Idprod = 3},
                
                    new games {Name = "Inscryption",  Cost = 20, Idprod = 1},

                    new games {Name = "Genshin Impact",  Cost = 0, Idprod = 2},

                    new games {Name = "The End is Nigh",  Cost = 0, Idprod = 3},

                    new games {Name = "Pony Island",  Cost = 4, Idprod = 1}
                };
                context.Games.AddRange(jocuri);
                context.SaveChanges();
            }
        }
    }
}