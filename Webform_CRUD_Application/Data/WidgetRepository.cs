using System.Data;
using System.Data.SqlClient;
using Webform_CRUD_Application.Models;

namespace Webform_CRUD_Application.Data;

// This class provides access to SQL Server & encapsulates DB specific procedures
public class WidgetRepository
{
    private SqlConnection _sqlConnection;

    
    //Establish DB connectionString
    public WidgetRepository()
    {
        string dbConnection =
            "Server=localhost,1433;Database=DotNetDevSample;User=sa;Password=reallyStrongPwd123;Encrypt=false;TrustServerCertificate=true";
        _sqlConnection = new SqlConnection(dbConnection);
        
        
        
    }
    
    // Method for dbo.sp_GetWidgetList 
    public List<WidgetEntity> GetWidgetList()
    {
        List<WidgetEntity> widgetClassEntity = new List<WidgetEntity>();
        
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

        return widgetClassEntity;

    }
    
}