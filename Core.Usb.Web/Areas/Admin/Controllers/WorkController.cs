using AutoMapper;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DTO.DTOs.WorkDtos;
using Core.JobTracking.Entities.Concrete;
using Core.Usb.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class WorkController : Controller
    {
        private readonly IPriorityService _priorityService;
        private readonly IWorkingService _workingService;
        private readonly IMapper _mapper;
        public WorkController(IWorkingService workingService, IPriorityService priorityService, IMapper mapper)
        {
            _workingService = workingService;
            _priorityService = priorityService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {           
            return View(_mapper.Map<List<WorkListDto>>(_workingService.GetNotCompletedWorkWithAscDate()));
        }
        public IActionResult CreateWork()
        {
            HttpContext.Session.SetString("userOrAdmin", "Admin");
            List<SelectListItem> value1 = (from i in _priorityService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.Priorities = value1;
            return View(new WorkAddDto());
        }
        [HttpPost]
        public IActionResult CreateWork(WorkAddDto model)
        {
            if (ModelState.IsValid)
            {
                _workingService.Save(new Work
                {
                    Explanation=model.Explanation,
                    Name = model.Name,
                    PriorityId=model.PriorityId
                });
                return RedirectToAction("Index");
            }
            List<SelectListItem> value1 = (from i in _priorityService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.Priorities = value1;
            return View(model);
        }
        public IActionResult UpdateWork(int id)
        {
            
            List<SelectListItem> value1 = (from i in _priorityService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.Priorities = value1;
            

            return View(_mapper.Map<WorkUpdateDto>(_workingService.GetWithAppUserId(id)));
        }
        [HttpPost]
        public IActionResult UpdateWork(WorkUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _workingService.Update(new Work
                {
                    Id=model.Id,
                    Explanation = model.Explanation,
                    Name = model.Name,
                    PriorityId = model.PriorityId,
                    AppUserId=model.AppUserId
                });
                return RedirectToAction("Index");
            }
            List<SelectListItem> value1 = (from i in _priorityService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.Priorities = value1;
            return View(model);
        }
        public IActionResult DeleteWork(int id)
        {
            _workingService.Delete(id);

            return Json(null);
        }

    }
}
