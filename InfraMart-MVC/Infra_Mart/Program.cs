using Infra_Mart.Models;
using Infra_Mart.SAL;
using Infra_Mart.DAL;
using Infra_Mart.DAL.Interfaces;
using Infra_Mart.DAL.Repository;
using Infra_Mart.SAL.Interfaces;
using Infra_Mart.SAL.Services;
using Infra_Mart.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration=provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<CollectionContex>(item => item.UseMySQL(configuration.GetConnectionString("myconn")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUserIointerface, UserIoManager>();
builder.Services.AddTransient<IUserInterface, UserImpl>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductServiceImpl>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryServiceImpl>();
builder.Services.AddDbContext<CollectionContex>();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
