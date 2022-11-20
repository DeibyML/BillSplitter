using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GroupG_Assignment4.Models;

namespace GroupG_Assignment4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Bill bill = new Bill();
        return View(bill);
    }

    [HttpPost]
    public IActionResult Index(Bill bill)
    {
        bill.Total = bill.CalculateTotalAmount();
        bill.IndividualAmount = bill.CalculateIndividualAmount();
        return View(bill);
    }
}