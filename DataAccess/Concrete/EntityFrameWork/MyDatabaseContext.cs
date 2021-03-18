using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class MyDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyDataBase;Trusted_Connection=true");

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("dbo");//dbo defaulttur o yüzden yazmaya gerek yok
            modelBuilder.Entity<Buyer>().ToTable("Customers","dbo");//dbo defaulttur o yüzden yazmaya gerek yok
            modelBuilder.Entity<Buyer>().Property(p => p.BuyerId).HasColumnName("Id");
            modelBuilder.Entity<Buyer>().Property(p => p.Name).HasColumnName("FirstName");
            modelBuilder.Entity<Buyer>().Property(p => p.Surname).HasColumnName("LastName");
        }




    }
}
