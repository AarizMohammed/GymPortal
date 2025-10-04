using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GymPortal.Models;

namespace GymPortal.Controllers;

public class HomeController : Controller
{
    //for reference
    private readonly ILogger<HomeController> _logger;
    private readonly IMemberRepository _memberRepository;

    //constructor definition
    public HomeController(ILogger<HomeController> logger, IMemberRepository memberRepository)
    {
        _logger = logger;
        _memberRepository = memberRepository;
    }


    //IactionResult methods for each view
    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Fees()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private static List<MemberSignupViewModel> members = new List<MemberSignupViewModel>();

    public IActionResult Join(MemberSignupViewModel model)
    {
        // 1. Check Unique Constraints (Email, Phone)
        if (members.Any(m => m.Email == model.Email))
        {
            ModelState.AddModelError("Email", "This email is already registered.");
        }

        if (members.Any(m => m.Phone == model.Phone))
        {
            ModelState.AddModelError("Phone", "This phone number is already registered.");
        }

        
        if (ModelState.IsValid)
        {
            
            if (model.MembershipType == "Yearly")
            {
                var rand = new Random();
                
                model.Discount = rand.Next(1, 101);
            }


            else
            {
                model.Discount = 0; 
            }

            
            members.Add(model);

            
            return RedirectToAction("ThankYou", model);
        }

        
        return View(model);
    }
    
    public IActionResult ThankYou(MemberSignupViewModel model)
    {
        
        if (model == null || string.IsNullOrEmpty(model.Name))
        {
            return RedirectToAction("Index");
        }

    
        ViewBag.MemberCount = members.Count;

    
        return View(model);
    }
}
