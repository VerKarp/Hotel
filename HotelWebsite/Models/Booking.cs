namespace HotelWebsite.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int DaysOfStay { get; set; }
        public decimal TotalFee { get; set; }
        public int Guests { get; set; }
        public bool Paid { get; set; }

        public Guid RoomId { get; set; }
        public Guid GuestId { get; set; }
    }
}
