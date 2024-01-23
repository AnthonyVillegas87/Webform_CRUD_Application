using Microsoft.AspNetCore.Mvc;
using Webform_CRUD_Application.Data;
using Webform_CRUD_Application.Models;

namespace Webform_CRUD_Application.Controllers;

public class WidgetController : Controller
{
    public IActionResult Index()
    {
        
        List<WidgetEntity> widgets = new List<WidgetEntity>();
        WidgetRepository widgetRepository = new WidgetRepository();
        widgets = widgetRepository.GetWidgetList();
        return View(widgets);
    }
    
}