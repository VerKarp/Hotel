namespace HotelWebsite.Models
{
    public class RoomImage
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
        public Guid RoomId { get; set; }
    }
}
