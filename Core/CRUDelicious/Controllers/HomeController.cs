#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

//////////////////////READ READ READ READ READ READ//////////////
    public IActionResult Index()
    {
        ViewBag.AllItems = _context.Dishes.OrderByDescending(a => a.DishId).ToList();
        return View();
    }
    ////////////////////////////////////////////////////////////////
    public IActionResult Privacy()
    {
        return View();
    }


//httpget == route
//post ==processs data

///////////////////////////////CREATE CREATE CREATE//////
[HttpGet ("/Create")]

public IActionResult Create(){
    return View();

}


[HttpPost("/Create/Process")]
public IActionResult  AddDish(Dish newDish)
{
    if(ModelState.IsValid)
    {
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    } else {
        return View("Create");
    }
}
/////////////////////////////////////////////////////////////

[HttpGet("/dish/{DishId}")]
public IActionResult Read(int DishId)
{
    Dish? DisplayOne = _context.Dishes.FirstOrDefault(b => b.DishId == DishId);

    return View("Read",DisplayOne);
}

///////////////////////////////////DELTE DELETE DELETE DELETE DELETE//////////////////////////////////

[HttpGet("dish/delete/{DishId}")]
public IActionResult DeleteDish(int DishId)
{
    Dish? dishToDelete = _context.Dishes.SingleOrDefault(a => a.DishId == DishId);
    _context.Dishes.Remove(dishToDelete);
    _context.SaveChanges();
    return RedirectToAction("Index");
}

/////////////////////////////////////Update Update


/////////////Route To Update Page
[HttpGet("dish/update/{DishId}")]
public IActionResult Update(int DishId)
{
    Dish? DisplayOne = _context.Dishes.FirstOrDefault(b => b.DishId == DishId);

    return View("Update",DisplayOne);
}

/////////////Process Update Button
[HttpPost("/Update/Process/{DishId}")]
public IActionResult UpdateDish(int DishId, Dish updateDish)
{
    
        Dish oldDish = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
        oldDish.Name = updateDish.Name;
        oldDish.Chef = updateDish.Chef;
        oldDish.Tastiness = updateDish.Tastiness;
        oldDish.Calories = updateDish.Calories;
        oldDish.Description = updateDish.Description;
        oldDish.UpdatedAt = updateDish.UpdatedAt;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }





















    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
