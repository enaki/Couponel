using CouponelServices.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouponelServices.Persistence
{
    public class CouponelContext : DbContext
    {
        public CouponelContext(DbContextOptions<CouponelContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to many relations
            modelBuilder.Entity<University>()
                .HasMany<Faculty>(university => university.Faculties)
                .WithOne();

            modelBuilder.Entity<Faculty>()
                .HasMany<Student>(faculty=> faculty.Students)
                .WithOne();

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Address> Coupons { get; set; }
        public DbSet<Address> Faculties { get; set; }
        public DbSet<Address> Students { get; set; }
        public DbSet<Address> Universities { get; set; }
        public DbSet<Address> Users { get; set; }
    }
}
