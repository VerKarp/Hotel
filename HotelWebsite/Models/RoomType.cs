namespace HotelWebsite.Models
{
    public class RoomType
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal BasePrice { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<Room>? Rooms { get; set; }
    }
}
