
using DigitalPropertyManagmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
   


      
        

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

            List<Property> properties = new List<Property>()
            {
                 new Property
                 {
                    PropertyId = 1,
                    Title = "Luxury Apartment in Cairo",
                    Description = "A spacious apartment in the heart of Cairo.",
                    Price = 5000,
                    PropertyType = "Apartment",
                    Status = "Available",
                    Size = 120,
                    Bedrooms = 3,
                    Bathrooms = 2,
                    Furnished = true,
                    IsAvailable = true,
                    ListedAt = DateTime.UtcNow,
                    Street = "Downtown Street",
                    City = "Cairo",
                    Governate = "Cairo",
                    Latitude = 30.0444,
                    Longitude = 31.2357
                 },

                 new Property
                 {
                    PropertyId = 2,
                    Title = "Modern Villa with Pool",
                    Description = "A luxurious villa with a private pool.",
                    Price = 15000,
                    PropertyType = "Villa",
                    Status = "Available",
                    Size = 300,
                    Bedrooms = 5,
                    Bathrooms = 4,
                    Furnished = false,
                    IsAvailable = true,
                    ListedAt = DateTime.UtcNow,
                    Street = "6th October Road",
                    City = "Giza",
                    Governate = "Giza",
                    Latitude = 29.9765,
                    Longitude = 31.1313
                 },

                new Property
                {
                    PropertyId = 3,
                    Title = "Beachfront Studio",
                    Description = "A modern studio apartment with a sea view.",
                    Price = 3000,
                    PropertyType = "Studio",
                    Status = "Available",
                    Size = 50,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Furnished = true,
                    IsAvailable = true,
                    ListedAt = DateTime.UtcNow,
                    Street = "Corniche Street",
                    City = "Alexandria",
                    Governate = "Alexandria",
                    Latitude = 31.2001,
                    Longitude = 29.9187
                },

                new Property
                {
                    PropertyId = 4,
                    Title = "Cozy House in Mansoura",
                    Description = "A comfortable house located in a quiet area.",
                    Price = 6000,
                    PropertyType = "House",
                    Status = "Pending",
                    Size = 180,
                    Bedrooms = 4,
                    Bathrooms = 3,
                    Furnished = false,
                    IsAvailable = false,
                    ListedAt = DateTime.UtcNow,
                    Street = "Shobra Street",
                    City = "Mansoura",
                    Governate = "Dakahlia",
                    Latitude = 31.0364,
                    Longitude = 31.3807
                },

                new Property
                {
                    PropertyId = 5,
                    Title = "Luxury Penthouse in Nasr City",
                    Description = "A high-end penthouse with a rooftop terrace.",
                    Price = 20000,
                    PropertyType = "Penthouse",
                    Status = "Available",
                    Size = 250,
                    Bedrooms = 4,
                    Bathrooms = 4,
                    Furnished = true,
                    IsAvailable = true,
                    ListedAt = DateTime.UtcNow,
                    Street = "Nasr City Main Road",
                    City = "Cairo",
                    Governate = "Cairo",
                    Latitude = 30.0489,
                    Longitude = 31.3462
                },

                new Property
                {
                    PropertyId = 6,
                    Title = "Affordable Apartment in Giza",
                    Description = "A budget-friendly apartment near public transportation.",
                    Price = 2500,
                    PropertyType = "Apartment",
                    Status = "Available",
                    Size = 90,
                    Bedrooms = 2,
                    Bathrooms = 1,
                    Furnished = false,
                    IsAvailable = true,
                    ListedAt = DateTime.UtcNow,
                    Street = "Faisal Street",
                    City = "Giza",
                    Governate = "Giza",
                    Latitude = 29.9876,
                    Longitude = 31.2134
                },

                new Property
                {
                    PropertyId = 7,
                    Title = "Furnished Studio in Alexandria",
                    Description = "A small, fully furnished studio in Alexandria.",
                    Price = 3500,
                    PropertyType = "Studio",
                    Status = "Available",
                    Size = 40,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    Furnished = true,
                    IsAvailable = true,
                    ListedAt = DateTime.UtcNow,
                    Street = "Stanley Bridge",
                    City = "Alexandria",
                    Governate = "Alexandria",
                    Latitude = 31.2156,
                    Longitude = 29.9553
                },

                new Property
                {
                    PropertyId = 8,
                    Title = "Elegant Duplex in Maadi",
                    Description = "A stylish duplex in Maadi with garden access.",
                    Price = 10000,
                    PropertyType = "Duplex",
                    Status = "Available",
                    Size = 200,
                    Bedrooms = 3,
                    Bathrooms = 3,
                    Furnished = true,
                    IsAvailable = true,
                    ListedAt = DateTime.UtcNow,
                    Street = "Maadi Corniche",
                    City = "Cairo",
                    Governate = "Cairo",
                    Latitude = 30.0081,
                    Longitude = 31.2306
                },

                new Property
                {
                    PropertyId = 9,
                    Title = "Budget-Friendly House in Tanta",
                    Description = "A simple house at an affordable price.",
                    Price = 4000,
                    PropertyType = "House",
                    Status = "Available",
                    Size = 160,
                    Bedrooms = 3,
                    Bathrooms = 2,
                    Furnished = false,
                    IsAvailable = true,
                    ListedAt = DateTime.UtcNow,
                    Street = "Tanta Main Road",
                    City = "Tanta",
                    Governate = "Gharbia",
                    Latitude = 30.7885,
                    Longitude = 31.0019
                },

                new Property
                {
                    PropertyId = 10,
                    Title = "Luxury Beachfront Villa in Hurghada",
                    Description = "A premium villa with private beach access.",
                    Price = 25000,
                    PropertyType = "Villa",
                    Status = "Available",
                    Size = 400,
                    Bedrooms = 6,
                    Bathrooms = 5,
                    Furnished = true,
                    IsAvailable = true,
                    ListedAt = DateTime.UtcNow,
                    Street = "Sahl Hasheesh",
                    City = "Hurghada",
                    Governate = "Red Sea",
                    Latitude = 27.2579,
                    Longitude = 33.8116
                },
               
            };

            modelBuilder.Entity<Property>().HasData(properties);

            modelBuilder.Entity<User>()
                 .HasIndex(u => u.Email)
                   .IsUnique();

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
