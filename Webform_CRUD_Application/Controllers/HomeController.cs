using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Webform_CRUD_Application.Data;
using Webform_CRUD_Application.Models;

namespace Webform_CRUD_Application.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<WidgetEntity> widgets = new List<WidgetEntity>();
        WidgetRepository widgetRepository = new WidgetRepository();
        widgets = widgetRepository.GetWidgetList();
        return View(widgets);
    }
    
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}