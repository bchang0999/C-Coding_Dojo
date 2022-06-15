using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RPass.Models;

namespace RPass.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetString("Assignment", "Randomizer Thingy");
        string? user = HttpContext.Session.GetString("Assignemnt");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public static int counter= 0;

    [HttpGet("process")]
    public IActionResult show()
    {
        string answer = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!";
        char[] BlankArr = new char[14];
        Random rand = new Random();
        for (int i = 0; i < 14; i++)
        {
            BlankArr[i] = answer[rand.Next(0, answer.Length)];
            {
                string finalize = string.Join("", BlankArr);
                ViewBag.final = finalize;
            }

        }
                counter++;
                string counted = string.Join("", counter);
                ViewBag.counted = counter;
                return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
