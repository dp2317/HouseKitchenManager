    ﻿using Microsoft.AspNetCore.Mvc;
using HouseKitchenManager.Data;
using HouseKitchenManager.Models;

namespace HouseKitchenManager.Controllers
{
    public class RatingsController : Controller
    {
        private readonly AppDbContext _context;

        public RatingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(int scheduleId, int stars)
        {
            int? loggedIn = HttpContext.Session.GetInt32("MemberId");
            if (loggedIn == null) return RedirectToAction("Index", "Login");

            var schedule = _context.Schedules.Find(scheduleId);
            if (schedule.MemberId == loggedIn) return Unauthorized();

            bool alreadyRated = _context.Ratings.Any(r =>
                r.ScheduleId == scheduleId &&
                r.RaterMemberId == loggedIn);

            if (!alreadyRated)
            {
                _context.Ratings.Add(new Rating
                {
                    ScheduleId = scheduleId,
                    RaterMemberId = loggedIn.Value,
                    Stars = stars
                });

                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Schedules");
        }
    }
}
