using Microsoft.AspNetCore.Mvc;
using HouseKitchenManager.Data;

namespace HouseKitchenManager.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly AppDbContext _context;

        public NotificationsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notifications = _context.Notifications
                .OrderByDescending(n => n.CreatedAt)
                .ToList();

            return View(notifications);
        }
    }
}
