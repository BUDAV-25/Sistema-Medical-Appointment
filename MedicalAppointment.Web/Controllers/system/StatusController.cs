using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Persistance.Models.system;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.system
{
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _statusService.GetAll();

            if (result.IsSuccess)
            {
                List<StatusModel> statusModel = (List<StatusModel>)result.Data;

                return View(statusModel);

            }
            return View();

        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _statusService.GetById(id);

            if (result.IsSuccess)
            {
                StatusModel statusModel = (StatusModel)result.Data;

                return View(statusModel);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusSaveDto statusSaveDto)
        {
            try
            {
                var result = await _statusService.SaveAsync(statusSaveDto);

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
            var result = await _statusService.GetById(id);

            if (result.IsSuccess)
            {
                StatusModel statusModel = (StatusModel)result.Data;

                return View(statusModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StatusUpdateDto statusUpdateDto)
        {
            try
            {
                var result = await _statusService.UpdateAsync(statusUpdateDto);

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
