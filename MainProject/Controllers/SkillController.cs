using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainProject.Core;
using MainProject.Data;
using MainProject.BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;

namespace MainProject.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly IUserService _userService;
        public SkillController(ISkillService skillService, IUserService userService)
        {
            _skillService = skillService;
            _userService = userService;
        }

       
        public async Task<IActionResult> Index()
        {
            var skillList = await _skillService.GetSkills(x => true,x=>x.Courses,x=>x.CreatedByUser);

            if (skillList==null)
            {
                  return View("У вас нет полученных способностей на данном сайте");
            }
            else return View(skillList.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {          
            return View();
        }
    
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] SkillEntity skillEntity)
        {
            if (ModelState.IsValid)
            {
                var userId = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name)).FirstOrDefault();
                skillEntity.CreatedUserId = userId.Id;
                var check = (await _skillService.GetSkills(x => x.Name == skillEntity.Name)).FirstOrDefault();
                if (check == null)
                {
                    await _skillService.AddSkillAsync(skillEntity);
                }
                else ModelState.AddModelError("", "Материал с таким именем уже существует");

                return RedirectToAction(nameof(Index));
            }
           
            return View(skillEntity);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            ViewBag.id = int.Parse(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            return  View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name")] SkillEntity skillEntity)
        {
            var userId = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name)).FirstOrDefault();
            skillEntity.CreatedUserId = userId.Id;
            skillEntity.Id = id;
            var check = (await _skillService.GetSkills(x => x.Name == skillEntity.Name)).FirstOrDefault();

            if (id != skillEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid& check == null)
            {
                try
                {
                    await _skillService.UpdateAsync(skillEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( !await SkillEntityExists(skillEntity.Id))
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
            else
                ModelState.AddModelError("", "Материал с таким именем уже существует");
            return View(skillEntity);
        }


        private async Task<bool> SkillEntityExists(int id)
        {
            return (await _skillService.GetSkills(x=>x.Id==id)).Any();
        }
    }
}
