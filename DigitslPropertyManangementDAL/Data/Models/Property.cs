

using DigitslPropertyManangementDAL.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class Property : BaseEntity
    {
      

        [Key]
        public int PropertyId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string PropertyType { get; set; }
        [Required]
        public string Status { get; set; } = "Pending";
        [Required]
        public double Size { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        [Required]
        public bool Furnished { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
       public string ListingType {  get; set; }

        public string? LocationUrl {  get; set; }
        [Required]
        public DateTime ListedAt { get; set; } = DateTime.UtcNow;
        // Address Information
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Governate { get; set; }
        [Required]

        //Location
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }


        //Navigation Properties
        // OneToMany With PropertyImage
        public ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();

        // OneToMany With User
        public int ?UserId { get; set; }
        public virtual User User { get; set; }


        //ManyToMany
        public ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
        public ICollection<UserPropertyReview> UserPropertyReviews { get; set; } 
        public ICollection<UserPropertyFavorite> UserPropertyFavorites { get; set; }
        public ICollection<UserPropertyPayment> UserPropertyPayments { get; set; }
        public ICollection<UserPropertyDocument> UserPropertyDocuments { get; set; }
        public virtual ICollection<AccessibillityAmenity> AccessibilityAmenities { get; set; } = new List<AccessibillityAmenity>();
        public virtual ICollection<ExternalAmenity> ExternalAmenities { get; set; } = new List<ExternalAmenity>();
        public virtual ICollection<InternalAmenity> InternalAmenities { get; set; } = new List<InternalAmenity>();

    }
}
