using Domain.Entity;
using MainProject.BLL.Interfaces.IServices;
using MainProject.BLL.Models;
using MainProject.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MainProject.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;
        private readonly IPassingCourseService _passingCourseService;
        public AccountController(IUserService userService, IPassingCourseService passingCourseService, ICourseService courseService)
        {
            _userService = userService;
            _passingCourseService = passingCourseService;
            _courseService = courseService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserEntity user = (await _userService.GetUsersAsync(u => u.Email == model.Email && u.Password == model.Password, x => x.Role)).FirstOrDefault();
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные email и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserEntity user = (await _userService.GetUsersAsync(u => u.Email == model.Email)).FirstOrDefault();
                if (user == null)
                {
                    await _userService.UserRegistration(new UserEntity { Email = model.Email, Password = model.Password, Login = model.Login });

                    user = (await _userService.GetUsersAsync(u => u.Email == model.Email && u.Password == model.Password, x => x.Role)).FirstOrDefault();

                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные email и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(UserEntity user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task<IActionResult> Cabinet()
        {
            UserEntity user = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name, u => u.PassingCourses, u => u.Skills, u => u.FinishedMaterials, u => u.Role,u=>u.SkillUserEnrollments)).FirstOrDefault();
            var passingCourse = (await _passingCourseService.GetCoursesAsync(x => x.UserId == user.Id, x => x.Course, x => x.Users));
            ViewBag.Titles = new List<string> { "Email", "Login", "Role" };
            ViewBag.UserInfo = new List<string> { user.Email, user.Login, user.Role.Name };

            ViewBag.FinishedMaterials = user.FinishedMaterials;

            foreach(var i in user.Skills)
            {
                i.SkillUserEnrollments = user.SkillUserEnrollments;
            }
            ViewBag.Skills = user.Skills;

            return View(passingCourse.ToList());
        }
    }


}
