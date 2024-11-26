using MedicalAppointment.Application.Dtos.appointments.Appointments;
using Microsoft.AspNetCore.Mvc;
using MedicalAppointment.Consumption.ContractsConsumption.appointments;
using MedicalAppointment.Consumption.ModelsMethods.appointments.Appointments;

namespace MedicalAppointment.Web.Controllers.appointments.Adm
{
    public class AppointmentsAdmController : Controller
    {
        private readonly IAppointmentsContracts _appointmentsContracts;
        public AppointmentsAdmController(IAppointmentsContracts appointmentsContracts)
        {
            _appointmentsContracts = appointmentsContracts;
        }

        public async Task<IActionResult> Index()
        {
            var appointmentsGetAll = await _appointmentsContracts.GetAll();
            return View(appointmentsGetAll.data);
        }

        public async Task<IActionResult> Details(int id)
        {
            AppointmentsGetByIdModel appointmentsGetById = await _appointmentsContracts.GetById(id);
            return View(appointmentsGetById.data);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentsSaveDto appointmentsSaveDto)
        {
            AppointmentsSaveDto appointmentsSave = await _appointmentsContracts.Save(appointmentsSaveDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            AppointmentsGetByIdModel appointmentsGetById = await _appointmentsContracts.GetById(id);
            return View(appointmentsGetById.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentsUpdateDto appointmentsUpdateDto)
        {
           AppointmentsUpdateDto appointmentsUpdate = await _appointmentsContracts.Update(appointmentsUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
