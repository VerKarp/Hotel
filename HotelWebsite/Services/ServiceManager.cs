namespace HotelWebsite.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly HttpClient httpClient = new();

        private readonly Lazy<IRoomService> _lazyRoomService;
        private readonly Lazy<IRoomTypeService> _lazyRoomTypeService;
        private readonly Lazy<IGuestService> _lazyGuestService;
        private readonly Lazy<IBookingService> _lazyBookingService;

        public ServiceManager()
        {
            _lazyRoomService = new Lazy<IRoomService>(() => new RoomService(httpClient));
            _lazyRoomTypeService = new Lazy<IRoomTypeService>(() => new RoomTypeService(httpClient));
            _lazyGuestService = new Lazy<IGuestService>(() => new GuestService(httpClient));
            _lazyBookingService = new Lazy<IBookingService>(() => new BookingService(httpClient));
        }

        public IGuestService GuestService => _lazyGuestService.Value;

        public IBookingService BookingService => _lazyBookingService.Value;

        public IRoomService RoomService => _lazyRoomService.Value;

        public IRoomTypeService RoomTypeService => _lazyRoomTypeService.Value;
    }
}
