using AutoMapper;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DTO.DTOs.AppUserDtos;
using Core.JobTracking.Entities.Concrete;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web.Components
{
    public class Wrapper : ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            
           var model = _mapper.Map<AppUserListDto>(user);

            var notificationCount =_notificationService.GetNotRead(user.Id).Count;
            ViewBag.notificationCount = notificationCount;

            var roles = _userManager.GetRolesAsync(user).Result;
            if (roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member", model);



        }
    }
}
