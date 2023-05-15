using HotelWebsite.Models;

namespace HotelWebsite.Services
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomType>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<RoomType> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<RoomType>> GetWithFreeRoomsAsync(DateTime checkIn, DateTime checkOut,
            CancellationToken cancellationToken = default);
    }
}
