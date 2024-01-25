using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration.UserSecrets;
using Webform_CRUD_Application.Models;

namespace Webform_CRUD_Application.Data;

// This class provides access to SQL Server & encapsulates DB specific procedures
public class WidgetRepository
{
    private readonly SqlConnection _sqlConnection;

    
    //Establish DB connectionString
    public WidgetRepository()
    
    {

        _sqlConnection = new SqlConnection(dbConnection);
        
    }
    
    // Method for dbo.sp_GetWidgetList 
    public List<WidgetEntity> GetWidgetList()
    {
        List<WidgetEntity> widgetClassEntity = new List<WidgetEntity>();

        using ( _sqlConnection)
        {
            SqlCommand getCommand = new SqlCommand("dbo.sp_GetWidgetList", _sqlConnection);
            getCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(getCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
        
            foreach (DataRow dataRow in dataTable.Rows)
            {
                widgetClassEntity.Add(
                    new WidgetEntity()
                    {
                    
                        WidgetId = Convert.ToInt32(dataRow["WidgetID"]),
                        InventoryCode = dataRow["InventoryCode"].ToString(),
                        Description =  dataRow["Description"].ToString(),
                        QuantityOnHand = Convert.ToInt32(dataRow["QuantityOnHand"]),
                        ReorderQuantity = Convert.ToInt32(dataRow["ReorderQuantity"])
                    
                    
                    });
            
            } 
        }
      

        return widgetClassEntity;

    }
    
    // Method to Add Widget
    public bool AddWidget(WidgetEntity entity)
    {
        int result = 0;
        using (_sqlConnection)
        {
            SqlCommand saveCommand = new SqlCommand("sp_SaveWidget", _sqlConnection);
            saveCommand.CommandType = CommandType.StoredProcedure;

            saveCommand.Parameters.AddWithValue("@WidgetID", entity.WidgetId);
            saveCommand.Parameters.AddWithValue("@InventoryCode", entity.InventoryCode);
            saveCommand.Parameters.AddWithValue("@Description", entity.Description);
            saveCommand.Parameters.AddWithValue("@QuantityOnHand", entity.QuantityOnHand);
            saveCommand.Parameters.AddWithValue("@ReorderQuantity", entity.ReorderQuantity);
            _sqlConnection.Open();
            result = saveCommand.ExecuteNonQuery();
            _sqlConnection.Close();
            
        }

        return result >= 1;
    }
    
    
    
    
    
    
    
}