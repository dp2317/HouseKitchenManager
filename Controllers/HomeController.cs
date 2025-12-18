using Microsoft.AspNetCore.Mvc;
using HouseKitchenManager.Data;

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
    return Content("App is running");
}

        
    }
}
