using MedicalAppointment.Application.Dtos.appointments.DoctorAvailability;
using MedicalAppointment.Consumption.ContractsConsumption.appointments;
using MedicalAppointment.Consumption.ModelsMethods.appointments.DoctorAvailability;
using Microsoft.AspNetCore.Mvc;


namespace MedicalAppointment.Web.Controllers.appointments.Adm
{
    public class DoctorAvailabilityAdmController : Controller
    {
        private readonly IDoctorAvailabilityContracts _doctorAvailabilityContracts;
        public DoctorAvailabilityAdmController(IDoctorAvailabilityContracts doctorAvailabilityContracts)
        {
            _doctorAvailabilityContracts = doctorAvailabilityContracts;
        }

        public async Task<IActionResult> Index()
        {
            DoctorAvailabilityGetAllModel doctorAvailabilityGetAll = await _doctorAvailabilityContracts.GetAll();
            return View(doctorAvailabilityGetAll.data);
        }

        public async Task<IActionResult> Details(int id)
        {
            DoctorAvailabilityGetByIdModel doctorAvailabilityGetById = await _doctorAvailabilityContracts.GetById(id);
            return View(doctorAvailabilityGetById.data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAvailabilitySaveDto doctorAvailabilitySaveDto)
        {
            DoctorAvailabilitySaveDto doctorAvailabilitySave = await _doctorAvailabilityContracts.Save(doctorAvailabilitySaveDto);   
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int id)
        {
            DoctorAvailabilityGetByIdModel doctorAvailabilityGetById = await _doctorAvailabilityContracts.GetById(id);
            return View(doctorAvailabilityGetById.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(DoctorAvailabilityUpdateDto doctorAvailabilityUpdateDto)
        {
            DoctorAvailabilityUpdateDto doctorAvailabilityUpdate = await _doctorAvailabilityContracts.Update(doctorAvailabilityUpdateDto);
            return RedirectToAction(nameof(Index));

        }
    }
}
