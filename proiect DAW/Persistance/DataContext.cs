using System;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {}
        public DbSet<user> User {get; set;}
        public DbSet<games> Games {get; set;}
        public DbSet<login> Login {get; set;}
        public DbSet<producator> Producator {get; set;}
        public DbSet<achizitii> Achizitii {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<achizitii>(x => x.HasKey(ug => 
                new {ug.Iduser, ug.Idjoc}));
            builder.Entity<achizitii>()
            .HasOne(u => u.user)
            .WithMany(g => g.achizitie)
            .HasForeignKey(u=> u.Iduser);
            builder.Entity<achizitii>()
            .HasOne(g => g.games)
            .WithMany(u => u.achizitie)
            .HasForeignKey(g=> g.Idjoc);
            builder.Entity<user>()
            .HasData(
                new user {Id = 1, Name = "tud", Tip = "user", Balance = 10, Idlogin = 1},
                
                new user {Id = 2, Name = "jeff", Tip = "user", Balance = 20, Idlogin = 2},
                
                new user {Id = 3, Name = "chef", Tip = "user", Balance = 0, Idlogin = 3}
            );
            builder.Entity<games>()
            .HasData(
                new games {Id = 1, Name = "The Binding of Isaac",  Cost = 15, Idprod = 3},
                
                new games {Id = 2, Name = "Inscryption",  Cost = 20, Idprod = 1},

                new games {Id = 3, Name = "Genshin Impact",  Cost = 0, Idprod = 2},

                new games {Id = 4, Name = "The End is Nigh",  Cost = 0, Idprod = 3},

                new games {Id = 5, Name = "Pony Island",  Cost = 4, Idprod = 1}
            );
            builder.Entity<producator>()
            .HasData(
                new producator {Id = 1, Name = "Daniel Mullins"},
                
                new producator {Id = 2, Name = "Mihoyo"},
                
                new producator {Id = 3, Name = "Edmund McMillen"}
            );
            builder.Entity<login>()
            .HasData(
                new login {Id = 1, Parola = "mare"},
                
                new login {Id = 2, Parola = "schema"},
                
                new login {Id = 3, Parola = "aicea"}
            );
            
        }
    }
}
