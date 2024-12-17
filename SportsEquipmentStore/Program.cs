using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Data;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<SportsEquipmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Identity
Stripe.StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];


builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<StripeService>();


var app = builder.Build();




app.UseStatusCodePagesWithReExecute("/Home/Error404");

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "sports",
    pattern: "Sports/{action=Index}/{sportCategory?}",
    defaults: new { controller = "Sports" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
