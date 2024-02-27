using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Helper;
using MeuSiteEmMVC.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


// Add services to the container.

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DataBase"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DataBase")),
    builder => builder.MigrationsAssembly("MeuSiteEmMVC")));

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor,  HttpContextAccessor>();

builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
