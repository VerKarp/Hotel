using HotelWebsite.Models;
using HotelWebsite.Services;
using HotelWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelWebsite.Controllers
{
    public class BookingController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public BookingController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = TempData["Booking"];
            var booking = new Booking();

            if (value is string json)
            {
                booking = JsonConvert.DeserializeObject<Booking>(json);
            }

            var roomTypes = await _serviceManager.RoomTypeService.GetWithFreeRoomsAsync(
                booking.CheckIn, booking.CheckOut);

            ViewData["RoomTypes"] = roomTypes;

            var rooms = await _serviceManager.RoomService.GetFreeAsync(roomTypes);

            ViewData["Rooms"] = rooms;
            TempData["Booking"] = JsonConvert.SerializeObject(booking);

            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Booking booking)
        {
            if (booking.CheckIn == default)
                booking.CheckIn = DateTime.Now.AddDays(1);

            if (booking.CheckOut == default)
                booking.CheckOut = DateTime.Now.AddDays(2);

            booking.DaysOfStay = (int)(booking.CheckOut - booking.CheckIn).TotalDays;
            booking.Id = Guid.NewGuid();

            TempData["Booking"] = JsonConvert.SerializeObject(booking);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Booking(Booking booking)
        {
            var room = await _serviceManager.RoomService.GetByIdAsync(booking.RoomId);

            var roomType = await _serviceManager.RoomTypeService.GetByIdAsync(room.RoomTypeId);

            booking.TotalFee = (int)(booking.CheckOut - booking.CheckIn).TotalDays * roomType!.BasePrice;
            booking.Guests = 1;

            return View(new BookingViewModel
            {
                Booking = booking,
                Room = room,
                RoomType = roomType
            });
        }

        public async Task<IActionResult> Booked(BookingViewModel bookingViewModel,
            [FromServices] EmailService email)
        {
            bookingViewModel.Guest.Id = Guid.NewGuid();

            await _serviceManager.GuestService.CreateAsync(bookingViewModel.Guest);

            bookingViewModel.Booking.Id = Guid.NewGuid();
            bookingViewModel.Booking.GuestId = bookingViewModel.Guest.Id;

            await _serviceManager.BookingService.CreateAsync(bookingViewModel.Booking);

            email.Send(bookingViewModel.Guest.Email!);

            bookingViewModel.Room = await _serviceManager.RoomService.GetByIdAsync(
                bookingViewModel.Booking.RoomId);

            bookingViewModel.RoomType = await _serviceManager.RoomTypeService.GetByIdAsync(
                bookingViewModel.Room.RoomTypeId);

            return View(bookingViewModel);
        }
    }
}
