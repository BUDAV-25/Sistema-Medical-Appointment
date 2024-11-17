using MedicalAppointment.Application.Contracts.appointments;
using MedicalAppointment.Application.Dtos.appointments.Appointments;
using MedicalAppointment.Persistance.Interfaces.appointments;
using MedicalAppointment.Persistance.Models.appointments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.appointments
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }
        public async Task <IActionResult> Index()
        {
            var result = await _appointmentsService.GetAll();

            if (result.IsSuccess)
            {
                List<AppointmentsModel> appointmentsService = (List<AppointmentsModel>)result.Data;

                return View(appointmentsService);
            }
            return View();
        }

        public async Task <IActionResult> Details(int id)
        {
            var result = await _appointmentsService.GetById(id);

            if (result.IsSuccess)
            {
                AppointmentsModel appointmentsModel = (AppointmentsModel)result.Data;
               
                return View(appointmentsModel);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(AppointmentsSaveDto appointmentsSaveDto)
        {
            try
            {
                appointmentsSaveDto.CreatedAt = DateTime.Now;
                var result = await _appointmentsService.SaveAsync(appointmentsSaveDto);

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

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(AppointmentsUpdateDto appointmentsUpdateDto)
        {
            try
            {
                appointmentsUpdateDto.UpdateAt = DateTime.Now;
                var result = await _appointmentsService.UpdateAsync(appointmentsUpdateDto);

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
