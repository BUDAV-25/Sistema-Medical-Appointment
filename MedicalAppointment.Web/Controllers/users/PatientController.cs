using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.Patient;
using MedicalAppointment.Persistance.Models.users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.users
{
    public class PatientController : Controller
    {
        private readonly IPatientService patient_Service;
        public PatientController(IPatientService patientService)
        {
            patient_Service = patientService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await patient_Service.GetAll();
            if (result.IsSuccess)
            {
                List<UserPatientModel> patientModels = (List<UserPatientModel>)result.Model;
                return View(patientModels);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await patient_Service.GetById(id);
            if (result.IsSuccess)
            {
                UserPatientModel userPatient = (UserPatientModel)result.Model;
                return View(userPatient);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientSaveDto patientSave)
        {
            try
            {
                patientSave.CreatedAt = DateTime.Now;
                var result = await patient_Service.SaveAsync(patientSave);
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
            var result = await patient_Service.GetById(id);
            if (result.IsSuccess)
            {
                UserPatientModel userPatient = (UserPatientModel)result.Model;
                return View(userPatient);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientUpdateDto patientUpdate)
        {
            try
            {
                patientUpdate.UpdatedAt = DateTime.Now;
                var result = await patient_Service.UpdateAsync(patientUpdate);
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
