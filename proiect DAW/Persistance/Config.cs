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
                    new user("mare") {Name = "tud", Tip = "user", Balance = 10,Idlogin=1},
                
                    new user("schema") {Name = "jeff", Tip = "user", Balance = 20,Idlogin=2},
                
                    new user("aicea") {Name = "chef", Tip = "user", Balance = 0,Idlogin=3}
                };
                context.User.AddRange(useri);
                context.SaveChanges();
            }
            if(!context.Producator.Any())
            {
                var producatori = new List<producator>
                {
                    new producator {Id =1, Name = "Daniel Mullins"},
                
                    new producator {Id =2,Name = "Mihoyo"},
                
                    new producator {Id =3,Name = "Edmund McMillen"}
                };
                context.Producator.AddRange(producatori);
                context.SaveChanges();
            }
            if(!context.Login.Any())
            {
                var parole = new List<login>
                {
                    new login {Id =1, Parola = "mare"},
                
                    new login {Id =2,Parola = "schema"},
                
                    new login {Id =3,Parola = "aicea"}
                };
                context.Login.AddRange(parole);
                context.SaveChanges();
            }
            if(!context.Games.Any())
            {
                var jocuri = new List<games>
                {
                    new games {Name = "The Binding of Isaac",  Cost = 15},
                
                    new games {Name = "Inscryption",  Cost = 20},

                    new games {Name = "Genshin Impact",  Cost = 0},

                    new games {Name = "The End is Nigh",  Cost = 0},

                    new games {Name = "Pony Island",  Cost = 4}
                };
                context.Games.AddRange(jocuri);
                context.SaveChanges();
            }
            
        }
    }
}