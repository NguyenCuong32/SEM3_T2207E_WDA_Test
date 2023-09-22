using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using exam.Models;
using exam.Repository;
using Microsoft.EntityFrameworkCore;

namespace exam.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _dataContext;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, DataContext context)
    {
        _logger = logger;
        _dataContext = context;
    }

    public IActionResult Index()
    {
        var viewEmploy = _dataContext.Employees.ToList();
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
}

