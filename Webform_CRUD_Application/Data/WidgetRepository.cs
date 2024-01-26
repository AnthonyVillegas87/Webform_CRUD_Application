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
    
    // Method for dbo.sp_SaveWidget
    public bool AddWidget(WidgetEntity entity)
    {
        int result = 0;
        
        
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
            
        

        return result >= 1;
    }
    
    
    // Method for Update dbo.sp_UpdateWidget
    public bool UpdateWidgetByDetails(int id, WidgetEntity entity)
    {
        
        int result = 0;
        using (_sqlConnection)
        {
            SqlCommand saveCommand = new SqlCommand("sp_UpdateWidget", _sqlConnection);
            saveCommand.CommandType = System.Data.CommandType.StoredProcedure;
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
    
    
    // Method for dbo.sp_GetWidgetById
    public WidgetEntity GetWidgetById(int id)
    {
        WidgetEntity widgetClassEntity = new WidgetEntity();

        
        
            SqlCommand getCommand = new SqlCommand("sp_GetWidgetById", _sqlConnection);
            getCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter command;
            getCommand.Parameters.Add(new SqlParameter("@WidgetID", id));

            SqlDataAdapter dataAdapter = new SqlDataAdapter(getCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                widgetClassEntity = new WidgetEntity
                    {

                        WidgetId = Convert.ToInt32(dataRow["WidgetID"]),
                        InventoryCode = dataRow["InventoryCode"].ToString(),
                        Description = dataRow["Description"].ToString(),
                        QuantityOnHand = Convert.ToInt32(dataRow["QuantityOnHand"]),
                        ReorderQuantity = Convert.ToInt32(dataRow["ReorderQuantity"])


                    };

            
            }

        return widgetClassEntity;
    }
    
    
    

    // Method for dbo.sp_DeleteWidget

    public bool DeleteWidget(int id, WidgetEntity entity)
    {
        using (_sqlConnection)
        {
            SqlCommand deleteCommand = new SqlCommand("sp_DeleteWidget", _sqlConnection);
            deleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
            deleteCommand.Parameters.AddWithValue("@WidgetID", entity.WidgetId);
            deleteCommand.Parameters.AddWithValue("@InventoryCode", entity.InventoryCode);
            deleteCommand.Parameters.AddWithValue("@Description", entity.Description);
            deleteCommand.Parameters.AddWithValue("@QuantityOnHand", entity.QuantityOnHand);
            deleteCommand.Parameters.AddWithValue("@ReorderQuantity", entity.ReorderQuantity);
            
            _sqlConnection.Open();
            int rowsAffected = deleteCommand.ExecuteNonQuery();
            _sqlConnection.Close();

            return rowsAffected > 0;
        }
    }
    
    
    
}