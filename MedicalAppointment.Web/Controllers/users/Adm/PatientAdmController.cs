using MedicalAppointment.Application.Dtos.users.Patient;
using MedicalAppointment.Consumption.ContractsConsumption.users;
using MedicalAppointment.Web.ModelsMethods.users.PatientTaskModel;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.users.Adm
{
    public class PatientAdmController : Controller
    {
        private readonly IPatientContract patient_Contract;
        public PatientAdmController(IPatientContract patientContract)
        {
            patient_Contract = patientContract;
        }
        public async Task<IActionResult> Index()
        {
            PatientGetAllModel patientGetAllModel = await patient_Contract.GetAll();
            return View(patientGetAllModel.Model);
        }
        public async Task<IActionResult> Details(int id)
        {
            PatientGetByIdModel patientGetByIdModel = await patient_Contract.GetById(id);
            return View(patientGetByIdModel.Model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientSaveDto patientSave)
        {
            PatientSaveDto patientSaveDto = await patient_Contract.Save(patientSave);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            PatientGetByIdModel patientGetByIdModel = await patient_Contract.GetById(id);
            return View(patientGetByIdModel.Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientUpdateDto patientUpdate)
        {
            PatientUpdateDto patientUpdateDto = await patient_Contract.Update(patientUpdate);
            return RedirectToAction(nameof(Index));
        }
    }
}
