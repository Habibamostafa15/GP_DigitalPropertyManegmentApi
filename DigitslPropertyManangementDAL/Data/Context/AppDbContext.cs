
using DigitalPropertyManagmentApi.Models;
using DigitslPropertyManangementDAL.Data.Models;
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


            var externalAmenities = new List<ExternalAmenity>
            {
                new ExternalAmenity { Id = 1, Name = "Garden" },
                new ExternalAmenity { Id = 2, Name = "Swimming Pool" },
                new ExternalAmenity { Id = 3, Name = "Parking" },
                new ExternalAmenity { Id = 4, Name = "Playground" },
                new ExternalAmenity { Id = 5, Name = "Security" },
                new ExternalAmenity { Id = 6, Name = "Elevator" },
                new ExternalAmenity { Id = 7, Name = "Balcony" },
                new ExternalAmenity { Id = 8, Name = "Roof Access" },
                new ExternalAmenity { Id = 9, Name = "BBQ Area" },
                new ExternalAmenity { Id = 10, Name = "Sports Court" }
            };

            var internalAmenities = new List<InternalAmenity>
            {
                new InternalAmenity { Id = 1, Name = "Air Conditioning" },
                new InternalAmenity { Id = 2, Name = "Central Heating" },
                new InternalAmenity { Id = 3, Name = "Fireplace" },
                new InternalAmenity { Id = 4, Name = "Laundry Room" },
                new InternalAmenity { Id = 5, Name = "Walk-in Closet" },
                new InternalAmenity { Id = 6, Name = "High-Speed Internet" },
                new InternalAmenity { Id = 7, Name = "Smart Home System" },
                new InternalAmenity { Id = 8, Name = "Modern Kitchen" },
                new InternalAmenity { Id = 9, Name = "Hardwood Floors" },
                new InternalAmenity { Id = 10, Name = "Soundproof Walls" }
            };

            var accessibilityAmenities = new List<AccessibillityAmenity>
            {
                new AccessibillityAmenity { Id = 1, Name = "Wheelchair Ramp" },
                new AccessibillityAmenity { Id = 2, Name = "Elevator Access" },
                new AccessibillityAmenity { Id = 3, Name = "Wide Hallways" },
                new AccessibillityAmenity { Id = 4, Name = "Grab Bars" },
                new AccessibillityAmenity { Id = 5, Name = "Accessible Parking" },
                new AccessibillityAmenity { Id = 6, Name = "Lowered Counters" },
                new AccessibillityAmenity { Id = 7, Name = "Voice Control System" },
                new AccessibillityAmenity { Id = 8, Name = "Automatic Doors" },
                new AccessibillityAmenity { Id = 9, Name = "Visual Alerts" },
                new AccessibillityAmenity { Id = 10, Name = "Braille Signage" }
            };



            modelBuilder.Entity<AccessibillityAmenity>().HasData(accessibilityAmenities);
            modelBuilder.Entity<ExternalAmenity>().HasData(externalAmenities);
            modelBuilder.Entity<InternalAmenity>().HasData(internalAmenities);
            modelBuilder.Entity<Property>().HasData(
        new Property
        {
            PropertyId = 1,
            UserId = 1,
            ListingType = "sale",
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
            UserId = 2,
            ListingType = "rent",
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
            UserId = 3,
            ListingType = "sale",
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
            UserId = 4,
            ListingType = "sale",
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
            UserId = 5,
            ListingType = "rent",
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
            UserId = 6,
            ListingType = "rent",
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
            UserId = 7,
            ListingType = "sale",
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
            UserId = 8,
            ListingType = "rent",
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
            UserId = 9,
            ListingType = "sale",
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
            UserId = 10,
            ListingType = "rent",
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
        }
    );

            modelBuilder.Entity<Property>()
      .HasMany(p => p.ExternalAmenities)
      .WithMany(e => e.Properties)
      .UsingEntity<Dictionary<string, object>>(
          "PropertyExternalAmenities",
          j => j.HasOne<ExternalAmenity>().WithMany().HasForeignKey("ExternalAmenitiesId"),
          j => j.HasOne<Property>().WithMany().HasForeignKey("PropertiesPropertyId"),
          j =>
          {
              j.HasKey("PropertiesPropertyId", "ExternalAmenitiesId");
              j.HasData(
                  new { PropertiesPropertyId = 1, ExternalAmenitiesId = 3 }, // Parking
                  new { PropertiesPropertyId = 1, ExternalAmenitiesId = 6 }, // Elevator
                  new { PropertiesPropertyId = 1, ExternalAmenitiesId = 8 }, // Roof Access
                  new { PropertiesPropertyId = 2, ExternalAmenitiesId = 1 }, // Garden
                  new { PropertiesPropertyId = 2, ExternalAmenitiesId = 2 }, // Swimming Pool
                  new { PropertiesPropertyId = 2, ExternalAmenitiesId = 9 }, // BBQ Area
                  new { PropertiesPropertyId = 2, ExternalAmenitiesId = 10 }, // Sports Court
                  new { PropertiesPropertyId = 3, ExternalAmenitiesId = 7 }, // Balcony
                  new { PropertiesPropertyId = 3, ExternalAmenitiesId = 5 }, // Security
                  new { PropertiesPropertyId = 4, ExternalAmenitiesId = 1 }, // Garden
                  new { PropertiesPropertyId = 4, ExternalAmenitiesId = 3 }, // Parking
                  new { PropertiesPropertyId = 4, ExternalAmenitiesId = 4 }, // Playground
                  new { PropertiesPropertyId = 5, ExternalAmenitiesId = 6 }, // Elevator
                  new { PropertiesPropertyId = 5, ExternalAmenitiesId = 8 }, // Roof Access
                  new { PropertiesPropertyId = 5, ExternalAmenitiesId = 9 }, // BBQ Area
                  new { PropertiesPropertyId = 6, ExternalAmenitiesId = 3 }, // Parking
                  new { PropertiesPropertyId = 6, ExternalAmenitiesId = 5 }, // Security
                  new { PropertiesPropertyId = 7, ExternalAmenitiesId = 7 }, // Balcony
                  new { PropertiesPropertyId = 7, ExternalAmenitiesId = 6 }, // Elevator
                  new { PropertiesPropertyId = 8, ExternalAmenitiesId = 1 }, // Garden
                  new { PropertiesPropertyId = 8, ExternalAmenitiesId = 3 }, // Parking
                  new { PropertiesPropertyId = 8, ExternalAmenitiesId = 8 }, // Roof Access
                  new { PropertiesPropertyId = 9, ExternalAmenitiesId = 1 }, // Garden
                  new { PropertiesPropertyId = 9, ExternalAmenitiesId = 3 }, // Parking
                  new { PropertiesPropertyId = 9, ExternalAmenitiesId = 4 }, // Playground
                  new { PropertiesPropertyId = 10, ExternalAmenitiesId = 2 }, // Swimming Pool
                  new { PropertiesPropertyId = 10, ExternalAmenitiesId = 3 }, // Parking
                  new { PropertiesPropertyId = 10, ExternalAmenitiesId = 9 }, // BBQ Area
                  new { PropertiesPropertyId = 10, ExternalAmenitiesId = 10 } // Sports Court
              );
          });

            // Configure many-to-many: Property ↔ InternalAmenity
            modelBuilder.Entity<Property>()
                .HasMany(p => p.InternalAmenities)
                .WithMany(i => i.Properties)
                .UsingEntity<Dictionary<string, object>>(
                    "PropertyInternalAmenities",
                    j => j.HasOne<InternalAmenity>().WithMany().HasForeignKey("InternalAmenitiesId"),
                    j => j.HasOne<Property>().WithMany().HasForeignKey("PropertiesPropertyId"),
                    j =>
                    {
                        j.HasKey("PropertiesPropertyId", "InternalAmenitiesId");
                        j.HasData(
                            new { PropertiesPropertyId = 1, InternalAmenitiesId = 1 }, // Air Conditioning
                            new { PropertiesPropertyId = 1, InternalAmenitiesId = 6 }, // High-Speed Internet
                            new { PropertiesPropertyId = 1, InternalAmenitiesId = 8 }, // Modern Kitchen
                            new { PropertiesPropertyId = 2, InternalAmenitiesId = 2 }, // Central Heating
                            new { PropertiesPropertyId = 2, InternalAmenitiesId = 4 }, // Laundry Room
                            new { PropertiesPropertyId = 2, InternalAmenitiesId = 7 }, // Smart Home System
                            new { PropertiesPropertyId = 3, InternalAmenitiesId = 1 }, // Air Conditioning
                            new { PropertiesPropertyId = 3, InternalAmenitiesId = 9 }, // Hardwood Floors
                            new { PropertiesPropertyId = 4, InternalAmenitiesId = 3 }, // Fireplace
                            new { PropertiesPropertyId = 4, InternalAmenitiesId = 5 }, // Walk-in Closet
                            new { PropertiesPropertyId = 4, InternalAmenitiesId = 10 }, // Soundproof Walls
                            new { PropertiesPropertyId = 5, InternalAmenitiesId = 7 }, // Smart Home System
                            new { PropertiesPropertyId = 5, InternalAmenitiesId = 8 }, // Modern Kitchen
                            new { PropertiesPropertyId = 5, InternalAmenitiesId = 9 }, // Hardwood Floors
                            new { PropertiesPropertyId = 5, InternalAmenitiesId = 1 }, // Air Conditioning
                            new { PropertiesPropertyId = 6, InternalAmenitiesId = 1 }, // Air Conditioning
                            new { PropertiesPropertyId = 6, InternalAmenitiesId = 6 }, // High-Speed Internet
                            new { PropertiesPropertyId = 7, InternalAmenitiesId = 8 }, // Modern Kitchen
                            new { PropertiesPropertyId = 7, InternalAmenitiesId = 9 }, // Hardwood Floors
                            new { PropertiesPropertyId = 8, InternalAmenitiesId = 1 }, // Air Conditioning
                            new { PropertiesPropertyId = 8, InternalAmenitiesId = 6 }, // High-Speed Internet
                            new { PropertiesPropertyId = 8, InternalAmenitiesId = 7 }, // Smart Home System
                            new { PropertiesPropertyId = 9, InternalAmenitiesId = 2 }, // Central Heating
                            new { PropertiesPropertyId = 9, InternalAmenitiesId = 5 }, // Walk-in Closet
                            new { PropertiesPropertyId = 9, InternalAmenitiesId = 10 }, // Soundproof Walls
                            new { PropertiesPropertyId = 10, InternalAmenitiesId = 1 }, // Air Conditioning
                            new { PropertiesPropertyId = 10, InternalAmenitiesId = 7 }, // Smart Home System
                            new { PropertiesPropertyId = 10, InternalAmenitiesId = 8 }, // Modern Kitchen
                            new { PropertiesPropertyId = 10, InternalAmenitiesId = 9 } // Hardwood Floors
                        );
                    });

            // Configure many-to-many: Property ↔ AccessibillityAmenity
            modelBuilder.Entity<Property>()
                .HasMany(p => p.AccessibilityAmenities)
                .WithMany(a => a.Properties)
                .UsingEntity<Dictionary<string, object>>(
                    "PropertyAccessibilityAmenities",
                    j => j.HasOne<AccessibillityAmenity>().WithMany().HasForeignKey("AccessibilityAmenitiesId"),
                    j => j.HasOne<Property>().WithMany().HasForeignKey("PropertiesPropertyId"),
                    j =>
                    {
                        j.HasKey("PropertiesPropertyId", "AccessibilityAmenitiesId");
                        j.HasData(
                            new { PropertiesPropertyId = 1, AccessibilityAmenitiesId = 2 }, // Elevator Access
                            new { PropertiesPropertyId = 1, AccessibilityAmenitiesId = 4 }, // Grab Bars
                            new { PropertiesPropertyId = 2, AccessibilityAmenitiesId = 1 }, // Wheelchair Ramp
                            new { PropertiesPropertyId = 2, AccessibilityAmenitiesId = 5 }, // Accessible Parking
                            new { PropertiesPropertyId = 2, AccessibilityAmenitiesId = 8 }, // Automatic Doors
                            new { PropertiesPropertyId = 3, AccessibilityAmenitiesId = 9 }, // Visual Alerts
                            new { PropertiesPropertyId = 3, AccessibilityAmenitiesId = 10 }, // Braille Signage
                            new { PropertiesPropertyId = 4, AccessibilityAmenitiesId = 3 }, // Wide Hallways
                            new { PropertiesPropertyId = 4, AccessibilityAmenitiesId = 6 }, // Lowered Counters
                            new { PropertiesPropertyId = 5, AccessibilityAmenitiesId = 2 }, // Elevator Access
                            new { PropertiesPropertyId = 5, AccessibilityAmenitiesId = 7 }, // Voice Control System
                            new { PropertiesPropertyId = 5, AccessibilityAmenitiesId = 8 }, // Automatic Doors
                            new { PropertiesPropertyId = 6, AccessibilityAmenitiesId = 4 }, // Grab Bars
                            new { PropertiesPropertyId = 6, AccessibilityAmenitiesId = 5 }, // Accessible Parking
                            new { PropertiesPropertyId = 7, AccessibilityAmenitiesId = 2 }, // Elevator Access
                            new { PropertiesPropertyId = 7, AccessibilityAmenitiesId = 9 }, // Visual Alerts
                            new { PropertiesPropertyId = 8, AccessibilityAmenitiesId = 3 }, // Wide Hallways
                            new { PropertiesPropertyId = 8, AccessibilityAmenitiesId = 7 }, // Voice Control System
                            new { PropertiesPropertyId = 9, AccessibilityAmenitiesId = 5 }, // Accessible Parking
                            new { PropertiesPropertyId = 9, AccessibilityAmenitiesId = 6 }, // Lowered Counters
                            new { PropertiesPropertyId = 10, AccessibilityAmenitiesId = 1 }, // Wheelchair Ramp
                            new { PropertiesPropertyId = 10, AccessibilityAmenitiesId = 2 }, // Elevator Access
                            new { PropertiesPropertyId = 10, AccessibilityAmenitiesId = 8 } // Automatic Doors
                        );
                    });


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
