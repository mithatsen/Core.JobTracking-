using AutoMapper;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DTO.DTOs.NotificationDtos;
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
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
       
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
           
            _notificationService = notificationService;
            
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            var user = await ActiveUser();           
            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetNotRead(user.Id)));
        }
       
        public IActionResult ReadNotification(int id)
        {
            var temp = _notificationService.GetWithId(id);
            temp.Status = true;
            _notificationService.Update(temp);

            return RedirectToAction("Index");
        }
    }
}
