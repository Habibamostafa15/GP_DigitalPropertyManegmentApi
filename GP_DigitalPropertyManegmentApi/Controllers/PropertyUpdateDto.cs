namespace GP_DigitalPropertyManegmentApi.Controllers
{
    public class PropertyUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PropertyType { get; set; }
        public double Size { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Governate { get; set; }
    }
}
