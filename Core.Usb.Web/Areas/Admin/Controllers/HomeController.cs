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

namespace Core.Usb.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles= RoleInfo.Admin)]
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
            ViewBag.totalNotAssignedWorkNumber = _workService.GetNotAssignedWorkNumber();
            ViewBag.totalFinishedWorkNumber = _workService.GetFinishedWorkNumber();
            ViewBag.totalNotificationNumber = _notificationService.GetNotReadNumber(user.Id);
            ViewBag.totalReportNumber = _reportService.GetTotalReportNumber();

            return View();
        }
    }
}
