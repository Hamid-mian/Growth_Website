using Growth_Website.Models.Interface;
using Growth_Website.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<depLogin, LoginRepository>();
builder.Services.AddSingleton<depSignup, SignupRepository>();
builder.Services.AddSingleton<depProduct, ProductRepository>();
builder.Services.AddSingleton<depCart, CartRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(o=>o.IdleTimeout=TimeSpan.FromMinutes(10));
builder.Services.AddAutoMapper(typeof(Program));
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=StudentLogin}/{id?}");

app.Run();
