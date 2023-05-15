using HotelWebsite.Models;

namespace HotelWebsite.Services
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAsync(Booking booking, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsJsonAsync(
                $"https://localhost:7015/controller/bookings/b", booking, cancellationToken);
        }
    }
}
