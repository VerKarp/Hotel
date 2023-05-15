using HotelApi.Data;
using HotelApi.Models;

namespace HotelApi.DAL
{
    public class UnitOfWork : IDisposable
    {
        private HotelContext context;
        private GenericRepository<Room> roomRepository;
        private GenericRepository<Guest> guestRepository;
        private GenericRepository<Booking> bookingRepository;
        private GenericRepository<AdvanceReport> advanceReportRepository;
        private GenericRepository<RoomImage> flatsImagesRepository;
        private GenericRepository<RoomType> roomTypeRepository;

        public UnitOfWork(HotelContext context)
        {
            this.context = context;
        }

        public GenericRepository<Room> RoomRepository
        {
            get
            {
                if (this.roomRepository is null)
                    this.roomRepository = new GenericRepository<Room>(context);

                return roomRepository;
            }
        }

        public GenericRepository<Guest> GuestRepository
        {
            get
            {
                if (this.guestRepository is null)
                    this.guestRepository = new GenericRepository<Guest>(context);

                return guestRepository;
            }
        }

        public GenericRepository<Booking> BookingRepository
        {
            get
            {
                if (this.bookingRepository is null)
                    this.bookingRepository = new GenericRepository<Booking>(context);

                return bookingRepository;
            }
        }

        public GenericRepository<AdvanceReport> AdvanceReportRepository
        {
            get
            {
                if (this.advanceReportRepository is null)
                    this.advanceReportRepository = new GenericRepository<AdvanceReport>(context);

                return advanceReportRepository;
            }
        }

        public GenericRepository<RoomImage> RoomImagesRepository
        {
            get
            {
                if (this.flatsImagesRepository is null)
                    this.flatsImagesRepository = new GenericRepository<RoomImage>(context);

                return flatsImagesRepository;
            }
        }

        public GenericRepository<RoomType> RoomTypeRepository
        {
            get
            {
                if (this.roomTypeRepository is null)
                    this.roomTypeRepository = new GenericRepository<RoomType>(context);

                return roomTypeRepository;
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    context.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
