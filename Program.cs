using Microsoft.EntityFrameworkCore;
using HouseKitchenManager.Data;

var builder = WebApplication.CreateBuilder(args);

// =======================
// SERVICES (BEFORE Build)
// =======================

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddSession();

var app = builder.Build();

// =======================
// MIDDLEWARE (AFTER Build)
// =======================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// =======================
// 🔴 REQUIRED FOR RAILWAY
// =======================

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();
