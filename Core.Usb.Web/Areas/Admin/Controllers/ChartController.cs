using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.Entities.Concrete;
using Core.Usb.Web.BaseControllers;
using Core.Usb.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ChartController : BaseIdentityController
    {
        private readonly IUserService _userService;
       
        public ChartController(IUserService userService, UserManager<AppUser> userManager) :base(userManager)
        {
            _userService = userService;
            
        }
        public IActionResult Index()
        {
            return View();
        }
    
        public async Task<IActionResult> SuccessfulStaffsNow()
        {
            List<DualHelper> list = _userService.GetTop5MostCompletedWorkNowAppUsers();
    
            foreach(var x in list)
            {
                var user = await _userManager.FindByNameAsync(x.Name);
                x.Name = user.Name + " " + user.Surname;
            }
            var jsonString = JsonConvert.SerializeObject(list);
            return Json(jsonString);
        }
        public async Task<IActionResult> SuccessfulStaffsGeneral()
        {
            List<DualHelper> list2 = _userService.GetTop5MostCompletedWorkAppUsers();

            foreach (var x in list2)
            {
                var user2 = await _userManager.FindByNameAsync(x.Name);
                x.Name = user2.Name + " " + user2.Surname;
            }
            var jsonString = JsonConvert.SerializeObject(list2);
            return Json(jsonString);
          
        }

    }
}
