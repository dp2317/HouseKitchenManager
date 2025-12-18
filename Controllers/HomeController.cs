using Microsoft.AspNetCore.Mvc;
using HouseKitchenManager.Data;
using System.Linq;

namespace HouseKitchenManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

       public IActionResult Index()
{
    var summary = _context.Members
        .Select(m => new
        {
            m.Id,
            m.Name,
            m.ColorHex,

            TotalCookDays = _context.Schedules
                .Count(s => s.MemberId == m.Id),

            AvgRating = (
                from r in _context.Ratings
                join s in _context.Schedules
                    on r.ScheduleId equals s.Id
                where s.MemberId == m.Id
                select (double?)r.Stars
            ).Average() ?? 0
        })
        .ToList();

    ViewBag.Summary = summary;
    return View();
}

    }
}
