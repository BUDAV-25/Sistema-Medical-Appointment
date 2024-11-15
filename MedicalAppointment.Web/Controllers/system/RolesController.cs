using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Persistance.Models.system;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.system
{
    public class RolesController : Controller
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _rolesService.GetAll();

            if (result.IsSuccess)
            {
                List<RolesModel> rolesModels = (List<RolesModel>)result.Data;

                return View(rolesModels);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _rolesService.GetById(id);

            if (result.IsSuccess)
            {
                RolesModel rolesModel = (RolesModel)result.Data;

                return View(rolesModel);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolesSaveDto rolesSaveDto)
        {
            try
            {
                rolesSaveDto.CreatedAt = DateTime.Now;
                var result = await _rolesService.SaveAsync(rolesSaveDto);


                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Messages;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _rolesService.GetById(id);

            if (result.IsSuccess)
            {
                RolesModel rolesModel = (RolesModel)result.Data;

                return View(rolesModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RolesUpdateDto rolesUpdateDto)
        {
            try
                
            {   rolesUpdateDto.UpdateAt = DateTime.Now;
                var result = await _rolesService.UpdateAsync(rolesUpdateDto);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Messages;
                    return View();
                }
            }

            catch
            {
                return View();
            }
        }

    }
}
