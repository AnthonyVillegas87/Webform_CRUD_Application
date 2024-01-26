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
    
    // READ Widgets Home page
    public IActionResult Index()
    {
        List<WidgetEntity> widgets = new List<WidgetEntity>();
        
        WidgetRepository widgetRepository = new WidgetRepository();
        
        widgets = widgetRepository.GetWidgetList();
        return View(widgets);
    }
    
    
    // CREATE Widget page
    public ActionResult AddWidget()
    {
        return View();
    }

    // CREATE Widget method
    public ActionResult AddNewWidget(WidgetEntity entity)
    {
        
        try
        {
            if (ModelState.IsValid)
            {
                // Validation that entity has been successfully added
                if (entity.ReorderQuantity < 0)
                {
                    ViewBag.Message = "Unable to record Entry!";
                    return View("AddWidget");
                }
                
                WidgetRepository widgetRepository = new WidgetRepository();
                if (widgetRepository.AddWidget(entity))
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Index");
        }
        catch
        {
            return View("AddWidget");
        }
    }
    
    
    //  UPDATE Widget page
    public IActionResult UpdateWidget(int id)
    {
        WidgetRepository widgetRepository = new WidgetRepository();
        WidgetEntity widget = new WidgetEntity();
        
        widget = widgetRepository.GetWidgetById(id); 
        return View(widget); 
        
    }
    

    // Update Widget method
    public IActionResult UpdateWidgetDetails(int id, WidgetEntity details)
    {

        if (ModelState.IsValid)
        {
            WidgetRepository widgetRepository = new WidgetRepository();
            if (widgetRepository.UpdateWidgetByDetails(id, details))
            {
                return RedirectToAction("Index");
            }
           
        }
        
        
        return View("UpdateWidget");
        
    }
    
    
    // Delete Widget page
    public ActionResult DeleteWidgetView(int id)
    {
        WidgetRepository widgetRepository = new WidgetRepository();
        WidgetEntity widget = new WidgetEntity();
        
        widget = widgetRepository.GetWidgetById(id); 
        return View(widget); 
    }
    
    // Delete Widget method
    public ActionResult DeleteWidgetDetails(int id, WidgetEntity entity)
    {
            WidgetRepository widgetRepository = new WidgetRepository();
            if (widgetRepository.DeleteWidget(id, entity))
            {
                return RedirectToAction("Index");
            }

            return View("DeleteWidgetView");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}