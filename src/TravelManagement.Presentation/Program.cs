using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TravelManagement.Application.Interfaces.Repositories;
using TravelManagement.Persistence.Contexts;
using TravelManagement.Persistence.Repositories;

namespace TravelManagement.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add Services to the Container.
        builder.Services.AddControllersWithViews();

        // Register DbContext with SQLite
        builder.Services.AddDbContext<TravelDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // Register the generic repository for dependency injection
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Add MediatR, other services, etc.
        builder.Services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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
    }
}
