using HotelApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Models
{
    public class RoomType : ModelBase
    {
        public string? Name { get; set; }
        [Column(TypeName = "money")]
        public decimal BasePrice { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<Room>? Rooms { get; set; }
    }
}
