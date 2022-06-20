using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndValidation.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginAndValidation.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                // Manually add a ModelState error to the Email field, with provided
                // error message
                ModelState.AddModelError("Email", "Email already in use!");
                return View("Index");

                // You may consider returning to the View at this point
            }
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("success")]
    public IActionResult Success()
    {
        return View();
    }

    [HttpGet("LogIn")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPostAttribute("LogIn/Processing")]
    public IActionResult LoggingIn(LogUser loginUser)
    {
        if (ModelState.IsValid)
        {
            User userInDb = _context.Users.FirstOrDefault(a => a.Email == loginUser.LogEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Login Attemp");
                return View("Login");
            }
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();

            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);

            if (result == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Login Attemp");
                return View("Login");
            }
            else
            {
                return RedirectToAction("Success");
            }
        }
        else
        {
            return View("LogIn");
        }
    }
















    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
