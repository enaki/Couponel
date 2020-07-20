using CouponelServices.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouponelServices.Persistence
{
    class CouponelContext : DbContext
    {
        public CouponelContext(DbContextOptions<CouponelContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to many relations
            modelBuilder.Entity<University>()
                .HasMany<Faculty>(university => university.Faculties)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Faculty>()
                .HasMany<Student>(faculty=> faculty.Students)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany<Address>(student => student.Addresses)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<University>()
                .HasMany<Address>(university => university.Addresses)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Faculty>()
                .HasMany<Address>(faculty => faculty.Addresses)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Address> Coupons { get; set; }
        public DbSet<Address> Faculties { get; set; }
        public DbSet<Address> Students { get; set; }
        public DbSet<Address> Universities { get; set; }
        public DbSet<Address> Users { get; set; }
    }
}
