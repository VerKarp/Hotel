using HotelWebsite.Models;

namespace HotelWebsite.Services
{
    public class GuestService : IGuestService
    {
        private readonly HttpClient _httpClient;

        public GuestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAsync(Guest guest, CancellationToken cancellationToken = default)
        {
            await _httpClient.PostAsJsonAsync(
                $"https://localhost:7015/controller/guests/g", guest, cancellationToken);
        }
    }
}
