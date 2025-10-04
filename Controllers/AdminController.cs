using Microsoft.AspNetCore.Mvc;
using GymPortal.Models;

namespace GymPortal.Controllers
{
    public class AdminController : Controller
    {
        //for reference
        private readonly IMemberRepository _memberRepository;
        public AdminController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        //IactionResult methods for each view
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
