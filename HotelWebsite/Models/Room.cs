namespace HotelWebsite.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid RoomTypeId { get; set; }
        public bool Available { get; set; }
        public string? Description { get; set; }

        public ICollection<RoomImage>? Images { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
