using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Repository;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();



	builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbContext"))); ;
builder.Services.AddTransient<IEmployeeRepo,EmployeeRepo>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
  
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
