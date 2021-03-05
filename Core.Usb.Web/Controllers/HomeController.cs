using AutoMapper;
using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DTO.DTOs.AppUserDtos;
using Core.JobTracking.Entities.Concrete;
using Core.Usb.Web.BaseControllers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Core.Usb.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {

        private readonly IWorkingService _workingService;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;


        public HomeController(IMapper mapper, IWorkingService workingService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager)
        {
            _workingService = workingService;

            _signInManager = signInManager;

            _roleManager = roleManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {

                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    Picture = "defaultUser.png"

                };
                var result = await _userManager.CreateAsync(user, model.Password); ////passwordu 2. parametre olarak yolladık.Passwordhash kullanmadık 

                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Member");

                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction("SignIn");
                    }
                    else
                    {
                        foreach (var item in roleResult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                        {
                          
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else if (roles.Contains("Member"))
                        {
                        
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }


                    }
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }

            return View("Index", model);

        }

        public async Task<IActionResult> SignOut()
        {

            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();

            return RedirectToAction("SignIn");

        }


        public async Task<IActionResult> StatusCode()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);



            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                return View("StatusCode", "Admin");
            }
            else 
            {
                return View("StatusCode", "Member");
            }


        }
        public IActionResult Error()
        {
            var exceptionHandler =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.Path = exceptionHandler.Path;
            ViewBag.ErrorMessage = exceptionHandler.Error.Message;
            return View();
        }
        public void Hata()
        {
            throw new Exception("Bu bir hata");
        }
    }
}
