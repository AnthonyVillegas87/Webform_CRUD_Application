using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webform_CRUD_Application.Models;

public class WidgetEntity
{
    
    
    [Key]
    [DisplayName("ID")]
    public int WidgetId
    {
        get; 
        set; 
        
    }
    
    
    
    [DisplayName("Inventory Code")]
    [Required(ErrorMessage = "Inventory Code is required.")]

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

    [DisplayName("Quantity On Hand")]
    [Required(ErrorMessage = "Quantity On Hand is required.")]

    public int QuantityOnHand
    {
        get;
        set;
    }
    
    
    [DisplayName("Reorder Quantity")]
    public int ReorderQuantity
    {
        get;
        set;
    }
    
    
}