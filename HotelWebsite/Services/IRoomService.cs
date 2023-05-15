using HotelWebsite.Models;

namespace HotelWebsite.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Room> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Room>> GetFreeAsync(IEnumerable<RoomType> types);
    }
}
