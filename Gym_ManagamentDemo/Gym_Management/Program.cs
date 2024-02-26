using Gym_Management.Data;
using Gym_Management.Repositories.Customer;
using Gym_Management.Repositories.Employee;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<SqlDataAccess>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
