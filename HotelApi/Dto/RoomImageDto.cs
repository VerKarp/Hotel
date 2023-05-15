namespace HotelApi.Dto
{
    public class RoomImageDto
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }

        public Guid RoomId { get; set; }
    }
}
