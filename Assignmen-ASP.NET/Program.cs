using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Helpers.Repositories;
using Assignmen_ASP.NET.Models.Identity;
using Assignmen_ASP.NET.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();



// Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductSql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySql")));



// Repositories
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductTagRepository>();
builder.Services.AddScoped<ProductCategoryRepository>();
builder.Services.AddScoped<AppUserRepository>();
builder.Services.AddScoped<ContactFormRepository>();


// Services 
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ContactFormService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<CategoryService>();




builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = false;

}).AddEntityFrameworkStores<IdentityContext>()
  .AddRoles<IdentityRole>();







var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
