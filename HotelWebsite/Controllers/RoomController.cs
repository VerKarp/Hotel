using HotelWebsite.Models;
using HotelWebsite.Services;
using HotelWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebsite.Controllers
{
    public class RoomController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public RoomController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            var roomTypes = await _serviceManager.RoomTypeService.GetAllAsync();

            ViewData["RoomTypes"] = roomTypes;

            return View(new Booking
            { CheckIn = DateTime.Now.AddDays(1), CheckOut = DateTime.Now.AddDays(2) });
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var room = await _serviceManager.RoomService.GetByIdAsync(id);
            var roomType = await _serviceManager.RoomTypeService.GetByIdAsync(room.RoomTypeId);

            if (room is null)
                return NotFound();

            return View(new BookingViewModel
            {
                Room = room,
                Booking = new Booking
                {
                    RoomId = id,
                    CheckIn = DateTime.Now.AddDays(1),
                    CheckOut = DateTime.Now.AddDays(2)
                },
                RoomType = roomType
            });
        }
    }
}
