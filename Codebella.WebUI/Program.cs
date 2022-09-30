using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Codebella.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCodebellaInfraStructure(builder.Configuration.GetConnectionString("DefaultConnection"));

        builder.Services.AddControllersWithViews();

        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "categoryArticle",
            pattern: "{controller=Category}/{categorySlug}/{articleSlug?}",
            defaults: new { controller = "Category", action = "CategoryArticle" }
            );

        app.MapControllerRoute(
            name: "category",
            pattern: "{controller=Category}/{slug}",
            defaults: new { controller = "Category", action = "Category" }
            );

        app.MapControllerRoute(
            name: "tag",
            pattern: "{controller=Tag}/{slug}",
            defaults: new { controller = "Tag", action = "Tag" }
            );

        app.MapControllerRoute(
            name: "author",
            pattern: "{controller=Author}/{nickname}",
            defaults: new { controller = "Author", action = "Index" }
            );

        app.MapRazorPages();

        app.Run();
    }
}