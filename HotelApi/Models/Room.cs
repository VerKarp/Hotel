using HotelApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Models
{
    public class Room : ModelBase
    {
        public int Number { get; set; }
        [ForeignKey("RoomTypeId")]
        public Guid RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        [Column(TypeName = "money")]
        public bool Available { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Booking>? Bookings { get; set; }
        public virtual ICollection<RoomImage>? Images { get; set; }
    }
}
