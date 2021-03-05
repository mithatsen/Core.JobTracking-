using AutoMapper;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DTO.DTOs.AppUserDtos;
using Core.JobTracking.Entities.Concrete;
using Core.Usb.Web.BaseControllers;
using Core.Usb.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class ProfileController : BaseIdentityController
    {
        
        private readonly IMapper _mapper;
        public ProfileController(UserManager<AppUser> userManager,IMapper mapper):base(userManager)
        {
          
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var user = await ActiveUser();
            
            return View(_mapper.Map<AppUserUpdateDto>(user));
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserUpdateDto model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekKullanici = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + resimAd);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    }

                    guncellenecekKullanici.Picture = resimAd;
                }

                guncellenecekKullanici.Name = model.Name;
                guncellenecekKullanici.Surname = model.SurName;
                guncellenecekKullanici.Email = model.Email;

                var result = await _userManager.UpdateAsync(guncellenecekKullanici);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işlemi başarıyla gerçekleşti";
                    return RedirectToAction("Index");
                }

                

            }
            return View(model);
        }

    }
}
