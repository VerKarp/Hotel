using HotelApi.DAL;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("controller/guests")]
    [ApiController]
    public class GuestController
    {
        private readonly UnitOfWork unitOfWork;

        public GuestController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async IAsyncEnumerable<Guest> GetAllGuests()
        {
            var guests = unitOfWork.GuestRepository.Get(includeProperties: "Bookings");

            foreach (var guest in guests)
                yield return guest;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(Guid id)
        {
            var guest = unitOfWork.GuestRepository.GetByID(id);

            unitOfWork.GuestRepository.context.Entry(guest).Collection(g => g.Bookings!).Load();

            return guest;
        }

        [HttpPost("{Guest}")]
        public async Task Insert(Guest guest)
        {
            unitOfWork.GuestRepository.Insert(guest);
            await unitOfWork.SaveAsync();
        }

        [HttpPut("{Guest}")]
        public async Task Update(Guest guest)
        {
            unitOfWork.GuestRepository.Update(guest);
            await unitOfWork.SaveAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            unitOfWork.GuestRepository.Delete(id);
            await unitOfWork.SaveAsync();
        }
    }
}
