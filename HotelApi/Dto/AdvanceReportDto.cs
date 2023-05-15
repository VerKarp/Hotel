namespace HotelApi.Dto
{
    public class AdvanceReportDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Paid { get; set; }
        public bool IsCash { get; set; }

        public Guid BookingId { get; set; }
    }
}
