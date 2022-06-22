using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PAC.Models;
using Microsoft.EntityFrameworkCore;

namespace PAC.Controllers;

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
        ViewBag.AllItems = _context.Products.OrderBy(a => a.Name).ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }



    [HttpPost("/create")]
    public IActionResult AddProduct(Product NewProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Add(NewProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.AllItems = _context.Products.OrderBy(a => a.Name).ToList();
            return View("Index");
        }

    }



    //////////////////Read CAtegories/////////////////////////////

    [HttpGet("/categories")]
    public IActionResult ViewCategories(int ProductId)
    {
        ViewBag.AllItems = _context.Categories.OrderBy(a => a.Name).ToList();
        return View("ReadCategories");
    }

    [HttpPost("/CreateCategories")]
    public IActionResult AddCategory(Category NewCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Add(NewCategory);
            _context.SaveChanges();
            return RedirectToAction("ViewCategories");
        }
        else
        {
            ViewBag.AllItems = _context.Categories.OrderBy(a => a.Name).ToList();
            return View("ReadCategories");
        }

    }
    //////////////////Add CAtegories/////////////////////////////

    [HttpGet("Product/{ProductId}")]
    public IActionResult ViewProduct(int ProductId)
    {

        ViewBag.One = _context.Products.Include(a => a.ListedCategories).ThenInclude(b => b.Category).FirstOrDefault(c => c.ProductId == ProductId);

        ViewBag.CategoriesName = _context.Categories.Include(d => d.ProductsInCategory).Where(d => d.ProductsInCategory.All(x => x.ProductId != ProductId)).ToList();

        return View("AddCategories");
    }

    [HttpPost("AddCategory/{ProductId}")]
    public IActionResult AddCategoryToProduct(int CategoryId, int ProductId)
    {
        Association NewCategoryAddOn = new Association()
        {
            CategoryId = CategoryId,
            ProductId = ProductId
        };
        _context.Add(NewCategoryAddOn);
        _context.SaveChanges();
        return Redirect($"/Product/{ProductId}");

}
//////////////////Add Product/////////////////////////////
    [HttpGet("Category/{CategoryId}")]
    public IActionResult ViewCategory(int CategoryId)
    {

        ViewBag.Two = _context.Categories.Include(a => a.ProductsInCategory).ThenInclude(b => b.Product).FirstOrDefault(c => c.CategoryId == CategoryId);


        ViewBag.ProductsName = _context.Products.Include(d => d.ListedCategories).Where(d => d.ListedCategories.All(x => x.CategoryId != CategoryId)).ToList();

        return View("AddProducts");
    }

    [HttpPost("AddProduct/{CategoryId}")]
    public IActionResult AddProductToCategory(int ProductId, int CategoryId)
    {
        Association NewProductAddOn = new Association()
        {
            ProductId = ProductId,
            CategoryId = CategoryId
        };
        _context.Add(NewProductAddOn);
        _context.SaveChanges();
        return Redirect($"/Category/{CategoryId}");

}














[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public IActionResult Error()
{
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
}
