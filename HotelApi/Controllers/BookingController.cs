using HotelApi.DAL;
using HotelApi.Dto;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("controller/bookings")]
    [ApiController]
    public class BookingController
    {
        private readonly UnitOfWork unitOfWork;

        public BookingController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async IAsyncEnumerable<Booking> GetAllBookings()
        {
            var bookings = unitOfWork.BookingRepository.Get(
                includeProperties: "AdvanceReports");

            foreach (var booking in bookings)
                yield return booking;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(Guid id)
        {
            var booking = unitOfWork.BookingRepository.GetByID(id);

            unitOfWork.BookingRepository.context.Entry(booking).Collection(a => a.AdvanceReports!).Load();

            return booking;
        }

        [HttpPost("{Booking}")]
        public async Task Insert(BookingDto booking)
        {
            var b = new Booking
            {
                CheckOut = booking.CheckOut,
                CheckIn = booking.CheckIn,
                GuestId = booking.GuestId,
                RoomId = booking.RoomId,
                Guests = booking.Guests,
                DaysOfStay = booking.DaysOfStay,
                TotalFee = booking.TotalFee,
                Paid = booking.Paid,
                Room = unitOfWork.RoomRepository.GetByID(booking.RoomId),
                Guest = unitOfWork.GuestRepository.GetByID(booking.GuestId)
            };

            unitOfWork.BookingRepository.Insert(b);
            await unitOfWork.SaveAsync();
        }

        [HttpPut("{Booking}")]
        public async Task Update(BookingDto booking)
        {
            var b = unitOfWork.BookingRepository.GetByID(booking.Id);

            b.CheckOut = booking.CheckOut;
            b.CheckIn = booking.CheckIn;
            b.GuestId = booking.GuestId;
            b.RoomId = booking.RoomId;
            b.Guests = booking.Guests;
            b.DaysOfStay = booking.DaysOfStay;
            b.TotalFee = booking.TotalFee;
            b.Paid = booking.Paid;
            b.Room = unitOfWork.RoomRepository.GetByID(booking.RoomId);
            b.Guest = unitOfWork.GuestRepository.GetByID(booking.GuestId);

            unitOfWork.BookingRepository.Update(b);
            await unitOfWork.SaveAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            unitOfWork.BookingRepository.Delete(id);
            await unitOfWork.SaveAsync();
        }
    }
}
