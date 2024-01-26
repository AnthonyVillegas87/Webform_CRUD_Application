# ASP.Net Webform CRUD Application

This is a simple ASP.Net Webform application that allows you to perform CRUD (Create, Read, Update, Delete) operations on a database table called "Widget". The application is designed to meet the following specifications:

## Application Specifications:
1. The app will open to a landing page.
2. The landing page will have a list of the entries in the "Widget" table.
3. Each entry in the list will have buttons or links to perform insert, update, and delete operations.
4. There will be a button on the landing page to initiate a create operation for a new row in the table.
5. The CRUD operations can be done on the same landing page, in a modal window, or in a separate page.
6. The app should be functional, generally pleasing to look at, and well organized.
7. The app does not need to be mobile responsive and can work in a big browser window.
8. CRUD operations against the database should be performed using Microsoft SQL Server stored procedures.
9. The app should provide basic validation to ensure successful data saving to the database, with feedback for validation errors.
10. The list should update after any changes are made to the database table.

## Database Specifications:
1. The database name is "DotNetDevSample".
2. The "Widget" table is created with the following SQL command:

```sql
CREATE TABLE dbo.[Widget] (
 WidgetID INT IDENTITY(1,1) NOT NULL,
 InventoryCode NVARCHAR(50) NOT NULL,
 Description NVARCHAR(MAX) NULL,
 QuantityOnHand INT NOT NULL,
 ReorderQuantity INT NULL
)


```

3. There are 4 main stored procedures:

a. Retrieve List of Rows in Widget Table
b. Save a new Widget
c. Delete a Widget
d. Update an existing Widget

```sql

--GET list of Widgets 
ALTER PROCEDURE dbo.sp_GetWidgetList
    AS
    BEGIN 
SELECT WidgetID, InventoryCode, Description, QuantityOnHand, ReorderQuantity
FROM dbo.widget
    END
    
 EXECUTE sp_GetWidgetList  

-- Delete a Widget
CREATE PROCEDURE dbo.sp_DeleteWidget
    @WidgetID INT
AS
BEGIN
    
    DELETE FROM dbo.widget
    WHERE WidgetID = @WidgetID;
END
 
-- Save a New Widget
ALTER PROCEDURE dbo.sp_SaveWidget
    @WidgetID INT,
    @InventoryCode NVARCHAR(50),
    @Description NVARCHAR(MAX),
    @QuantityOnHand INT,
    @ReorderQuantity INT
    AS
    BEGIN
       
       
        -- INSERT: If a record with the specified WidgetID exists, it is updated. Otherwise, a new record is inserted. 
        INSERT INTO dbo.widget  (InventoryCode, Description, QuantityOnHand, ReorderQuantity)
        VALUES (@InventoryCode, @Description, @QuantityOnHand, @ReorderQuantity);
  END
            
    
        
    
-- Get Widget By Id 
ALTER PROCEDURE dbo.sp_GetWidgetById
    @WidgetID int
    AS 
    BEGIN
        SELECT WidgetID, InventoryCode, Description, QuantityOnHand, ReorderQuantity
        FROM widget
        WHERE WidgetID = @WidgetID
    END
    
    EXECUTE sp_GetWidgetById 6
    
    
    
-- Delete a Widget
        
    ALTER PROCEDURE dbo.sp_DeleteWidget
        @WidgetID INT,
        @InventoryCode NVARCHAR(50),
        @Description NVARCHAR(MAX),
        @QuantityOnHand INT,
        @ReorderQuantity INT
    AS
    BEGIN
        DELETE FROM dbo.widget
        WHERE WidgetID = @WidgetID;
    END
    
    
   -- Update a Widget
   CREATE PROCEDURE dbo.sp_UpdateWidget
       @WidgetID INT,
       @InventoryCode NVARCHAR(50),
       @Description NVARCHAR(MAX),
       @QuantityOnHand INT,
       @ReorderQuantity INT
   AS
   BEGIN 
       UPDATE widget SET 
            InventoryCode = @InventoryCode,
           Description = @Description,
           QuantityOnHand = @QuantityOnHand,
           ReorderQuantity = @ReorderQuantity
       WHERE WidgetID = @WidgetID
   END
   
   EXECUTE sp_DeleteWidget 6



```

## Getting Started
To set up and run the application locally, follow these steps:

1. Install the .NET Framework and ASP.NET on your development machine.
2. Install Microsoft SQL Server and SQL Server Management Studio (SSMS).
3. Clone the repository from GitHub.
4. Open the project in the Rider IDE.
5. Open SSMS and connect to your SQL Server instance.
6. Create a new database named "DotNetDevSample".
7. Execute the SQL script provided to create the "Widget" table and the three stored procedures.
8. Update the connection string in the web.config file of the project to connect to your SQL Server instance and the "DotNetDevSample" database.
9. Build and run the application in the Rider IDE.
10. The application will open in your default web browser, and you can start performing CRUD operations on the "Widget" table.

## Folder Structure
The project follows a standard ASP.Net Webform folder structure. Here's an overview of the important folders and files:

- `App_Code`: Contains the C# code files for the data access layer and business logic.
- `App_Data`: Contains the SQL Server database file (MDF) for the "DotNetDevSample" database (if applicable).
- `Scripts`: Contains JavaScript files used in the application.
- `Styles`: Contains CSS files for styling the application.
- `Default.aspx`: The landing page of the application that displays the list of entries in the "Widget" table.
- `Default.aspx.cs`: The code-behind file for the Default.aspx page.
- `InsertUpdateWidget.aspx`: The page for creating a new widget or updating an existing widget.
- `InsertUpdateWidget.aspx.cs`: The code-behind file for the InsertUpdateWidget.aspx page.
- `Web.config`: Contains the application configuration settings, including the database connection string.

## Technology Stack
The application is built using the following technologies:

- ASP.NET Webforms: The framework for building web applications using .NET.
- C#: The programming language used for server-side code.
- ADO.Net: The technology used for database access.
- Microsoft SQL Server: The relational database management system.
- HTML/CSS: The markup and styling languages for the user interface.
- JavaScript: Used for client-side validation and interactivity.

## Deployment
To deploy the application to a web server or hosting service, follow these steps:

1. Publish the application from the Rider IDE.
2. Copy the published files to the web server or hosting service.
3. Set up the necessary configuration settings, such as the database connection string, on the web server or hosting service.
4. Configure the web server or hosting service to serve the ASP.Net Webform application.
5. Access the application using the provided URL.

## Conclusion
This ASP.Net Webform CRUD application provides a simple interface for managing entries in the "Widget" table. 
It allows users to perform create, read, update, and delete operations on the table using Microsoft SQL Server stored procedures. 
The application provides basic validation and updates the list in real-time after any changes to the
