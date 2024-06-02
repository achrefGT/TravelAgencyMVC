using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TransportMVC.Data
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Review configurations
            modelBuilder.Entity<Review>()
                .HasOne(r => r.AssociatedPackage)
                .WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete configured correctly

            modelBuilder.Entity<Review>()
                .HasOne(r => r.CreatedBy)
                .WithMany(u => u.Reviews)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            modelBuilder.Entity<Review>()
                .HasOne(r => r.LastModifiedBy)
                .WithMany(u => u.ModifiedReviews)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            // Notification configurations
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Receiver)
                .WithMany(u => u.ReceivedNotifications)
                .HasForeignKey(n => n.ReceiverId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete configured correctly

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.CreatedBy)
                .WithMany(u => u.SentNotifications)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.LastModifiedBy)
                .WithMany(u => u.ModifiedNotifications)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            // Booking configurations
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.AssociatedPackage)
                .WithMany(p => p.Bookings)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete configured correctly

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.CreatedBy)
                .WithMany(u => u.Bookings)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.LastModifiedBy)
                .WithMany(u => u.ModifiedBookings)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            // Coupon configurations
            modelBuilder.Entity<Coupon>()
                .HasOne(c => c.CreatedBy)
                .WithMany(u => u.Coupons)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            modelBuilder.Entity<Coupon>()
                .HasMany(c => c.Packages)
                .WithMany(p => p.Coupons);

            // Destination configurations
            modelBuilder.Entity<Destination>()
                .HasOne(d => d.CreatedBy)
                .WithMany(u => u.Destinations)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            // Package configurations
            modelBuilder.Entity<Package>()
                .HasOne(p => p.CreatedBy)
                .WithMany(u => u.Packages)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            modelBuilder.Entity<Package>()
                .HasOne(p => p.Destination)
                .WithMany(d => d.Packages)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete configured correctly

            modelBuilder.Entity<Package>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<Package>()
                .HasOne(p => p.Coordinator)
                .WithMany(c => c.Packages)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            modelBuilder.Entity<Coordinator>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasOne<IdentityRole>()
                .WithMany()
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
                

            // The following code will set ON DELETE NO ACTION to all Foreign Keys
            // foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            // {
            //     foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            // }

            // Configure cascade delete for user-related entities

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedNotifications)
                .WithOne(n => n.Receiver)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete notifications related to a user

            modelBuilder.Entity<User>()
                .HasMany(u => u.SentNotifications)
                .WithOne(n => n.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull); // Set null for notifications created by a user if the user is deleted

            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.CreatedBy)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete bookings created by a user

            modelBuilder.Entity<User>()
                .HasMany(u => u.ModifiedBookings)
                .WithOne(b => b.LastModifiedBy)
                .OnDelete(DeleteBehavior.SetNull); // Set null for modified bookings if the user is deleted

            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete reviews created by a user

            modelBuilder.Entity<User>()
                .HasMany(u => u.ModifiedReviews)
                .WithOne(r => r.LastModifiedBy)
                .OnDelete(DeleteBehavior.SetNull); // Set null for modified reviews if the user is deleted

                }

        public DbSet<Destination> Destinations { get; set; } = default!;
        public DbSet<Package> Packages { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<Coordinator> Coordinators { get; set; } = default!;
        public DbSet<Coupon> Coupons { get; set; } = default!;
        public DbSet<Notification> Notifications { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<WishForm> WishForms { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;


        
    }
}
