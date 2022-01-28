using System;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {}
        public DbSet<value> Values {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<value>()
            .HasData(
                new value {Id = 1, Name = "mare"},
                
                new value {Id = 2, Name = "schema"},
                
                new value {Id = 3, Name = "aicea"}
            );
        }
        
    }
}
