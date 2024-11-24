using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Dtos.medical.AvailabilityModes;
using MedicalAppointment.Persistance.Models.medical;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.medical
{
    public class AvailabilityModesController : Controller
    {
        private readonly IAvailabilityModesService availabilityModes_Service;
        public AvailabilityModesController(IAvailabilityModesService availabilityModesService)
        {
            availabilityModes_Service = availabilityModesService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await availabilityModes_Service.GetAll();
            if (result.IsSuccess)
            {
                List<AvailabilityModesModel> availabilityModesModels = (List<AvailabilityModesModel>)result.Model;
                return View(availabilityModesModels);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await availabilityModes_Service.GetById(id);
            if (result.IsSuccess)
            {
                AvailabilityModesModel userModel = (AvailabilityModesModel)result.Model;
                return View(userModel);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvailabilityModesSaveDto availabilitySave)
        {
            try
            {
                availabilitySave.CreatedAt = DateTime.Now;
                var result = await availabilityModes_Service.SaveAsync(availabilitySave);
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
            var result = await availabilityModes_Service.GetById(id);
            if (result.IsSuccess)
            {
                AvailabilityModesModel userModel = (AvailabilityModesModel)result.Model;
                return View(userModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AvailabilityModesUpdateDto availabilityUpdate)
        {
            try
            {
                availabilityUpdate.UpdatedAt = DateTime.Now;
                var result = await availabilityModes_Service.UpdateAsync(availabilityUpdate);
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
