using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.Doctor;
using MedicalAppointment.Persistance.Models.users;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.users
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctor_Service;
        public DoctorController(IDoctorService doctorService)
        {
            doctor_Service = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await doctor_Service.GetAll();
            if (result.IsSuccess)
            {
                List<DoctorsModel> doctorsModels = (List<DoctorsModel>)result.Model;
                return View(doctorsModels);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await doctor_Service.GetById(id);
            if (result.IsSuccess)
            {
                DoctorDetailsModel doctorDetails = (DoctorDetailsModel)result.Model;
                return View(doctorDetails);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorSaveDto doctorSave)
        {
            try
            {
                doctorSave.CreatedAt = DateTime.Now;
                var result = await doctor_Service.SaveAsync(doctorSave);
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
            var result = await doctor_Service.GetById(id);
            if (result.IsSuccess)
            {
                DoctorDetailsModel doctorDetails = (DoctorDetailsModel)result.Model;
                return View(doctorDetails);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorUpdateDto doctorUpdate)
        {
            try
            {
                doctorUpdate.UpdatedAt = DateTime.Now;
                var result = await doctor_Service.UpdateAsync(doctorUpdate);
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
