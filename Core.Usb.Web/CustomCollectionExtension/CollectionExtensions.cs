using Core.JobTracking.Business.Concrete;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.Business.ValidationRules.FludentValidation;
using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.DTO.DTOs.AppUserDtos;
using Core.JobTracking.DTO.DTOs.PriorityDtos;
using Core.JobTracking.DTO.DTOs.ReportDtos;
using Core.JobTracking.DTO.DTOs.WorkDtos;
using Core.JobTracking.Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web.CustomCollectionExtension
{
    public static class CollectionExtensions
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddDbContext<JobTrackingContext>(); // katmanlı mimariye devam

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<JobTrackingContext>();

            //bitti yukarıdaki 8 satır önemli.

            services.ConfigureApplicationCookie(opt =>   //kayıt işlemi için önemli
            {
                opt.Cookie.Name = "JobTracking";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;//BAŞKA WEB SAYFALARINA PAYLAŞMASIN
                opt.Cookie.HttpOnly = true; //ilgili kullanıcı document.cookie yazarak ulaşamasın
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; //İSTEK NEYSE ONA GÖRE DAVRAN
                opt.LoginPath = "/Home/Index";

            });

        }
        public static void AddCustomValidator( this IServiceCollection services)
        {
            services.AddTransient<IValidator<PriorityAddDto>, PriorityAddValidator>();
            services.AddTransient<IValidator<PriorityUpdateDto>, PriorityUpdateValidator>();

            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserSignInValidator>();

            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportUpdateDto>, ReportUpdateValidator>();

            services.AddTransient<IValidator<WorkAddDto>, WorkAddValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateValidator>();
        }
       
    }
}
