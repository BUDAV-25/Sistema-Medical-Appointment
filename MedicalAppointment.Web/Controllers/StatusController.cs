using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Persistance.Models.system;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusService  _statusService;

        public StatusController(IStatusService statusService)
        {
            this._statusService = statusService;
        }
        public async Task <IActionResult> Index()
        {
            var result = await _statusService.GetAll();

            if (result.IsSuccess)
            {
                List<StatusModel> statusModel = (List<StatusModel>) result.Data;

                return View(statusModel);
            }
            return View();
        }

        public async Task <IActionResult> Details(int id)
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task <IActionResult> Edit(int id)
        {
            var result = await _statusService.GetById(id);

            if (result.IsSuccess) 
            {
                StatusModel model = (StatusModel)result.Data; 

                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
