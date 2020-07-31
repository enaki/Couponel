using Couponel.Entities;
using Couponel.Entities.Coupons;
using Couponel.Entities.Identities;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Entities.Institutions;
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

            #region Many to one relations
            #region Institutions
            modelBuilder.Entity<University>()
                .HasMany<Faculty>(university => university.Faculties)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<Faculty>()
                .HasMany<Student>(faculty => faculty.Students)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);
            #endregion

            #region Coupons
            modelBuilder.Entity<Offerer>()
                .HasMany<Coupon>(offerer => offerer.Coupons)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Coupon>()
                .HasMany<RedeemedCoupon>(coupon => coupon.RedeemedCoupons)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany<RedeemedCoupon>(student => student.RedeemedCoupons)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #endregion

            #region One to one relations 

            #region Address Relations
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
            #endregion 
            #region User Relations
            modelBuilder.Entity<Student>()
                .HasOne<User>(student => student.User)
                .WithOne()
                .IsRequired(true)
                .HasForeignKey<Student>(student => student.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Admin>()
                .HasOne<User>(admin => admin.User)
                .WithOne()
                .IsRequired(true)
                .HasForeignKey<Admin>(admin => admin.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offerer>()
                .HasOne<User>(offerer => offerer.User)
                .WithOne()
                .IsRequired(true)
                .HasForeignKey<Offerer>(offerer => offerer.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
            #endregion

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<RedeemedCoupon> RedeemedCoupons { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Offerer> Offerers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
