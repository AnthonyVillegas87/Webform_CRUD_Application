﻿using System.Diagnostics;
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

    
    
    
    // GET Widgets Home page
    public IActionResult Index()
    {
        List<WidgetEntity> widgets = new List<WidgetEntity>();
        
        // var config = new ConfigurationBuilder()
        //     .SetBasePath(
        //         Directory.GetCurrentDirectory())
        //     .AddJsonFile("secrets.json").Build(); 
        WidgetRepository widgetRepository = new WidgetRepository();
        
        widgets = widgetRepository.GetWidgetList();
        return View(widgets);
    }

    
    
    
    // Create Widget page
    public ActionResult AddWidget()
    {
        return View();
    }

    // Create Widget POST
    public ActionResult AddNewWidget(WidgetEntity entity)
    {
        
        try
        {
            if (ModelState.IsValid)
            {
                // // Validation that entity has been successfully added
                // if (entity.ReorderQuantity < 0)
                // {
                //     ViewBag.Message = "Unable to record Entry!";
                //     return View("AddWidget");
                // }
                
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