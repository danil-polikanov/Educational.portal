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
using Domain.Entity;
using MainProject.BLL.Interfaces.IServices;

namespace MainProject.Controllers
{
    [Authorize]
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;
        private readonly IUserService _userService;
        public MaterialController(IMaterialService materialService, IUserService userService)
        {
            _materialService = materialService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var materialList = await _materialService.GetMaterialAsync(x => true, x => x.Courses, x => x.CreatedByUser);

            if (materialList == null)
            {
                return View("У вас нет полученных способностей на данном сайте");
            }

            else return View(materialList.ToList());

        }
        [HttpGet]
        public IActionResult ElectronicPublication()
        {
            return View();
        }
        [HttpGet]
        public IActionResult InternetArticle()
        {
            return View();
        }
        [HttpGet]
        public IActionResult VideoResource()
        {
             return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialEntity materialEntity)
        {
            if (ModelState.IsValid)
            {
                var userId = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name)).FirstOrDefault();
                var check = (await _materialService.GetMaterialAsync(x => x.Name == materialEntity.Name)).FirstOrDefault();
                if (check == null) {
                    materialEntity.CreatedUserId = userId.Id;
                    await _materialService.AddMaterialAsync(materialEntity); }
                   
                else ModelState.AddModelError("", "Материал с таким именем уже есть");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ElectronicPublicationEdit()
        {
            ViewBag.id = int.Parse(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            return View();
        }
        [HttpGet]
        public IActionResult InternetArticleEdit()
        {
            ViewBag.id = int.Parse(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            return View();
        }
        [HttpGet]
        public IActionResult VideoResourseEdit()
        {
            ViewBag.id = int.Parse(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,MaterialEntity materialEntity)
        {
            var userId = (await _userService.GetUsersAsync(u => u.Email == this.HttpContext.User.Identity.Name)).FirstOrDefault();
            materialEntity.CreatedUserId = userId.Id;
            materialEntity.Id = id;
            var check = (await _materialService.GetMaterialAsync(x => x.Name == materialEntity.Name)).FirstOrDefault();

            if (ModelState.IsValid& check == null)
            {       
                   await _materialService.AddMaterialAsync(materialEntity);
                   
                try
                {
                    await _materialService.UpdateAsync(materialEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MaterialEntityExists(materialEntity.Id))
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
            else ModelState.AddModelError("", "Материал с таким именем уже есть");
            return View(materialEntity);

        }

        private async Task<bool> MaterialEntityExists(int id)
        {
            return (await _materialService.GetMaterialAsync(x => x.Id == id)).Any();
        }
    }
}
