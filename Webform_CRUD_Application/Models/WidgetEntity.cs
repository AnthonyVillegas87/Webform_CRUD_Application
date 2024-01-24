using System.ComponentModel.DataAnnotations;

namespace Webform_CRUD_Application.Models;

public class WidgetEntity
{
    [Key]
    
    public int WidgetId
    {
        get; 
        set; 
        
    }

    public string InventoryCode
    {
        get; 
        set; 
        
    }

    public string Description
    {
        get; 
        set; 
        
    }


    public int QuantityOnHand
    {
        get;
        set;
    }

    public int ReorderQuantity
    {
        get;
        set;
    }
    
    
}