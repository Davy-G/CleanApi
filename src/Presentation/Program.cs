using Application.Interfaces;
using Application.Users.Queries;
using infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SamoqalaqoDbContext>(op => op.UseSqlite(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<IappDbContext>(sp => sp.GetRequiredService<SamoqalaqoDbContext>());
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(GetUserById).Assembly));
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();