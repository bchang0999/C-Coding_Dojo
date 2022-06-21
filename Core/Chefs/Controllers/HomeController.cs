using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chefs.Models;


namespace Chefs.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger,  MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.AllItems=_context.Cooks.OrderBy(a => a.Fname).Include(Chef=>Chef.CreatedDishes).ToList(); 
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("new")]
    public IActionResult NewChefPage()
    {
        return View("new");
    }

    [HttpPost("process")]
    public IActionResult AddChef(Chef Newchef)

    {
        if (ModelState.IsValid)
        {
            if (DateTime.Now.Year - Newchef.DOB.Year < 18){
                ModelState.AddModelError("DOB","Must be 18 or Older");
                return View("NewChefPage");
            }
            _context.Add(Newchef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("new");
        }
    }

    [HttpGet("meals")]
    public IActionResult DishPage()
    {
        ViewBag.AllItems=_context.dishes.OrderBy(a => a.Name).Include(Chef=>Chef.Creator).ToList();
        return View("meals");
    }
    [HttpGet("newDish")]
    public IActionResult NewDishPage()
    {
        ViewBag.Cooks=_context.Cooks.OrderBy(a => a.Fname).ToList();
        return View("newDish");
    }

[HttpPost("meals/process")]
    public IActionResult AddDish(Dish newDish)

    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("DishPage");
        }
        else
        {
            ViewBag.Cooks=_context.Cooks.OrderBy(a => a.Fname).ToList();
            return View("newDish");
        }
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
