using HotelWebsite.Models;

namespace HotelWebsite.Services
{
    public class RoomService : IRoomService
    {
        private readonly HttpClient _httpClient;

        public RoomService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Room>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var rooms = await _httpClient.GetFromJsonAsync<List<Room>>(
                "https://localhost:7015/controller/rooms", cancellationToken);

            return rooms;
        }

        public async Task<Room> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var room = await _httpClient.GetFromJsonAsync<Room>(
                $"https://localhost:7015/controller/rooms/{id}", cancellationToken);

            return room;
        }

        public Task<IEnumerable<Room>> GetFreeAsync(IEnumerable<RoomType> types)
        {
            List<Room> roomsList = new();

            foreach (var type in types)
            {
                if (type.Rooms is not null)
                    roomsList.AddRange(type!.Rooms);
            };

            IEnumerable<Room> rooms = roomsList;

            return Task.FromResult(rooms);
        }
    }
}
