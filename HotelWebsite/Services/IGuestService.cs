using HotelWebsite.Models;

namespace HotelWebsite.Services
{
    public interface IGuestService
    {
        Task CreateAsync(Guest guest, CancellationToken cancellationToken = default);
    }
}
