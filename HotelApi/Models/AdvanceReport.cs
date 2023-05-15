using HotelApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class AdvanceReport : ModelBase
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Column(TypeName = "money")]
        public decimal Paid { get; set; }

        [ForeignKey("BookingId")]
        public Guid BookingId { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
