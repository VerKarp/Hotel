using HotelWebsite.Models;

namespace HotelWebsite.ViewModels
{
    public class BookingViewModel
    {
        public Booking Booking { get; set; }
        public Guest Guest { get; set; }
        public Room Room { get; set; }
        public RoomType RoomType { get; set; }
    }
}
