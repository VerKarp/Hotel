using HotelApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Models
{
    public class RoomImage : ModelBase
    {
        public string? ImageUrl { get; set; }

        [ForeignKey("RoomId")]
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
