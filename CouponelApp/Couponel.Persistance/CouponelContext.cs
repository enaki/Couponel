using Couponel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Couponel.Persistence
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
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<Faculty>()
                .HasMany<Student>(faculty => faculty.Students)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);

            //One to one relations 
            modelBuilder.Entity<Student>()
                .HasOne<Address>(student => student.Address)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey<Student>(student => student.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Faculty>()
                .HasOne<Address>(faculty => faculty.Address)
                .WithOne()
                .IsRequired(true)
                .HasForeignKey<Faculty>(faculty => faculty.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<University>()
                .HasOne<Address>(university => university.Address)
                .WithOne()
                .IsRequired(true)
                .HasForeignKey<University>(university => university.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
