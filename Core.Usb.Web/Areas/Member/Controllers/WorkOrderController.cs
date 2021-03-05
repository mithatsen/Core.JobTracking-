using AutoMapper;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DTO.DTOs.WorkDtos;
using Core.JobTracking.DTO.DTOs.ReportDtos;
using Core.JobTracking.Entities.Concrete;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Usb.Web.BaseControllers;
using Core.Usb.Web.StringInfo;

namespace Core.Usb.Web.Areas.Member.Controllers
{

    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class WorkOrderController : BaseIdentityController
    {
        private readonly IWorkingService _workingService;
        private readonly IReportService _reportService;
        
        private readonly INotificationService _notificationManager;
        private readonly IMapper _mapper;
        public WorkOrderController(IWorkingService workingService, UserManager<AppUser> userManager, IReportService reportService, INotificationService notificationManager, IMapper mapper):base(userManager)
        {
            _workingService = workingService;
           
            _reportService = reportService;
            _notificationManager = notificationManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(_mapper.Map<List<WorkListWithAllTableDto>>(_workingService.GetWorksWithAllTable(p => p.AppUserId == user.Id && !p.Status)));
        }
        public IActionResult CreateReport(int id)
        {
            var work = _workingService.GetWithPriorityId(id);
            ReportAddDto model = new ReportAddDto();
            model.WorkId = id;
            model.Work = work;
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> CreateReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report
                {
                    WorkId = model.WorkId,
                    Name = model.Name,
                    Detail = model.Detail
                });


                // alt taraf bildirim gönderir 

                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                var user = await ActiveUser();

                foreach (var admin in adminUserList)
                {
                    _notificationManager.Save(new Notification
                    {
                        Explanation = $"{user.Name} {user.Surname} yeni bir rapor oluşturdu",
                        AppUserId = admin.Id
                    });
                }

                // üst taraf bildirim gönderir



                return RedirectToAction("Index");
            }
            return View(model);

        }
        public IActionResult UpdateReport(int id)
        {
            return View(_mapper.Map<ReportUpdateDto>(_reportService.GetWithWorkId(id)));

        }
        [HttpPost]
        public async Task<IActionResult> UpdateReport(ReportUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var report = _reportService.GetWithWorkId(model.Id);

                report.Name = model.Name;
                report.Detail = model.Detail;

                _reportService.Update(report);
                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                var user = await ActiveUser();

                foreach (var admin in adminUserList)
                {
                    _notificationManager.Save(new Notification
                    {
                        Explanation = $"{user.Name} {user.Surname} yazmış olduğu raporda değişiklik yaptı",
                        AppUserId = admin.Id
                    });
                }

                return RedirectToAction("Index");
            }
            return View(model);

        }
        public async Task<IActionResult> FinishWork(int id)
        {
            var work = _workingService.GetWithId(id);
            work.Status = true;
            _workingService.Update(work);
            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
            var user = await ActiveUser();

            foreach (var admin in adminUserList)
            {
                _notificationManager.Save(new Notification
                {
                    Explanation = $"{user.Name} {user.Surname} üzerine tanımlı olan görevi tamamladı",
                    AppUserId = admin.Id
                });
            }

            return Json(null);

        }
    }


}