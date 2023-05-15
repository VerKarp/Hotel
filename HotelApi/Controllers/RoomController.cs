using HotelApi.DAL;
using HotelApi.Dto;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("controller/rooms")]
    [ApiController]
    public class RoomController
    {
        private readonly UnitOfWork unitOfWork;

        public RoomController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async IAsyncEnumerable<Room> GetAllRooms()
        {
            var rooms = unitOfWork.RoomRepository.Get(includeProperties: "Bookings,Images");

            foreach (var room in rooms)
                yield return room;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(Guid id)
        {
            var room = unitOfWork.RoomRepository.GetByID(id);

            unitOfWork.RoomRepository.context.Entry(room).Collection(r => r.Images!).Load();
            unitOfWork.RoomRepository.context.Entry(room).Collection(r => r.Bookings!).Load();

            return room;
        }

        [HttpPost("{Room}")]
        public async Task Insert(RoomDto room)
        {
            var r = new Room
            {
                Number = room.Number,
                Available = room.Available,
                Description = room.Description,
                RoomTypeId = room.RoomTypeId,
                RoomType = unitOfWork.RoomTypeRepository.GetByID(room.RoomTypeId)
            };

            unitOfWork.RoomRepository.Insert(r);
            await unitOfWork.SaveAsync();
        }

        [HttpPut("{Room}")]
        public async Task Update(RoomDto room)
        {
            var r = unitOfWork.RoomRepository.GetByID(room.Id);

            r.Description = room.Description;
            r.Number = room.Number;
            r.Available = room.Available;
            r.RoomTypeId = room.RoomTypeId;
            r.RoomType = unitOfWork.RoomTypeRepository.GetByID(room.RoomTypeId);

            unitOfWork.RoomRepository.Update(r);
            await unitOfWork.SaveAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            unitOfWork.RoomRepository.Delete(id);
            await unitOfWork.SaveAsync();
        }
    }
}
