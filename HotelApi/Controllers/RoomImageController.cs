using HotelApi.DAL;
using HotelApi.Dto;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("controller/roomImage")]
    [ApiController]
    public class RoomImageController
    {
        private readonly UnitOfWork unitOfWork;

        public RoomImageController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async IAsyncEnumerable<RoomImage> GetAllRoomImages()
        {
            var roomImages = unitOfWork.RoomImagesRepository.Get();

            foreach (var roomImage in roomImages)
                yield return roomImage;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomImage>> GetRoomImage(Guid id)
        {
            var roomImage = unitOfWork.RoomImagesRepository.GetByID(id);

            return roomImage;
        }

        [HttpPost("{RoomImage}")]
        public async Task Insert(RoomImageDto roomImage)
        {
            var i = new RoomImage
            {
                ImageUrl = roomImage.ImageUrl,
                RoomId = roomImage.RoomId,
                Room = unitOfWork.RoomRepository.GetByID(roomImage.RoomId)
            };

            unitOfWork.RoomImagesRepository.Insert(i);
            await unitOfWork.SaveAsync();
        }

        [HttpPut("{RoomImage}")]
        public async Task Update(RoomImageDto roomImage)
        {
            var i = unitOfWork.RoomImagesRepository.GetByID(roomImage.Id);

            i.ImageUrl = roomImage.ImageUrl;
            i.RoomId = roomImage.RoomId;
            i.Room = unitOfWork.RoomRepository.GetByID(roomImage.RoomId);

            unitOfWork.RoomImagesRepository.Update(i);
            await unitOfWork.SaveAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            unitOfWork.RoomImagesRepository.Delete(id);
            await unitOfWork.SaveAsync();
        }
    }
}
