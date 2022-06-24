using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers;

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

    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            // Verify Email is Unique
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View("Index");
            }
            // HashPassword to DB
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("user/login")]
    public IActionResult Login(LogUser LoginUser)
    {
        if (ModelState.IsValid)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == LoginUser.LogEmail);
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            if (userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Login Attemp");
                return View("Index");
            }
            PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
            var result = Hasher.VerifyHashedPassword(LoginUser, userInDb.Password, LoginUser.LogPassword);

            if (result == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Login Attemp");
                return View("Index");
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        List<Wedding> ViewWeddings = _context.Weddings.Include(c => c.Guests).OrderBy(a => a.WedderOne).ToList();
        return View(ViewWeddings);
    }

    [HttpGet("unRSVP/{WeddingId}")]
    public IActionResult UnInvite(int WeddingId)
    {
        Guest Uninvite = _context.Guests.SingleOrDefault(i => i.WeddingId == WeddingId && i.UserId == (int)HttpContext.Session.GetInt32("UserId"));


        _context.Guests.Remove(Uninvite);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("RSVP/{WeddingId}")]
    public IActionResult Invite(int WeddingId)
    {
        Guest Newinvite = new Guest()
        {
            WeddingId = WeddingId,
            UserId = (int)HttpContext.Session.GetInt32("UserId")
        };
        _context.Add(Newinvite);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("delete/{WeddingId}")]
    public IActionResult Divorce(int WeddingId)
    {
        Wedding Divorce = _context.Weddings
            .SingleOrDefault(a => a.WeddingId == WeddingId);

        // Then pass the object we queried for to .Remove() on Users
        _context.Weddings.Remove(Divorce);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    ////////////////////////////////////////////////////////////////////

    [HttpGet("WeddingPlanner")]
    public IActionResult WeddingPlanner()
    {

        return View("WeddingPlanner");
    }

    [HttpPost("WeddingDetails/")]
    public IActionResult ViewWeddingDetails(Wedding NewWedding)
    {
        if (ModelState.IsValid)
        {
            _context.Add(NewWedding);
            _context.SaveChanges();
            return RedirectToAction("TheWeddingDeets", new { WeddingId = NewWedding.WeddingId });
        }
        else
        {
            return View("WeddingPlanner");
        }
    }

    ///////////////////////////////////////////////////////////

    [HttpGet("WeddingDetails/{WeddingId}")]
    public IActionResult TheWeddingDeets(int WeddingId)
    {
        ViewBag.WeddingInfo = _context.Weddings.Include(a => a.Guests).ThenInclude(b => b.User).FirstOrDefault(a => a.WeddingId == WeddingId);
        return View("WeddingDetails");
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
}
