using System;
using Microsoft.EntityFrameworkCore;
using Domain;
namespace Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>().HasData
            (
              new Value { Id = 1, Name = "Value 101" },
              new Value { Id = 2, Name = "Value 102" },
              new Value { Id = 3, Name = "Value 103" }
            );
        }
    }
}



/*
Explaination:

base (options) -- We also need to use the options from derived DbContext. If we don't have this, we will have problems to migration

public DbSet<Value> Values { get; set; }  -- Values would be name for the table in database. Import Domain where our Value entity is located. So Domain is actually model, entity is the tables we want to create 
 
protected override void OnModelCreating -- protected methods are only accessible to this class and its derived classes. OnModelCreating is the method from Dbcontext. reference: https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext.onmodelcreating?view=entity-framework-6.2.0
*/


