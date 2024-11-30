using MedicalAppointment.Application.Dtos.users.Doctor;
using MedicalAppointment.Consumption.ContractsConsumption.users;
using MedicalAppointment.Web.Models.Core;
using MedicalAppointment.Web.Models.users.DoctorTaskModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalAppointment.Web.Controllers.users.Adm
{
    public class DoctorAdmController : Controller
    {
        private readonly IDoctorContract doctor_Contract;
        public DoctorAdmController(IDoctorContract doctorContract)
        {
            doctor_Contract = doctorContract;
        }
        public async Task<IActionResult> Index()
        {
            DoctorGetAllModel doctorGetAllModel = await doctor_Contract.GetAll();
            return View(doctorGetAllModel.Model);
        }

        public async Task<IActionResult> Details(int id)
        {
            DoctorGetByIdModel doctorGetByIdModel = await doctor_Contract.GetById(id);
            return View(doctorGetByIdModel.Model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorSaveDto doctorSave)
        {
            DoctorSaveDto doctorSaveDto = await doctor_Contract.Save(doctorSave);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            DoctorGetByIdModel doctorGetByIdModel = await doctor_Contract.GetById(id);
            return View(doctorGetByIdModel.Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorUpdateDto doctorUpdate)
        {
            DoctorUpdateDto doctorUpdateDto = await doctor_Contract.Update(doctorUpdate);
            return RedirectToAction(nameof(Index));
        }

    }
}
