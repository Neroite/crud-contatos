using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Repositorio;
using Microsoft.EntityFrameworkCore;


// Add services to the container.

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DataBase"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DataBase")),
    builder => builder.MigrationsAssembly("MeuSiteEmMVC")));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
