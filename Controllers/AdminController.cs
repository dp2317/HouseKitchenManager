using Microsoft.AspNetCore.Mvc;
using HouseKitchenManager.Data;
using HouseKitchenManager.Models;

namespace HouseKitchenManager.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin") == "true";
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Invalid admin credentials";
            return View();
        }

        public IActionResult Index()
        {
            if (!IsAdmin())
                return RedirectToAction("Login");

            var members = _context.Members.ToList();
            return View(members);
        }

        [HttpPost]
        public IActionResult AddMember(string name, string colorHex)
        {
            if (!IsAdmin())
                return Unauthorized();

            // 🔐 Auto-generate username & password
            var username = name.ToLower().Replace(" ", "");
            var password = $"{name.Substring(0, 1).ToUpper()}@123";

            var member = new Member
            {
                Name = name,
                Username = username,
                Password = password,
                ColorHex = colorHex
            };

            _context.Members.Add(member);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!IsAdmin())
                return Unauthorized();

            var member = _context.Members.Find(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Login");
        }
    }
}
