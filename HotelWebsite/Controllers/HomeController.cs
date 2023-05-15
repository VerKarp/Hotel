using HotelWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new Booking
            { CheckIn = DateTime.Now.AddDays(1), CheckOut = DateTime.Now.AddDays(2) });
        }

        public IActionResult Contacts()
        {
            return View(new Booking
            { CheckIn = DateTime.Now.AddDays(1), CheckOut = DateTime.Now.AddDays(2) });
        }
    }
}
