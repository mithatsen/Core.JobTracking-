using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.Entities.Concrete;
using Core.Usb.Web.BaseControllers;
using Core.Usb.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IReportService _reportService;
        private readonly IWorkingService _workService;
        private readonly INotificationService _notificationService;
        
        public HomeController(IReportService reportService, UserManager<AppUser> userManager, IWorkingService workService, INotificationService notificationService):base(userManager)
        {
            _reportService = reportService;
           
            _workService = workService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
           
            
            var user = await ActiveUser();
            
            ViewBag.totalReportNumber =_reportService.GetTotalReportNumberWithAppUserId(user.Id);
            ViewBag.totalWorkNumber = _workService.GetFinisheWorkNumberWithAppUserId(user.Id);
            ViewBag.totalNotificationNumber = _notificationService.GetNotReadNumber(user.Id);
            ViewBag.totalNotFinishedWorkNumber = _workService.GetNotFinishedWorkNumberWithAppUserId(user.Id);
            return View();
        }
    }
}


//sende uzak ol diyar pala