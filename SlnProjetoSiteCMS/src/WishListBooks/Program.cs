using Microsoft.EntityFrameworkCore;
using WishListBooks.Helper;
using WishListBooks.Models;
using WishListBooks.Repository;
using WishListBooks.Service.Implements;
using WishListBooks.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextoDatabase>
    (options => options.UseSqlServer("Server=LAPTOP-EBG33A6E\\SQLEXPRESS;Database=WishListBooks;User Id=sa;Password=gibi2016; TrustServerCertificate=True;"));

//Service
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<ILivrosLidosService, LivrosLidosService>();

//Repository
builder.Services.AddScoped<CategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<UserRepository, UserRepository>();
builder.Services.AddScoped<LivroRepository, LivroRepository>();
builder.Services.AddScoped<LivrosLidosRepository, LivrosLidosRepository>();


//mapeando Sessão
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISessao, Sessao>();
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
