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
                new {ug.Iduser, ug.Idgames}));
            builder.Entity<achizitii>()
            .HasOne(u => u.user)
            .WithMany(g => g.achizitie)
            .HasForeignKey(u=> u.Iduser);
            builder.Entity<achizitii>()
            .HasOne(g => g.games)
            .WithMany(u => u.achizitie)
            .HasForeignKey(g=> g.Idgames);
            
            
            
            
            
        }
    }
}
