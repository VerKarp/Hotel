using HotelApi.Models.Base;

namespace HotelApi.Models
{
    public class Guest : ModelBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
