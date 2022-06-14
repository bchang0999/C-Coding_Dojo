using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Batman.Models;

namespace Batman.Controllers;

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


    [HttpPost("Process")]
    public IActionResult Process(User result)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Result", result);
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("Result")]
    public IActionResult Result(User result)
    {
        ViewBag.form = result;
        return View(result);
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
