using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainProject.Core;
using MainProject.Data;
using Microsoft.AspNetCore.Authorization;
using BL;
using MainProject.BLL.Services;
using Domain.Entity;
using MainProject.BLL.Interfaces.IServices;
using System.Threading;

namespace MainProject.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly IMaterialService _materialService;
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;
        private readonly IPassingCourseService _passingCourseService;

        public CourseController(ICourseService courseService, IUserService userService, IMaterialService materialService, ISkillService skillService, IPassingCourseService passsingCourseService)
        {
            _skillService = skillService;
            _materialService = materialService;
            _courseService = courseService;
            _userService = userService;
            _passingCourseService = passsingCourseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courseList = await _courseService.GetCoursesAsync(c => true, c => c.CreatedByUser);

            if (courseList == null)
            {
                return View("У вас нет полученных способностей на данном сайте");
            }
            else return View(courseList.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Materials = await _materialService.GetMaterialAsync(x => true);
            ViewBag.Skills = await _skillService.GetSkills(x => true);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseEntity courseEntity, string[] materials, string[] skills, string level)
        {
            if (ModelState.IsValid)
            {
                string[] RequirmentLevel = level.Split(",");
                if (materials.Count() == RequirmentLevel.Count())
                {
                    var userId = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name)).FirstOrDefault().Id;
                    var course = courseEntity;
                    course.CreatedByUserId = userId;

                    var check = (await _courseService.GetCoursesAsync(x => x.Name == course.Name)).FirstOrDefault();
                    if (check == null)
                    {
                        await _courseService.AddCourseAsync(course);

                        var getCourse = (await _courseService.GetCoursesAsync(x => x.Name == course.Name, x => x.CourseMaterialEnrollments, x => x.CourseSkillEnrollments)).FirstOrDefault();
                        course.Id = getCourse.Id;
                        if (course.CourseMaterialEnrollments == null)
                        {
                            course.CourseMaterialEnrollments = new List<CourseMaterialEnrollment>();
                        }
                        foreach (var i in materials)
                        {
                            course.CourseMaterialEnrollments.Add(new CourseMaterialEnrollment { CourseId = course.Id, MaterialId = int.Parse(i) });
                        }
                        if (course.CourseSkillEnrollments == null)
                        {
                            course.CourseSkillEnrollments = new List<CourseSkillEnrollment>();
                        }
                        foreach (var i in skills)
                        {
                            foreach (var j in RequirmentLevel)
                            {

                                courseEntity.CourseSkillEnrollments.Add(new CourseSkillEnrollment { SkillId = int.Parse(i), CourseId = course.Id, RequirementLevel = int.Parse(j) });
                            }
                        }

                        await _courseService.UpdateAsync(course);
                    }
                }
                ModelState.AddModelError("", "Неправильное соотношение материалов и допустимого уровня");
            }
            else
                ModelState.AddModelError("", "Курс с таким именем уже существует");

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            ViewBag.Materials = await _materialService.GetMaterialAsync(x => true);
            ViewBag.Skills = await _skillService.GetSkills(x => true);
            ViewBag.id = int.Parse(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseEntity courseEntity, string[] materials, string[] skills, string[] level)
        {

            if (id != courseEntity.Id)
            {
                return NotFound();
            }

            var userId = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name)).FirstOrDefault();
            var course = courseEntity;
            courseEntity.CreatedByUserId = userId.Id;
            courseEntity.Id = id;
            var check = (await _materialService.GetMaterialAsync(x => x.Name == course.Name)).FirstOrDefault();

            if (ModelState.IsValid & check == null)
            {
                try
                {
                    await _courseService.UpdateAsync(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CourseEntityExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else ModelState.AddModelError("", "Курс с таким именем уже есть");
            return View();
        }

        private async Task<bool> CourseEntityExists(int id)
        {
            return (await _courseService.GetCoursesAsync(e => e.Id == id)).Any();
        }

        [HttpGet]
        public IActionResult PassingCourse()
        {
            ViewBag.id = int.Parse(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PassingCourse(int id)
        {
            var user = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name)).FirstOrDefault();

            var tempCourse = (await _courseService.GetCoursesAsync(x => x.Id == id)).FirstOrDefault();

            var tempPassingCourses = (await _passingCourseService.GetCoursesAsync(x => x.UserId == user.Id));

            var course = tempCourse;
            foreach (var i in tempPassingCourses)
            {
                if (i.CourseId == course.Id && i.UserId == user.Id && ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Вы уже проходите данный курс");
                }
            }

            await _passingCourseService.AddPassingCourse(course, user);



            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> LearningCourse()
        {
            int item = int.Parse(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            var user = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name, u => u.PassingCourses)).FirstOrDefault();
            ViewBag.PassingCourse = (await _courseService.GetCoursesAsync(u => u.Id == item,u=>u.Materials)).FirstOrDefault().Materials;
            ViewBag.id = item;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LearningCourse(int id, string materialId,CancellationToken cancellationToken = default)
        {
            if (materialId != null)
            {
                materialId = "0";
            }
                ViewBag.PassingCourse = (await _courseService.GetCoursesAsync(u => u.Id == id, u => u.Materials)).FirstOrDefault().Materials;
                ViewBag.id = id;
                var user = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name, u => u.FinishedMaterials)).FirstOrDefault();
                var passingCourse = (await _passingCourseService.GetCoursesAsync(x => x.UserId == user.Id && x.CourseId == id, x => x.Course, x => x.Users)).FirstOrDefault();

                if (ModelState.IsValid)
                {
                    await _passingCourseService.PassCourse(passingCourse, user, int.Parse(materialId));

                }
                else ModelState.AddModelError("", "Материал уже пройден");
            
            return RedirectPermanent("/Account/Cabinet");
        }

    }
}
