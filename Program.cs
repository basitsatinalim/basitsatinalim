using basitsatinalimuyg.Context;
using basitsatinalimuyg.Config;
using basitsatinalimuyg.Middlewares;
using basitsatinalimuyg.Repositories;
using basitsatinalimuyg.Repositories.Abstraction;
using basitsatinalimuyg.Services;
using basitsatinalimuyg.Services.Abstraction;
using basitsatinalimuyg.Utils;
using basitsatinalimuyg.Utils.Abstraction;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<RazorViewEngineOptions>(options =>
	 {
		 options.ViewLocationExpanders.Add(new CustomViewLocationExpander());
	 });


builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("basicecomm")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.Cookie.Name = "user_auth";
		options.ExpireTimeSpan = TimeSpan.FromDays(1);
		options.SlidingExpiration = true;
		options.AccessDeniedPath = "/Home/Error";
		options.LoginPath = "/Auth/Login";
		options.LogoutPath = "/Auth/Logout";
	});

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<ExceptionMiddleware>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IHasher, SHA256Hasher>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdressRepository, AdressRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderLineRepository, OrderLineRepository>();



var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "notfound",
	pattern: "{*url}",
	defaults: new { controller = "Home", action = "Error" }
);

app.Run();
