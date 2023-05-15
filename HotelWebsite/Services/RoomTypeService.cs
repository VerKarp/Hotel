using HotelWebsite.Models;

namespace HotelWebsite.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly HttpClient _httpClient;

        public RoomTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RoomType>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var roomTypes = await _httpClient.GetFromJsonAsync<List<RoomType>>(
                "https://localhost:7015/controller/roomType");

            return roomTypes;
        }

        public async Task<RoomType> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var roomType = await _httpClient.GetFromJsonAsync<RoomType>(
                $"https://localhost:7015/controller/roomType/{id}", cancellationToken);

            return roomType;
        }

        public async Task<IEnumerable<RoomType>> GetWithFreeRoomsAsync(DateTime checkIn, DateTime checkOut,
            CancellationToken cancellationToken = default)
        {
            var roomTypes = await _httpClient.GetFromJsonAsync<List<RoomType>>(
                "https://localhost:7015/controller/roomType", cancellationToken);

            foreach (var type in roomTypes!)
            {
                foreach (var room in type.Rooms!)
                {
                    room.Bookings = room.Bookings!.Where(b =>
                    (b.CheckIn <= checkIn && b.CheckOut >= checkIn) ||
                    (b.CheckIn <= checkIn && b.CheckOut >= checkOut) ||
                    (b.CheckIn >= checkIn && b.CheckOut <= checkOut) ||
                    (b.CheckIn <= checkOut && b.CheckOut >= checkOut))
                    .ToList();
                }
            }

            foreach (var type in roomTypes)
            {
                type.Rooms = type.Rooms!.Where(r => r.Bookings!.All(b => b.RoomId != r.Id)).ToList();
            }

            return roomTypes;
        }
    }
}
