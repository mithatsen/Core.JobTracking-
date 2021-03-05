using Core.JobTracking.Business.Concrete;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.Business.ValidationRules.FludentValidation;
using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.DTO.DTOs.AppUserDtos;
using Core.JobTracking.DTO.DTOs.PriorityDtos;
using Core.JobTracking.DTO.DTOs.WorkDtos;
using Core.JobTracking.DTO.DTOs.ReportDtos;
using Core.JobTracking.Entities.Concrete;

using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Core.JobTracking.Business.DiContainer;
using Core.Usb.Web.CustomCollectionExtension;

namespace Core.Usb.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            //Buralar� dikkatli �ekilde doldurmak laz�m,kurumsal mimari a��s�ndan �nemli

            services.AddContainerWithDependencies(); //alttaki 11 sat�r

            //services.AddScoped<IWorkingService, WorkManager>(); //dependency injection i�in gerekli
            //services.AddScoped<IPriorityService, PriorityManager>();
            //services.AddScoped<IReportService, ReportManager>();
            //services.AddScoped<IUserService, UserManager>();
            //services.AddScoped<IFileService, FileManager>();
            //services.AddScoped<INotificationService, NotificationManager>();

            //services.AddScoped<IWorkingDal, EfWorkRepository>();
            //services.AddScoped<IReportDal, EfReportRepository>();
            //services.AddScoped<IPriorityDal, EfPriorityRepository>();
            //services.AddScoped<IUserDal, EfUserRepository>();
            //services.AddScoped<INotificationDal, EfNotificationRepository>();

            //Yukar�s� dikkat
            services.AddCustomIdentity();  //alttaki 20 s�ra

            //services.AddDbContext<JobTrackingContext>(); // katmanl� mimariye devam

            //services.AddIdentity<AppUser, AppRole>(opt =>
            //{
            //    opt.Password.RequireDigit = false;
            //    opt.Password.RequireLowercase = false;
            //    opt.Password.RequiredLength = 1;
            //    opt.Password.RequireUppercase = false;
            //    opt.Password.RequireNonAlphanumeric = false;

            //}).AddEntityFrameworkStores<JobTrackingContext>();

            ////bitti yukar�daki 8 sat�r �nemli.

            //services.ConfigureApplicationCookie(opt =>   //kay�t i�lemi i�in �nemli
            //{
            //    opt.Cookie.Name = "JobTracking";
            //    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;//BA�KA WEB SAYFALARINA PAYLA�MASIN
            //    opt.Cookie.HttpOnly = true; //ilgili kullan�c� document.cookie yazarak ula�amas�n
            //    opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            //    opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; //�STEK NEYSE ONA G�RE DAVRAN
            //    opt.LoginPath = "/Home/Index";

            //});
            services.AddDistributedMemoryCache();
            services.AddSession(); //session i�in

            services.AddAutoMapper(typeof(Startup));

            services.AddCustomValidator(); //salttaki 8 sat�r

            //services.AddTransient<IValidator<PriorityAddDto>,PriorityAddValidator>();
            //services.AddTransient<IValidator<PriorityUpdateDto>,PriorityUpdateValidator>();
            
            //services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            //services.AddTransient<IValidator<AppUserLoginDto>, AppUserSignInValidator>();

            //services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            //services.AddTransient<IValidator<ReportUpdateDto>, ReportUpdateValidator>();

            //services.AddTransient<IValidator<WorkAddDto>, WorkAddValidator>();
            //services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateValidator>();
            

            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

            

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //IdentityInitilazier clas�m�z� bu alanda �al��t�r�caz o y�zden yukar�ya parametre olarak apuser ve approle ekleyelim
            app.UseSession();


            IdentityInitializer.SeedData(userManager, roleManager).Wait(); // .wait kullanmak �nemli ��nk� configure async de�il
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=SignIn}/{id?}"
                    ); //area ekleyince gerekli

                endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=SignIn}/{id?}"

            );
            });
        }
    }
}
