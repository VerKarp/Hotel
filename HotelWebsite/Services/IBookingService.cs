using HotelWebsite.Models;

namespace HotelWebsite.Services
{
    public interface IBookingService
    {
        Task CreateAsync(Booking booking, CancellationToken cancellationToken = default);
    }
}
