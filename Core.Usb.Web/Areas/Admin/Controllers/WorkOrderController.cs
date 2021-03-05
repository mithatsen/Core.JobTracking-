using AutoMapper;

using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DTO.DTOs.AppUserDtos;
using Core.JobTracking.DTO.DTOs.ReportDtos;
using Core.JobTracking.DTO.DTOs.WorkDtos;
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
    [Authorize(Roles = RoleInfo.Admin)]
    public class WorkOrderController : BaseIdentityController
    {
        private readonly IUserService _userService;
        private readonly IWorkingService _workService;

        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public WorkOrderController(IUserService userService, IWorkingService workService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper):base(userManager)
        {
            _userService = userService;
            _workService = workService;
            
            _fileService = fileService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //List<Work> works = _workService.GetWorksWithAllTable();

            //List<WorkListWithAllTableViewModel> models = new List<WorkListWithAllTableViewModel>();
            //foreach (var item in works)
            //{
            //    WorkListWithAllTableViewModel model = new WorkListWithAllTableViewModel();
            //    model.Id = item.Id;
            //    model.Name = item.Name;
            //    model.Priority = item.Priority;
            //    model.Explanation = item.Explanation;
            //    model.Reports = item.Reports;
            //    model.CreationDate = item.CreationDate;
            //    model.AppUser = item.AppUser;
            //    models.Add(model);
            //}
            return View(_mapper.Map<List<WorkListWithAllTableDto>>(_workService.GetWorksWithAllTable()));

        }

        public IActionResult AssignPersonel(int id, string s, int limit = 3, int page = 1)
        {
            int totalPages;
            
            var users= _mapper.Map<List<AppUserListDto>>(_userService.GetNotAdmin(out totalPages, s, limit, page)); 

           
            ViewBag.ActivePage = page;
            ViewBag.Staffs = users;
            ViewBag.totalPages = totalPages;
            ViewBag.Searched = s;
                      
            return View(_mapper.Map<WorkListDto>(_workService.GetWithPriorityId(id)));
        }
        [HttpPost]
        public IActionResult AssignPersonel(PersonelAssignDto model)
        {
            var work = _workService.GetWithId(model.WorkId);
            work.AppUserId = model.PersonelId;
            _workService.Update(work);

            return RedirectToAction("Index");

        }
        public IActionResult ShowDetail(int id)
        {
            //var work = _workService.GetWithReportId(id);
            //WorkListWithAllTableViewModel model = new WorkListWithAllTableViewModel();
            //model.Id = work.Id;
            //model.Name = work.Name;
            //model.Reports = work.Reports;
            //model.Explanation = work.Explanation;
            //model.AppUser = work.AppUser;

           
            return View(_mapper.Map<WorkListWithAllTableDto>(_workService.GetWithReportId(id)));

        }
        public IActionResult getExcel(int id)
        {
            var path = _fileService.TransferExcel(_mapper.Map<List<ReportFileDto>>(_workService.GetWithReportId(id).Reports));
            
            return File(path, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid()+ ".xlsx");

        }
        public IActionResult getPdf(int id)
        {


            var path = _fileService.TransferPdf(_mapper.Map<List<ReportFileDto>>(_workService.GetWithReportId(id).Reports));
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");

        }

        public async Task<IActionResult> AssignPersonelConfirmation(PersonelAssignDto model)
        {
           
            
            PersonelAssignListDto model2 = new PersonelAssignListDto();

            model2.User = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(p => p.Id == model.PersonelId));

            model2.Work = _mapper.Map<WorkListDto>(_workService.GetWithPriorityId(model.WorkId));

            var admin = await ActiveUser();

            _notificationService.Save(new Notification
            {
                Explanation = $"Yönetici {admin.Name} {admin.Surname} sizi yeni bir iş için görevlendirdi",
                AppUserId = model.PersonelId
            }); ;
            


            return View(model2);

        }
    }
}

