# ExampleWebApi
It is a ASP .NET Core Web API project handling basic HTTP verbs i.e GET, POST, PUT, DELETE.
Entities that SqlServer database stores are Video Game Development Companies.

Project created thanks to ASP .NET Core Course at:
-	Part 1 : [ASP.NET Core - Tworzenie aplikacji webowych #1](https://www.youtube.com/watch?v=Pqs6wxnwb9E)
-	Part 2 : [ASP.NET Core - Tworzenie aplikacji webowych #2](https://www.youtube.com/watch?v=96OSEglK_ro)
-	Part 3 : [ASP.NET Core Web API - Logowanie (Autentykacja) użytkowników](https://www.youtube.com/watch?v=exKLvxaPI6Y)
-	Part 4 : [ASP.NET Core Web API - Autoryzacja użytkowników](https://www.youtube.com/watch?v=Ei7Uk-UgSAY)

# Dependencies 
**NuGet** packages :
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- NLog.Web.AspNetCore
- Swashbuckle.AspNetCore
- Microsoft.AspNetCore.Authentication.JwtBearer
- FluentValidation.AspNetCore

# Entities
Database holds **video game companies** that contains **head quarters address** and their example products (**games**).

![Entities](https://github.com/N-janas/Assets/blob/main/ExampleWebAPI/entities.PNG "Entities")
