using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Dtos.medical.Specialties;
using MedicalAppointment.Persistance.Models.medical;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.medical
{
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialtiesService specialties_Service;
        public SpecialtiesController(ISpecialtiesService specialtiesService)
        {
            specialties_Service = specialtiesService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await specialties_Service.GetAll();
            if (result.IsSuccess)
            {
                List<SpecialtiesModel> specialtiesModels = (List<SpecialtiesModel>)result.Model;
                return View(specialtiesModels);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await specialties_Service.GetById(id);
            if (result.IsSuccess)
            {
                SpecialtiesModel specialtiesModel = (SpecialtiesModel)result.Model;
                return View(specialtiesModel);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialtiesSaveDto specialtiesSave)
        {
            try
            {
                specialtiesSave.CreatedAt = DateTime.Now;
                var result = await specialties_Service.SaveAsync(specialtiesSave);
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
            var result = await specialties_Service.GetById(id);
            if (result.IsSuccess)
            {
                SpecialtiesModel specialtiesModel = (SpecialtiesModel)result.Model;
                return View(specialtiesModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialtiesUpdateDto specialtiesUpdate)
        {
            try
            {
                specialtiesUpdate.UpdatedAt = DateTime.Now;
                var result = await specialties_Service.UpdateAsync(specialtiesUpdate);
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
