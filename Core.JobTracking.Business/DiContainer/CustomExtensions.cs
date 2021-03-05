using Core.JobTracking.Business.Concrete;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Core.JobTracking.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies( this IServiceCollection services)
        {
            //Buraları dikkatli şekilde doldurmak lazım,kurumsal mimari açısından önemli
            services.AddScoped<IWorkingService, WorkManager>(); //dependency injection için gerekli
            services.AddScoped<IPriorityService, PriorityManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IWorkingDal, EfWorkRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<IPriorityDal, EfPriorityRepository>();
            services.AddScoped<IUserDal, EfUserRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();

            //Yukarısı dikkat
        }
    }

}
