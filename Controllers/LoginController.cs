using Microsoft.AspNetCore.Mvc;
using HouseKitchenManager.Data;

namespace HouseKitchenManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var member = _context.Members
                .FirstOrDefault(m => m.Username == username && m.Password == password);

            if (member == null)
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }

            HttpContext.Session.SetInt32("MemberId", member.Id);
            return RedirectToAction("Index", "Home");
        }
    }
}
