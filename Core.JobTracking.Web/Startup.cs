using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.JobTracking.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting(); //ysk.com.tr/index.aspl   use routing olmazsa bu url nin hiçbir anlamý yok 
            app.UseStaticFiles();
            app.UseStatusCodePages();//hata sayfaný oluþturmak için gerekli
            app.UseEndpoints(endpoints =>      
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=User}/{controller=Home}/{action=Index}"// urlde neyin ne olduðunu  ayarlar
                    );
            });
        }
    }
}
