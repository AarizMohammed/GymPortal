using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GymPortal.Models;

namespace GymPortal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

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
        // 1. Custom Uniqueness Checks (Must happen first, adding errors to ModelState)
        if (members.Any(m => m.Email == model.Email))
        {
            ModelState.AddModelError("Email", "This email is already registered.");
        }

        if (members.Any(m => m.Phone == model.Phone))
        {
            ModelState.AddModelError("Phone", "This phone number is already registered.");
        }

        // 2. Check ALL Validation (Data Annotations + Unique Checks)
        if (ModelState.IsValid)
        {
            // 3. Special Case: Generate Discount (only if valid)
            if (model.MembershipType == "Yearly")
            {
                var rand = new Random();
                // Generate random discount value between 1 and 100
                model.Discount = rand.Next(1, 101);
            }
            else
            {
                model.Discount = 0; // Set discount to 0 for non-yearly members
            }

            // 4. Save Member (Only runs once, with discount saved in the model)
            members.Add(model);

            // 5. Redirect to Thank You Page, passing the model for the summary
            // The model contains the saved discount and member data.
            return RedirectToAction("ThankYou", model);
        }

        // If validation failed, return the view with errors
        return View(model);
    }
    
    public IActionResult ThankYou(MemberSignupViewModel model)
    {
        // Check if data was passed via redirect (or prevent saving if accessed directly)
        if (model == null || string.IsNullOrEmpty(model.Name))
        {
            return RedirectToAction("Index");
        }

    // Get the total count from the list (for the "Nth person" message)
        ViewBag.MemberCount = members.Count;

    // Pass the model (containing the summary/discount) to the view
        return View(model);
    }
}
