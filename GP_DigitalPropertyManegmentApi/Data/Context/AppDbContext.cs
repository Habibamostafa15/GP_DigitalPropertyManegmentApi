
using DigitalPropertyManagmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class AppDbContext : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)


        {
            optionsBuilder.UseSqlServer("Server=.;Database=DigitalPropertyDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }


      
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<PropertyImage> PropertiesImages { get; set; }

        public DbSet<UserPropertyReview> UserPropertyReviews { get; set; }
        public DbSet<UserPropertyFavorite> UserPropertyFavorites { get; set; }
        public DbSet<UserPropertyDocument> UserPropertyDocuments { get; set; }
        public DbSet<UserPropertyPayment> UserPropertyPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-Many Relationships
            modelBuilder.Entity<UserPropertyReview>()
                .HasKey(up => new { up.UserId, up.PropertyId });

            modelBuilder.Entity<UserPropertyFavorite>()
                .HasKey(up => new { up.UserId, up.PropertyId });

            modelBuilder.Entity<UserPropertyDocument>()
                .HasKey(up => new { up.UserId, up.PropertyId, up.DocumentId });

            modelBuilder.Entity<UserPropertyPayment>()
                .HasKey(up => new { up.UserId, up.PropertyId, up.PaymentId });

            //modelBuilder.Entity<PropertyAmenity>()
            //    .HasKey(pa => new { pa.PropertyId, pa.AmenityId });

            //// One-to-Many Relationships
            //modelBuilder.Entity<Notification>()
            //    .HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(n => n.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<SearchHistory>()
            //    .HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(sh => sh.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ChatMessage>()
            //    .HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(cm => cm.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
