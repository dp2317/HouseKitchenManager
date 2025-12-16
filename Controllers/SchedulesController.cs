using Microsoft.AspNetCore.Mvc;
using HouseKitchenManager.Data;
using HouseKitchenManager.Models;

namespace HouseKitchenManager.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly AppDbContext _context;

        public SchedulesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int? loggedIn = HttpContext.Session.GetInt32("MemberId");

            if (loggedIn == null)
                return RedirectToAction("Index", "Login");

            ViewBag.Members = _context.Members.ToList();
            ViewBag.LoggedInMember = loggedIn;

            var schedules = _context.Schedules
                .OrderBy(s => s.CookDate)
                .ToList();

            return View(schedules);
        }


        [HttpPost]
        public IActionResult Save(DateTime cookDate)
        {
            int? loggedIn = HttpContext.Session.GetInt32("MemberId");

            if (loggedIn == null)
                return RedirectToAction("Index", "Login");

            // 1️⃣ Save cooking record
            var schedule = new Schedule
            {
                MemberId = loggedIn.Value,
                CookDate = cookDate
            };

            _context.Schedules.Add(schedule);
            _context.SaveChanges();

            // 2️⃣ SAVE NOTIFICATION (THIS WAS MISSING OR WRONG)
            var member = _context.Members.Find(loggedIn.Value);

            _context.Notifications.Add(new Notification
            {
                Message = $"📅 {cookDate:dd MMM yyyy} – Cooking done by {member.Name}",
                CreatedAt = DateTime.Now
            });

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
