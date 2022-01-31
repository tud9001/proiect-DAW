using System;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {}
        public DbSet<user> Values {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<user>()
            .HasData(
                new user {Id = 1, Name = "mare"},
                
                new user {Id = 2, Name = "schema"},
                
                new user {Id = 3, Name = "aicea"}
            );
        }
        
    }
}
