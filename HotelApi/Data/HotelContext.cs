using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().ToTable(nameof(Booking))
                .HasMany(b => b.AdvanceReports)
                .WithOne(ar => ar.Booking)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoomType>().ToTable(nameof(RoomType))
                .HasMany(t => t.Rooms)
                .WithOne(r => r.RoomType)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guest>().ToTable(nameof(Guest))
                .HasMany(g => g.Bookings)
                .WithOne(b => b.Guest)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Room>().ToTable(nameof(Room))
                .HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Room>().ToTable(nameof(Room))
                .HasMany(r => r.Images)
            .WithOne(i => i.Room)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<AdvanceReport> AdvanceReports { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
    }
}
