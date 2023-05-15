namespace HotelWebsite.Services
{
    public interface IServiceManager
    {
        IRoomService RoomService { get; }
        IRoomTypeService RoomTypeService { get; }
        IGuestService GuestService { get; }
        IBookingService BookingService { get; }
    }
}
