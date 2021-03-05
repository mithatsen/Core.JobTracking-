using AutoMapper;
using Core.JobTracking.Business.Interfaces;
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

namespace Core.Usb.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class WorkController : BaseIdentityController
    {
        private readonly IWorkingService _workingService;

        private readonly IMapper _mapper;
        public WorkController(IWorkingService workingService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _workingService = workingService;
           
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int activePage = 1)
        {
            var user = await ActiveUser();
            int totalPages;

            var works = _mapper.Map<List<WorkListWithAllTableDto>>(_workingService.GetFinishedWorksWithAllTable(out totalPages, user.Id, activePage));


            ViewBag.totalPages = totalPages;
            ViewBag.activePage = activePage;


            return View(works);
        }
    }
}
