using MedicalAppointment.Application.Dtos.medical.MedicalRecords;
using MedicalAppointment.Consumption.ContractsConsumption.medical;
using MedicalAppointment.Consumption.ModelsMethods.medical.MedicalRecordsTaskModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.medical.Adm
{
    public class MedicalRecordsAdmController : Controller
    {
        private readonly IMedicalRecordsContract medicalRecords_Contract;
        public MedicalRecordsAdmController(IMedicalRecordsContract medicalRecordsContract)
        {
            medicalRecords_Contract = medicalRecordsContract;
        }
        public async Task<IActionResult> Index()
        {
            MedicalRecordsGetAllModel medicalRecordsGetAllModel = await medicalRecords_Contract.GetAll();
            return View(medicalRecordsGetAllModel.Model);
        }

        public async Task<IActionResult> Details(int id)
        {
            MedicalRecordsGetByIdModel medicalRecordsGetByIdModel = await medicalRecords_Contract.GetById(id);
            return View(medicalRecordsGetByIdModel.Model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalRecordsSaveDto recordsSave)
        {
            MedicalRecordsSaveDto recordsSaveDto = await medicalRecords_Contract.Save(recordsSave);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            MedicalRecordsGetByIdModel medicalRecordsGetByIdModel = await medicalRecords_Contract.GetById(id);
            return View(medicalRecordsGetByIdModel.Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalRecordsUpdateDto recordsUpdate)
        {
            MedicalRecordsUpdateDto recordsUpdateDto = await medicalRecords_Contract.Update(recordsUpdate);
            return RedirectToAction(nameof(Index));
        }
    }
}
