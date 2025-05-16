using Bookstore.Data;
using Bookstore.Mapper;
using Bookstore.Models;
using Bookstore.Repositories;
using Bookstore.Services.AuthorService;
using Bookstore.Services.BookService;
using Bookstore.Services.CategoryService;
using Bookstore.Services.LoginService;
using Bookstore.Services.PublisherService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;
using Bookstore.Services.RegisterService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<BookstoreDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString
("DefaultConnection")));


builder.Services.AddIdentity<AppUser,AppRole>(options =>
options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<AppRole>()
    .AddEntityFrameworkStores<BookstoreDbContext>();

// Automapper configuration
builder.Services.AddAutoMapper(typeof(BookstoreMapper));

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();





// Dependency Injection Configuration

//BookService ve BookRepository
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookService, BookService>();

//AuthorService ve AuthorRepo
builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IAuthorService, AuthorService>();

//CategoryService ve CategoryRepo
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

//PublisherService ve PublisherRepo
builder.Services.AddTransient<IPublisherRepository, PublisherRepository>();
builder.Services.AddTransient<IPublisherService, PublisherService >();

//LoginService
builder.Services.AddTransient<ILoginService, LoginService>();

//RegisterService
builder.Services.AddTransient<IRegisterService, RegisterService>();


//BookAuthorService ve BookAuthorRepo
builder.Services.AddTransient<IBookAuthorRepository, BookAuthorRepository>();




// Swagger servislerini ekle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Geliþtirme ortamýnda Swagger'ý aç
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
