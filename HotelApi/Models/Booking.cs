using HotelApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class Booking : ModelBase
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }
        public int DaysOfStay { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalFee { get; set; }
        public int Guests { get; set; }
        public bool Paid { get; set; }

        [ForeignKey("RoomId")]
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
        [ForeignKey("GuestId")]
        public Guid GuestId { get; set; }
        public virtual Guest Guest { get; set; }

        public virtual ICollection<AdvanceReport>? AdvanceReports { get; set; }
    }
}
