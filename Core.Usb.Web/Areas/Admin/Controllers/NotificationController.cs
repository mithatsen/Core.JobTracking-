using AutoMapper;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DTO.DTOs.NotificationDtos;
using Core.JobTracking.Entities.Concrete;
using Core.Usb.Web.BaseControllers;
using Core.Usb.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using System.Threading.Tasks;

namespace Core.Usb.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;            
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var user = await ActiveUser();

            //List<NotificationListViewModel> models = new List<NotificationListViewModel>();
            //foreach (var item in notifications){
            //    NotificationListViewModel model = new NotificationListViewModel(){
            //        Id = item.Id,
            //        Explanation=item.Explanation
            //    };
            //    models.Add(model);
            //}
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
