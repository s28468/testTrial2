```
git clone https://github.com/s28468/Test2
```
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
download .net

connect to db
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```