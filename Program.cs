using Microsoft.EntityFrameworkCore;
using HouseKitchenManager.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ ADD ALL SERVICES HERE (BEFORE Build)
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSession();

var app = builder.Build();

// ✅ MIDDLEWARE (AFTER Build)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // ✅ must be AFTER UseRouting

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
