using Core.JobTracking.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("Mithat");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = "Mithat",
                    Surname = "Şen",
                    UserName = "mithatsen",
                    Email = "mithatsen45@gmail.com"
                };
                await userManager.CreateAsync(user,"1");
                await userManager.AddToRoleAsync(user,"Admin");
            }

        }
    }
}
