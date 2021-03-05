using AutoMapper;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DTO.DTOs.PriorityDtos;
using Core.JobTracking.Entities.Concrete;
using Core.Usb.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class PriorityController : Controller
    {
        private readonly IPriorityService _priorityService;
        private readonly IMapper _mapper;
        public PriorityController(IPriorityService priorityService, IMapper mapper)
        {
            _priorityService = priorityService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //List<Priority> priorities=_priorityService.GetAll();
            //List<PriorityListViewModel> model = new List<PriorityListViewModel>();
            //foreach(var item in priorities)
            //{
            //    PriorityListViewModel priorityModel = new PriorityListViewModel();
            //    priorityModel.Id = item.Id;
            //    priorityModel.Name = item.Name;
            //    model.Add(priorityModel);
            //}


            return View(_mapper.Map<List<PriorityListDto>>(_priorityService.GetAll()));
        }
        public IActionResult CreatePriority()
        {        
            return View(new PriorityAddDto());
        }
        [HttpPost]
        public IActionResult CreatePriority(PriorityAddDto model)
        {
            if (ModelState.IsValid)
            {
                _priorityService.Save(new Priority
                {
                    Name = model.Name
                }) ;
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdatePriority(int id)
        {                            
            return View(_mapper.Map<PriorityUpdateDto>(_priorityService.GetWithId(id)));
        }
        [HttpPost]
        public IActionResult UpdatePriority(PriorityUpdateDto param)
        {
            if (ModelState.IsValid)
            {
                _priorityService.Update(new Priority
                {
                    Id=param.Id,
                    Name = param.Name
                });
                return RedirectToAction("Index");
            }
            return View(param);                              
        }
    }
}
