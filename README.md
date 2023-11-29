# basitsatinalim
**_basitsatinalim_** is an basic e-commerce application which written by using C# ASP .NET Core MVC.
***
## Features
- Authentication and Authorization
- Products Page, Product Detail Page, Profile and Cart Section.
- People can order by using their credit cart

***

## Tech

basitsatinalim uses a number of open source library to work properly:

- [ASP.NET CORE MVC] - ASP .NET Core MVC is a rich framework for building web apps and APIs using the Model-View-Controller design pattern.
- [Entity Framework] - Entity Framework is a modern object-relation mapper that lets you build a clean, portable, and high-level data access layer with .NET (C#).
- [PostgreSql] - PostgreSQL is a powerful, open source object-relational database system.
- [Bootstrap] - Bootstrap is a css framework for building responsive, powerful html pages.
- [Alpine.js] - Alpine.js is a lightweight js library. It's working like vue and angularjs so you can use alpinejs inside your html tags. Alpine.js has so much powerful feature like global store, binding, magics that can manipulate elements etc.

## Installation

basitsatinalim requires [ASP.NET CORE](https://learn.microsoft.com/tr-tr/aspnet/core/mvc/overview?view=aspnetcore-7.0) 7.0 to run. Also you need a postgresql server.

> Note: You can use Docker to run your postgresql server

Before installing packages and starting project, we will run an postgresql server and will use Docker for this in this doc.

### Docker
```sh
cd basitsatinalim/docs
docker-compose -f docker-compose.yml up
```
After this step your `postgresql` server will be running. 

> Note: In that docker file does not involve setting that will automatically provide to be running your postgresql that's why you need to start postgresql image every restart docker.

Install the packages inside `basitsatinalimuyg.csproj` where your clone project folder and start the project.

```sh
cd basitsatinalim
dotnet package restore
dotnet watch
```

   [ASP.NET CORE MVC]: <https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-8.0>
   [Entity Framework]: <https://learn.microsoft.com/en-us/ef/>
   [PostgreSql]: <https://www.postgresql.org/>
   [Bootstrap]: <https://getbootstrap.com/>
   [Alpine.js]: <https://alpinejs.dev>

