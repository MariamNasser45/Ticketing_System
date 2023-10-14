using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ticketing_System.Data;
using Ticketing_System.Interfaces;
using Ticketing_System.Interfaces.Implemintation;

namespace Ticketing_System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
          
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();



            builder.Services.AddRazorPages();

            builder.Services.AddScoped<ITicket, TicketIMP>();
            builder.Services.AddScoped<ICategory, CategoryImp>();
            builder.Services.AddScoped<IStatus, StatusImp>();
            builder.Services.AddScoped<ISeverity, SeverityImp>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseMigrationsEndPoint();
                app.UseExceptionHandler("/Home/Error");

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope=app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string ReporterEmail = "Reporter@gmail.com";
                string ManagerEmail = "Manager@gmail.com";
                string TechnicianEmail = "Technician@gmail.com";
                string Allpassword = "Mariam@123M";

                if (await userManager.FindByEmailAsync(ReporterEmail) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = "Reporter";
                    user.Email = ReporterEmail;
                    user.EmailConfirmed = true;

                    await userManager.CreateAsync(user, Allpassword);
                    await userManager.AddToRoleAsync(user, "Reporter");
                }

                if (await userManager.FindByEmailAsync(ManagerEmail)==null )
                {
                    var user = new IdentityUser();
                    user.UserName = "Manager";
                    user.Email = ManagerEmail;
                    user.EmailConfirmed = true;

                    await userManager.CreateAsync(user, Allpassword);
                    await userManager.AddToRoleAsync(user, "Manager");
                }

                if (await userManager.FindByEmailAsync(TechnicianEmail) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = "Technician";
                    user.Email = TechnicianEmail;
                    user.EmailConfirmed = true;

                    await userManager.CreateAsync(user, Allpassword);
                    await userManager.AddToRoleAsync(user, "Technician");
                }

            }

            app.Run();
        }
    }
}