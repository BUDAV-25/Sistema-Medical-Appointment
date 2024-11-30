using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Dtos.medical.MedicalRecords;
using MedicalAppointment.Persistance.Models.medical;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.medical
{
    public class MedicalRecordsController : Controller
    {
        private readonly IMedicalRecordsService medicalRecords_Service;
        public MedicalRecordsController(IMedicalRecordsService medicalRecordsService)
        {
            medicalRecords_Service = medicalRecordsService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await medicalRecords_Service.GetAll();
            if (result.IsSuccess)
            {
                List<MedicalRecordsModel> medicalRecordsModels = (List<MedicalRecordsModel>)result.Model;
                return View(medicalRecordsModels);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await medicalRecords_Service.GetById(id);
            if (result.IsSuccess)
            {
                MedicalRecordsModel medicalRecordsModels = (MedicalRecordsModel)result.Model;
                return View(medicalRecordsModels);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalRecordsSaveDto recordsSaveDto)
        {
            try
            {
                recordsSaveDto.CreatedAt = DateTime.Now;
                var result = await medicalRecords_Service.SaveAsync(recordsSaveDto);
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
            var result = await medicalRecords_Service.GetById(id);
            if (result.IsSuccess)
            {
                MedicalRecordsModel medicalRecordsModels = (MedicalRecordsModel)result.Model;
                return View(medicalRecordsModels);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalRecordsUpdateDto recordsUpdateDto)
        {
            try
            {
                recordsUpdateDto.UpdatedAt = DateTime.Now;
                var result = await medicalRecords_Service.UpdateAsync(recordsUpdateDto);
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
