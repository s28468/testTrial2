```
git clone https://github.com/s28468/Test2
```
```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
download .net

connect to db
Check your connection string in 'appsettings.json'
  ```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server_address;Database=your_database_name;User Id=your_username;Password=your_password;"
  }
}
  ```
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
