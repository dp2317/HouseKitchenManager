using Microsoft.AspNetCore.Mvc;
using HouseKitchenManager.Data;
using HouseKitchenManager.Models;

namespace HouseKitchenManager.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        // 🔐 Admin check (used everywhere)
        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin") == "true";
        }

        // 📋 List members (ADMIN ONLY)
        public IActionResult Index()
        {
            if (!IsAdmin())
                return Unauthorized();

            var members = _context.Members.ToList();
            return View(members);
        }

        // ➕ Create page (ADMIN ONLY)
        public IActionResult Create()
        {
            if (!IsAdmin())
                return Unauthorized();

            return View();
        }

        // ➕ Create POST (ADMIN ONLY)
        [HttpPost]
        public IActionResult Create(Member member)
        {
            if (!IsAdmin())
                return Unauthorized();

            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // ❌ Delete member (ADMIN ONLY)
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
    }
}
