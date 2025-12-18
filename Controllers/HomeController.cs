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
            var members = _context.Members.ToList();

            var summary = members.Select(m => new
            {
                m.Id,
                m.Name,
                m.ColorHex,

                TotalCookDays = _context.Schedules
                    .Count(s => s.MemberId == m.Id),

                AvgRating = _context.Ratings
                    .Where(r => _context.Schedules
                        .Any(s => s.Id == r.ScheduleId && s.MemberId == m.Id))
                    .Select(r => (double?)r.Stars)
                    .Average() ?? 0
            }).ToList();

            ViewBag.Summary = summary;

            return View();
        }
    }
}
