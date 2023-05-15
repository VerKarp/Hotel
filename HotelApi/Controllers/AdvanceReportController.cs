using HotelApi.DAL;
using HotelApi.Dto;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("controller/advanceReports")]
    [ApiController]
    public class AdvanceReportController
    {
        private readonly UnitOfWork unitOfWork;

        public AdvanceReportController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async IAsyncEnumerable<AdvanceReport> GetAllAdvanceReports()
        {
            var advanceReports = unitOfWork.AdvanceReportRepository.Get();

            foreach (var advanceReport in advanceReports)
                yield return advanceReport;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdvanceReport>> GetAdvanceReport(Guid id)
        {
            var advanceReport = unitOfWork.AdvanceReportRepository.GetByID(id);
            return advanceReport;
        }

        [HttpPost("{AdvanceReport}")]
        public async Task Insert(AdvanceReportDto advanceReport)
        {
            var a = new AdvanceReport
            {
                Date = advanceReport.Date,
                Paid = advanceReport.Paid,
                BookingId = advanceReport.BookingId,
                Booking = unitOfWork.BookingRepository.GetByID(advanceReport.BookingId)
            };

            unitOfWork.AdvanceReportRepository.Insert(a);
            await unitOfWork.SaveAsync();
        }

        [HttpPut("{AdvanceReport}")]
        public async Task Update(AdvanceReportDto advanceReport)
        {
            var a = unitOfWork.AdvanceReportRepository.GetByID(advanceReport.Id);

            a.Date = advanceReport.Date;
            a.Paid = advanceReport.Paid;
            a.BookingId = advanceReport.BookingId;
            a.Booking = unitOfWork.BookingRepository.GetByID(advanceReport.BookingId);

            unitOfWork.AdvanceReportRepository.Update(a);
            await unitOfWork.SaveAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            unitOfWork.AdvanceReportRepository.Delete(id);
            await unitOfWork.SaveAsync();
        }
    }
}
