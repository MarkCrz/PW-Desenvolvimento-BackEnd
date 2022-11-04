using Microsoft.EntityFrameworkCore;
using WebComerce.Data;
using WebComerce.Repositorios;
using WebComerce.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContextPool<UserDBContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IProdutosRepositorio, ProdutosRepositorio>();
builder.Services.AddScoped<IUserRepositorio, UserRepositorio>();
builder.Services.AddScoped<IProdutoEscolhidoRepositorio, ProdutoEscolhidoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();