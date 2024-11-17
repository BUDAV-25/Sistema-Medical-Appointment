using MedicalAppointment.Application.Contracts.appointments;
using MedicalAppointment.Application.Dtos.appointments.DoctorAvailability;
using MedicalAppointment.Application.Services.appointmet;
using MedicalAppointment.Persistance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.appointments
{
    public class DoctorAvailabilityController : Controller
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;

        public DoctorAvailabilityController(IDoctorAvailabilityService doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }
        public async Task <IActionResult> Index()
        {
            var result = await _doctorAvailabilityService.GetAll();

            if (result.IsSuccess)
            {
                List<DoctorAvailabilityModel> doctorAvailabilityService = (List<DoctorAvailabilityModel>)result.Data;
                
                return View(doctorAvailabilityService);
            }
            return View();
        }

        public async Task <IActionResult> Details(int id)
        {
            var result = await _doctorAvailabilityService.GetById(id);

            if (result.IsSuccess)
            {
                DoctorAvailabilityModel doctorAvailabilityModel = (DoctorAvailabilityModel)result.Data;

                return View(doctorAvailabilityModel);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(DoctorAvailabilitySaveDto doctorAvailabilitySaveDto)
        {
            try
            {
                var result = await _doctorAvailabilityService.SaveAsync(doctorAvailabilitySaveDto);

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

        public async Task <IActionResult> Edit(int id)
        {
            var result = await _doctorAvailabilityService.GetById(id);
            if (result.IsSuccess)
            {
                DoctorAvailabilityModel doctorAvailabilityMode = (DoctorAvailabilityModel)result.Data;

                    return View(doctorAvailabilityMode);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(DoctorAvailabilityUpdateDto doctorAvailabilityUpdateDto)
        {
            try
            {

                var result = await _doctorAvailabilityService.UpdateAsync(doctorAvailabilityUpdateDto);
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
