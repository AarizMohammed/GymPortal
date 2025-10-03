using Microsoft.AspNetCore.Mvc;

namespace GymPortal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "password123")
            {
                return RedirectToAction("Dashboard");
            }
            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
