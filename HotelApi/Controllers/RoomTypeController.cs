using HotelApi.DAL;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("controller/roomType")]
    [ApiController]
    public class RoomTypeController
    {
        private readonly UnitOfWork unitOfWork;

        public RoomTypeController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async IAsyncEnumerable<RoomType> GetAllRoomTypes()
        {
            var roomTypes = unitOfWork.RoomTypeRepository.Get(
                includeProperties: "Rooms,Rooms.Images,Rooms.Bookings");

            foreach (var roomType in roomTypes)
                yield return roomType;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomType>> GetRoomType(Guid id)
        {
            var roomType = unitOfWork.RoomTypeRepository.GetByID(id);

            unitOfWork.RoomTypeRepository.context.Entry(roomType).Collection(t => t.Rooms!).Load();

            return roomType;
        }

        [HttpPost("{RoomType}")]
        public async Task Insert(RoomType roomType)
        {
            unitOfWork.RoomTypeRepository.Insert(roomType);
            await unitOfWork.SaveAsync();
        }

        [HttpPut("{RoomType}")]
        public async Task Update(RoomType roomType)
        {
            unitOfWork.RoomTypeRepository.Update(roomType);
            await unitOfWork.SaveAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            unitOfWork.RoomTypeRepository.Delete(id);
            await unitOfWork.SaveAsync();
        }
    }
}
