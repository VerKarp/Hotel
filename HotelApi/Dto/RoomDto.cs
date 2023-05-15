namespace HotelApi.Dto
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public bool Available { get; set; }
        public string? Description { get; set; }

        public Guid RoomTypeId { get; set; }
    }
}
