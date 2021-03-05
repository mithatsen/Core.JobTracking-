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


            //Buralarý dikkatli þekilde doldurmak lazým,kurumsal mimari açýsýndan önemli

            services.AddContainerWithDependencies(); //alttaki 11 satýr

            //services.AddScoped<IWorkingService, WorkManager>(); //dependency injection için gerekli
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

            //Yukarýsý dikkat
            services.AddCustomIdentity();  //alttaki 20 sýra

            //services.AddDbContext<JobTrackingContext>(); // katmanlý mimariye devam

            //services.AddIdentity<AppUser, AppRole>(opt =>
            //{
            //    opt.Password.RequireDigit = false;
            //    opt.Password.RequireLowercase = false;
            //    opt.Password.RequiredLength = 1;
            //    opt.Password.RequireUppercase = false;
            //    opt.Password.RequireNonAlphanumeric = false;

            //}).AddEntityFrameworkStores<JobTrackingContext>();

            ////bitti yukarýdaki 8 satýr önemli.

            //services.ConfigureApplicationCookie(opt =>   //kayýt iþlemi için önemli
            //{
            //    opt.Cookie.Name = "JobTracking";
            //    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;//BAÞKA WEB SAYFALARINA PAYLAÞMASIN
            //    opt.Cookie.HttpOnly = true; //ilgili kullanýcý document.cookie yazarak ulaþamasýn
            //    opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            //    opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; //ÝSTEK NEYSE ONA GÖRE DAVRAN
            //    opt.LoginPath = "/Home/Index";

            //});
            services.AddDistributedMemoryCache();
            services.AddSession(); //session için

            services.AddAutoMapper(typeof(Startup));

            services.AddCustomValidator(); //salttaki 8 satýr

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
            //IdentityInitilazier clasýmýzý bu alanda çalýþtýrýcaz o yüzden yukarýya parametre olarak apuser ve approle ekleyelim
            app.UseSession();


            IdentityInitializer.SeedData(userManager, roleManager).Wait(); // .wait kullanmak önemli çünkü configure async deðil
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
